using LoggingWithSerilog.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog.AspNetCore;
using System.Reflection.Metadata.Ecma335;


namespace LoggingWithSerilog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> logger;

        public StudentController(ILogger<StudentController> logger) 
        { 
            this.logger = logger;
        }

        [HttpGet(Name = "GetStudent")]
        public IEnumerable<Student> Get()
        {
            //Testing Exception here
            if (true)
            {
              throw new Exception("Failed to retrieve data");
            }

            //Testing Logs Here
            var response = Enumerable.Range(1, 1).Select(index => new Student
            {
                Address = "Taxus USA",
                GraduationYear = 2023,
                Name = "Teodora"
            }).ToArray();
            logger.LogDebug("Inside GetStudent endpoint");
            logger.LogDebug($"The response for the GetStudent is {JsonConvert.SerializeObject(response)}");
            
            return response;
        }
    }
}
