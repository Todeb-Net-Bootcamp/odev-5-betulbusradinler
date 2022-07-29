using AutoMapper;
using Business.Abstract;
using Business.Configuration.Extension;
using Business.Configuration.Response;
using Business.Configuration.Response.Validator.FluentValidation;
using Business.Configuration.Validator.FluentValidation;
using DataAccessLayer.Abstarct;
using DTO.Department;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{

    // Insert, Update, Delete command olarak lşiteratürde geçer. 
    // GetAll() ise query diye geçer. VT de çektiklerimiz sorgudur.
    // Business katmanı DAL katmanına gidicek. DAL katmanından da vt ye gidip ilgili operasyonları yapacak
    // Business katmanından DAL katamanına neyle erişeceğiz. INTERFACE ile gidicez.
    // Business katmanındayız burada veritabanına gitmeden valid etmiş olduk.
    public class DepartmentServisce : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;

        // mapper ı kullanabilmek için bu interface i ekledik
        private IMapper _mapper;

        public DepartmentServisce(IDepartmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public IEnumerable<Department> GetAll()
        {
           return _repository.GetAll();
        }



        public CommandResponse Delete(Department department)
        {
            _repository.Delete(department);
            return new CommandResponse
            {
                Status = true,
                Message = $"Müşteri Silindi Id={department.Id}"
            };
        }

        public CommandResponse Insert(CreateDepartmentRequest request)
        {  // Validation vs -> Business Logic. DAL katmanında bu işlemleri yapmayız. DAL katmanı sadece vt operasyonlarını işler
            // Business ın bir üst katmanı Prensentation. Presentation a biz API den erişiyorduk.
            //  _repository.Insert(department);

            // Burada modellerimizi kontrol etmiş olduk. Ayrıca modelleri kontrol edip veritabanına gitmemesini sağladık
            var validator = new CreateDepartmentRequestValidator();

            validator.Validate(request).ThrowErrorIfException();

            var entity = _mapper.Map<Department>(request);
            _repository.Insert(entity);

            return new CommandResponse
            {
                Status = true,
                Message = $"Müşteri Eklendi"
            };
        }

        public CommandResponse Update(UpdateDepartmentRequest request)
        {

            var validator = new UpdateDepartmentRequestValidation();
            validator.Validate(request).ThrowErrorIfException();

            var mappedEntity = _mapper.Map<Department>(request);
            _repository.Update(mappedEntity);
            //var validator = new UpdateDepartmentRequestValidation();
            //var valid = validator.Validate(request);

            //if (valid.IsValid == false)
            //{
            //    // string join list şeklindeki stringleri bize tek bir satır halinde vermeye yarar
            //    var message = string.Join(',', valid.Errors.Select(x => x.ErrorMessage));
            //    throw new ValidationException(message);
            //}


            return new CommandResponse
            {
                Status = true,
                Message = $"Müşteri Eklendi"
            };
        }
    }
}
