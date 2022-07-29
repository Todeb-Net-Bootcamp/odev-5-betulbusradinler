using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    public class Student
    {

        [Key]
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string StudentNo { get; set; }

        public int DepartmentID { get; set; }  // Olmayan bir bölümde öğrenci de olmaz
        public DateTime BirthDate { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }


        [ForeignKey("DepartmentID")]
        public Department Department { get; set; }
    }
}
