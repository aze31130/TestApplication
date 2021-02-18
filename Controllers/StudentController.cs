using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        public static List<Students> CreateRandomStudent()
        {
            List<Students> students = new List<Students>();
            string[] randomFirstNames = {"Michel", "Edward", "Jack" };
            string[] randomLastNames = { "O'Calagan", "O'Nyme", "Jackson" };
            Random rng = new Random();
            
            for (int i = 0 ; i < 10 ; i++)
            {
                students.Add(new Students() { id = i, firstName = randomFirstNames[rng.Next(randomFirstNames.Length)],
                    lastName = randomLastNames[rng.Next(randomFirstNames.Length)], age = rng.Next(99), studyYear = 2021 });
            }
            return students;
        }

        [HttpGet]
        public IEnumerable<Students> GetStudents()
        {
            return CreateRandomStudent();
        }


        [HttpGet("{id}")]
        public ActionResult<Students> GetStudents_ById(int id)
        {
            var games = CreateRandomStudent().SingleOrDefault(x => x.id == id);
            if (games != null)
            {
                return games;
            }
            else
            {
                return NotFound();
            }
        }
    }
}
