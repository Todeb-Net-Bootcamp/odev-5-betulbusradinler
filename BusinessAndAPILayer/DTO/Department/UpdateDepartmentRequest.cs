using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Department
{
    public class UpdateDepartmentRequest
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string FacultyName { get; set; }
        public string HeadOfDepartment { get; set; }
    }
}
