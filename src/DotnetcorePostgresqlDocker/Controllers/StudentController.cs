using Microsoft.AspNetCore.Mvc;

namespace DotnetcorePostgresqlDocker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IConfiguration _configuration;

        public StudentController(ILogger<StudentController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet("")]
        public IEnumerable<Student> Get()
        {
            using (var dbContext = new ApplicationContext(_configuration))
            {
                return dbContext.Students.ToList();
            }
        }

        [HttpGet("add/{name}")]
        public void Add(string name)
        {
            using (var dbContext = new ApplicationContext(_configuration))
            {
                dbContext.Students.Add(new Student { Name = name });
                dbContext.SaveChanges();
            }
        }
    }
}
