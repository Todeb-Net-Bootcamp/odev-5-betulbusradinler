using DataAccessLayer.DBContexts;
using System;
using Models.Entities;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //using(var db = new SchoolDbContext())
            //{
            //    var less = new Lesson()
            //    {
            //        Name = "fsdfds Ağldsfsdarı",
            //        Code = "dsfsdfsd",
            //        DepartmentID = 1
            //    };

            //    db.Lessons.Add(less);   
            //    db.SaveChanges();

            //    var student = new Student()
            //    {
            //        FirstName = "sdasdsa Betül",
            //        LastName = "DİNLdsadsaER",
            //        StudentNo = "127sad12653",
            //        City = "Muğla",
            //        DepartmentID = 1,
            //        Phone = "37173"
            //    };

            //    db.Students.Add(student);
            //    db.SaveChanges();
            }
        }
    }
}
