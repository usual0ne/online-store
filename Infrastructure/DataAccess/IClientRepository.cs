using System;
using System.Collections.Generic;
using System.Text;
using OnlineStore.Entities;

namespace Infrastructure.DataAccess
{
    public interface IClientRepository
    {
        Client Get(int id);
        void Add(Client client);
        void Update(Client client);
        IReadOnlyList<Client> GetClientByLastName(string lastName);
        IReadOnlyList<Client> GetClientByFirstName(string firstName);
    }
}
