using DinnerBooking.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinnerBooking.Domain.Entities
{
    public class Menu : EntityBase
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        private readonly List<MenuItem> menuItems = new List<MenuItem>();
        public IReadOnlyList<MenuItem> Items => menuItems;

        public Menu(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public void AddMenuItem(MenuItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Item cannot be null");
            }
            menuItems.Add(item);
        }


    }


    public class MenuItem
    {
        public string? ItemId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public float Price { get; private set; }

        public MenuItem(string name, string description, float price)
        {
            Name = name;
            Description = description;
            Price = price;
            ItemId = Guid.NewGuid().ToString();
        }
    }


}
