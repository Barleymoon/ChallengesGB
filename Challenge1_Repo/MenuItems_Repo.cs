using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1_Repo
{
    public class MenuItems_Repo
    {
        private readonly List<MenuItems> _inventory = new List<MenuItems>();

        public int Count
        {
            get
            {
                return _inventory.Count;
            }
        }

        public bool AddItemsToInventory(MenuItems items)
        {
            int startingCount = _inventory.Count;
            _inventory.Add(items);

            bool wasAdded = _inventory.Count > startingCount;
            return wasAdded;
        }

        public List<MenuItems> ShowItems()
        {
            return _inventory;
        }

        public MenuItems GetItemsByName(string name)
        {
            foreach (MenuItems items in _inventory)
            {
                if (name.ToLower() == items.Name.ToLower())
                {
                    return items;
                }
            }
            return null;
        }
        public bool DeleteItems(string name)
        {
            MenuItems MenuItemsToDelete = GetItemsByName(name);
            return _inventory.Remove(MenuItemsToDelete);
        }
    }
}
