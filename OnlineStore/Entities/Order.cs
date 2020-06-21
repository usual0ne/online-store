using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace OnlineStore.Entities
{
  public class Order : AuditableEntity
  {
        //Order has client, show single relationship to client
        public virtual Client Client { get; set; }

        //Order has product, show single relationship to product
        public virtual Product Product { get; set; }
        public Order(Client client, Product product, DateTime createdAt)
        {
            Client = client;
            Product = product;
            CreatedAt = createdAt;
        }

        //For EF Core
        public Order()
        {

        }
  }
}
