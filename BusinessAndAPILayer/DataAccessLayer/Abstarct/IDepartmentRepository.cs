using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstarct
{
    public interface IDepartmentRepository
    {
        public IEnumerable<Department> GetAll();
        public void Insert(Department department);
        public void Update(Department department);
        public void Delete(Department department);
    }
}
