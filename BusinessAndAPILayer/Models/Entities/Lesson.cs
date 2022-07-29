using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    public class Lesson
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int DepartmentID { get; set; }

        [ForeignKey("DepartmentID")]
        public Department Department { get; set; }
    }
}
