using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        public static List<Games> GetGames()
        {
            List<Games> games = new List<Games>();
            games.Add(new Games() { Id = 1, Name = "First", Price = 10 });
            games.Add(new Games() { Id = 2, Name = "Second", Price = 50000 });
            games.Add(new Games() { Id = 3, Name = "Third", Price = 42424242 });
            return games;
        }

        [HttpGet]
        public IEnumerable<Games> GetGames_List()
        {
            return GetGames();
        }


        [HttpGet("{id}")]
        public ActionResult<Games> GetGames_ById(int id)
        {
            var games = GetGames().SingleOrDefault(x => x.Id == id);
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
