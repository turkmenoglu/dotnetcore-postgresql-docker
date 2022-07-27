using Microsoft.EntityFrameworkCore;

namespace DotnetcorePostgresqlDocker
{
    public class ApplicationContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(_configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<Student> Students {get; set;}
        public DbSet<Teacher> Teachers {get; set; }
    }

    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class Teacher
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}