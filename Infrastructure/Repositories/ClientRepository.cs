using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class ClientRepository : EfRepository<Client>, IClientRepository
    {
        public ClientRepository(ClientManagementSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Client> UpdateAsync(int id, Client c)
        {
            var client = _dbContext.Set<Client>().Find(id);
            if (client != null)
            {
                client.Name = c.Name;
                client.Email = c.Email;
                client.Phones = c.Phones;
                client.Address = c.Address;
                client.AddedOn = c.AddedOn;

                int affected = await _dbContext.SaveChangesAsync();
                if (affected == 1)
                {
                    return client;
                }
            }

            return null;

        }
    }
}
