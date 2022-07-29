using DataAccessLayer.Abstarct;
using DataAccessLayer.DBContexts;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class DepartmentRepository : IDepartmentRepository
    {
        // burada operasyonlar yapılacak bunun için dbcontext e ihtiyacım var 
        private SchoolDbContext context;
        public DepartmentRepository(SchoolDbContext context)
        {
            this.context = context;
        }
   

        public IEnumerable<Department> GetAll()
        {

            return context.Departments.ToList();
        }
        public void Insert(Department department)
        {
            context.Departments.Add(department);
            context.SaveChanges();
        }

        public void Update(Department department)
        {
            context.Departments.Update(department);
            context.SaveChanges();
        }

        public void Delete(Department department)
        {

            context.Departments.Remove(department);
            context.SaveChanges();
        }
    }
}
