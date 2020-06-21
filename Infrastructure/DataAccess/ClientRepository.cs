using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using OnlineStore.Entities;

namespace Infrastructure.DataAccess
{
    public class ClientRepository : AuditableRepository<Client>, IClientRepository
    {
        private readonly AppDbContext _dbContext;
        public ClientRepository(AppDbContext dbContext) : base(dbContext)
        {
             _dbContext = dbContext;
        }

        public IReadOnlyList<Client> GetClientByFirstName(string firstName)
        {
            return _dbContext.Clients.Where(x => x.FirstName.ToLower().Contains(firstName.ToLower())).ToList();
        }

        public IReadOnlyList<Client> GetClientByLastName(string lastName)
        {
            return _dbContext.Clients.Where(x => x.LastName.ToLower().Contains(lastName.ToLower())).ToList();
        }
    }
}
