using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Models.Entities
{
    public class StudentLesson
    {
        [Key]
        public int Id { get; set; }

        public int StudentId { get; set; }
        public int LessonId { get; set; }


        [ForeignKey("StudentId")] // hem studentın alt tablosu hemde Lessonın
        public Student Students { get; set; }


        //[ForeignKey("LessonId")] // hem studentın alt tablosu hemde Lessonın
        //public Lesson Lesson { get; set; }
    }
}
