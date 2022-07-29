using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models.Entities;

namespace DataAccessLayer.DBContexts
{
    public class SchoolDbContext:DbContext
    {
        // Bu da bir dependency Injectiondır ama bunu .net core kendisi ayarlıyor.
        private IConfiguration _configuration;
        public SchoolDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentLesson> StudentsLessons { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder.UseSqlServer("Server=ERENINPC\\SQLEXPRESS03;Database=School;Trusted_Connection=True;"));
            // Yukarıda Magic String olarak verdiğimiz ifadeyi artık IConfiguring den alıcaz.

            var connectionString = _configuration.GetConnectionString("MsConn");
            base.OnConfiguring(optionsBuilder.UseSqlServer(connectionString));
        }
    }
}
//Migration modellerin arasıdaki bağlantıların saklanır
