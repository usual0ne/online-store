using System;
using System.Collections.Generic;
using System.Text;
using OnlineStore.Entities;

namespace Infrastructure.DataAccess
{
    public interface IProductRepository
    {
        IReadOnlyList<Product> GetProductsByName(string name);
        void HideProduct(Product product);
        void Add(Product product);
        void Update(Product product);
        Product Get(int id);
    }
}
