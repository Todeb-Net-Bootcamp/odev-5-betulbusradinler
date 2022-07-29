using DTO.Department;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Configuration.Response.Validator.FluentValidation
{
    public class CreateDepartmentRequestValidator : AbstractValidator<CreateDepartmentRequest>
    {
      public CreateDepartmentRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Departman Adı Boş Geçilemez");
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.FacultyName).NotEmpty();
            RuleFor(x => x.HeadOfDepartment).NotEmpty();
        }
    }
}
