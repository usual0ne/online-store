using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Entities
{
   public class Product : AuditableEntity
   {
        public string Name { get; set; }
        public double Price { get; set; }
        public bool Available { get; set; }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
            Available = true;
        }

        //For EF Core
        public Product()
        {

        }
   }
}
