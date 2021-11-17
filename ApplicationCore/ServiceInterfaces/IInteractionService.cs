using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IInteractionService
    {
        public Task<List<InteractionResponseModel>> GetInteractions();
        public Task<InteractionResponseModel> GetInteractionById(int id);
        public Task<InteractionResponseModel> AddInteraction(InteractionRequestModel model);
        public Task DeleteInteraction(int id);
        public Task<Interaction> UpdateInteraction(int id, InteractionRequestModel model);
    }
}
