using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1_Repo
{
    public class MenuItems
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set;  }
        public List<string> Ingredients { get; set; }
        public MenuItems(int iD, string name, string description, int price, List<string> ingredients)
        {
            ID = iD;
            Name = name;
            Description = description;
            Price = price;
            Ingredients = ingredients;
        }

        public MenuItems()
        {
        }
    }
}
