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
    public class InteractionService : IInteractionService
    {
        private readonly IInteractionRepository _interactionRepository;

        public InteractionService(IInteractionRepository interactionRepository)
        {
            _interactionRepository = interactionRepository;
        }

        public async Task<InteractionResponseModel> GetInteractionById(int id)
        {
            var interaction = await _interactionRepository.GetByIdAsync(id);

            if (interaction == null)
            {
                throw new Exception($"No Interaction Found for this {id}");
            }
            var interactionDetails = new InteractionResponseModel()
            {
                Id = interaction.Id,
                EmpId = interaction.EmpId,
                ClientId = interaction.ClientId,
                IntType = interaction.IntType,
                IntDate = interaction.IntDate,
                Remarks = interaction.Remarks,
            };


            return interactionDetails;

        }

        public async Task<List<InteractionResponseModel>> GetInteractions()
        {
            var interactions = await _interactionRepository.ListAllAsync();
            var interactionsModels = new List<InteractionResponseModel>();
            foreach (var i in interactions)
            {
                interactionsModels.Add(new InteractionResponseModel
                {
                    Id = i.Id,
                    EmpId = i.EmpId,
                    ClientId = i.ClientId,
                    IntType = i.IntType,
                    IntDate = i.IntDate,
                    Remarks = i.Remarks,
                    

                });
            }

            return interactionsModels;
        }



        public async Task<InteractionResponseModel> AddInteraction(InteractionRequestModel model)
        {
            var newInteraction = new Interaction
            {
                
                EmpId = model.EmpId,
                ClientId = model.ClientId,
                IntType = model.IntType,
                IntDate = model.IntDate,
                Remarks = model.Remarks,
            };

            var dbInteraction = await _interactionRepository.AddAsync(newInteraction);

            var interactionModel = new InteractionResponseModel
            {
                Id = dbInteraction.Id,
                EmpId = dbInteraction.EmpId,
                ClientId = dbInteraction.ClientId,
                IntType = dbInteraction.IntType,
                IntDate = dbInteraction.IntDate,
                Remarks = dbInteraction.Remarks,

            };
            return interactionModel;
        }



        public async Task DeleteInteraction(int id)
        {
            await _interactionRepository.DeleteAsync(id);



        }



        public async Task<Interaction> UpdateInteraction(int id, InteractionRequestModel model)
        {

            var dbInteraction = new Interaction
            {
                EmpId = model.EmpId,
                ClientId = model.ClientId,
                IntType = model.IntType,
                IntDate = model.IntDate,
                Remarks = model.Remarks,
            };
            var updatedInteraction = await _interactionRepository.UpdateAsync(id, dbInteraction);
            return updatedInteraction;
        }


    }
}

