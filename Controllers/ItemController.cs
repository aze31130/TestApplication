using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        public static string[] itemNames = { "The Jingling Jester", "Nepta Flowrider", "Singularity" };
        public static string[] itemDescriptions = { "Fabled Item", "Legendary Item", "Mythical Item" };
        public static int[] itemPower = { 15, 33, 75 };
        public static int itemAmount = 3;
        public static List<Items> CreateItems()
        {
            List<Items> items = new List<Items>();
            for (int i = 0; i < itemAmount; i++)
            {
                items.Add(new Items(itemNames[i], itemDescriptions[i], itemPower[i]));
            }
            return items;
        }

        [HttpGet]
        public IEnumerable<Items> GetStudents()
        {
            return CreateItems();
        }

        [HttpPost]
        public string PostItem(string message)
        {
            /*Items jsonString = JsonSerializer.Deserialize<Items>(item);
            itemNames.Append(item.name);
            itemDescriptions.Append(item.description);
            itemPower.Append(item.power);
            itemAmount++;
            return CreateItems();*/
            return "Hey, you just posted: " + message;
        }

        [HttpPut("{name}")]
        public string PutItem(string item)
        {
            return "Hey, you just puted: " + item;
        }

        [HttpGet("{name}")]
        public ActionResult<Items> GetItemById(string name)
        {
            var item = CreateItems().SingleOrDefault(x => x.name == name);
            if (item != null)
            {
                return item;
            }
            else
            {
                return NotFound();
            }
        }
    }
}
