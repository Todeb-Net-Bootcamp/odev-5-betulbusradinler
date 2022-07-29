using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Department
{
    // Departman oluşturmak için dışarıdan gelen obje alanları
    public class CreateDepartmentRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string FacultyName { get; set; }
        public string HeadOfDepartment { get; set; }
    }
}
