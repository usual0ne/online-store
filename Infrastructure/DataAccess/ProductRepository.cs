using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using OnlineStore.Entities;

namespace Infrastructure.DataAccess
{
    public class ProductRepository : AuditableRepository<Product>, IProductRepository
    {
        private readonly AppDbContext _dbContext;
        public ProductRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IReadOnlyList<Product> GetProductsByName(string name)
        {
            return _dbContext.Products.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();
        }

        public void HideProduct(Product product)
        {
            if (product.Available == true)
            {
                product.ModifiedAt = DateTime.Now;
                product.Available = false;
                SaveChanges();
            }
        }
    }
}
