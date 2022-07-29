using AutoMapper;
using DTO.Department;
using Models.Entities;

namespace Business.Configuration.Mapper
{
    public class MapperProfile:Profile
    {
        // CreateDepartmentRequestten --> Department elde edeceğiz
        public MapperProfile()
        {
            // Auto Mapper sayesinde DTO ile Entity i mapledik
            // Dto aracılığıyla veritabanına direkt erişimi ortadan kaldırdık
            // Entity ile de verileri vt ye kaydediyoruz
               CreateMap<CreateDepartmentRequest, Department>();
               CreateMap<CreateDepartmentRequest, Department>();
        }
    }
}
