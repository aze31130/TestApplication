using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Items
    {
        public Items(string _name, string _description, int _power)
        {
            name = _name;
            description = _description;
            power = _power;
        }

        public string name { get; set; }
        public string description { get; set; }
        public int power { get; set; }

    }
}
