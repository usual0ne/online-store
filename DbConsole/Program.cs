using System;
using OnlineStore.Entities;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Collections.Generic;

namespace DbConsole
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=OnlineStore;Trusted_Connection=True;", o => o.MigrationsAssembly("Infrastructure"));
            return new AppDbContext(optionsBuilder.Options);
        }
    }

    class Program
    {
        private static readonly AppDbContext _appContext;
        private static IOrderRepository _orderRepository;
        private static IProductRepository _productRepository;
        private static IClientRepository _clientRepository;

        static Program()
        {
            var factory = new AppDbContextFactory();
            _appContext = factory.CreateDbContext(null);
            _orderRepository = new OrderRepository(_appContext);
            _productRepository = new ProductRepository(_appContext);
            _clientRepository = new ClientRepository(_appContext);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Let's begin!");

            var product = new Product("doll", 200);
            _productRepository.Add(product);

            var client = new Client("Lara", "Croft", "Tobias");
            _clientRepository.Add(client);

            var order = new Order(client, product, DateTime.Now);

            _orderRepository.Add(order);  
        }
    }
}
