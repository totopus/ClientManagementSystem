using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IClientService
    {
        public Task<List<ClientResponseModel>> GetClients();
        public Task<ClientResponseModel> GetClientById(int id);
        public Task<ClientResponseModel> AddClient(ClientRequestModel model);
        public Task DeleteClient(int id);
        public Task<Client> UpdateClient(int id, ClientRequestModel model);
    }
}
