using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<ClientResponseModel> GetClientById(int id)
        {
            var client = await _clientRepository.GetByIdAsync(id);

            if (client == null)
            {
                throw new Exception($"No Client Found for this {id}");
            }
            var clientDetails = new ClientResponseModel()
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email,
                Phones = client.Phones,
                Address = client.Address,
                AddedOn = client.AddedOn,
                
            };


            return clientDetails;

        }

        public async Task<List<ClientResponseModel>> GetClients()
        {
            var clients = await _clientRepository.ListAllAsync();
            var clientsModels = new List<ClientResponseModel>();
            foreach (var client in clients)
            {
                clientsModels.Add(new ClientResponseModel
                {
                    Id = client.Id,
                    Name = client.Name,
                    Email = client.Email,
                    Phones = client.Phones,
                    Address = client.Address,
                    AddedOn = client.AddedOn,

                });
            }

            return clientsModels;
        }



        public async Task<ClientResponseModel> AddClient(ClientRequestModel model)
        {
            var newClient = new Client
            {
                Name = model.Name,
                Email = model.Email,
                Phones = model.Phones,
                Address = model.Address,
                AddedOn = model.AddedOn,
            };

            var dbClient = await _clientRepository.AddAsync(newClient);

            var clientModel = new ClientResponseModel
            {
                Id = dbClient.Id,
                Name = dbClient.Name,
                Email = dbClient.Email,
                Phones = dbClient.Phones,
                Address = dbClient.Address,
                AddedOn = dbClient.AddedOn,

            };
            return clientModel;
        }



        public async Task DeleteClient(int id)
        {
            await _clientRepository.DeleteAsync(id);



        }



        public async Task<Client> UpdateClient(int id, ClientRequestModel model)
        {

            var dbClient = new Client
            {
                Name = model.Name,
                Email = model.Email,
                Phones = model.Phones,
                Address = model.Address,
                AddedOn = model.AddedOn,
            };
            var updatedClient = await _clientRepository.UpdateAsync(id, dbClient);
            return updatedClient;
        }

       
    }
}

