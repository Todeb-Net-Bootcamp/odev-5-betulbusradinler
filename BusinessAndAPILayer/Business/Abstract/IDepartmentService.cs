using Business.Configuration.Response;
using DTO.Department;
using Models.Entities;
using System.Collections.Generic;

namespace Business.Abstract
{
    public  interface  IDepartmentService
    {
        public IEnumerable<Department> GetAll();
        public CommandResponse Insert(CreateDepartmentRequest department);
        public CommandResponse Update(UpdateDepartmentRequest department);
        public CommandResponse Delete(Department department);
    }
}
