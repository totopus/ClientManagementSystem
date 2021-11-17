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
    public class InteractionRepository : EfRepository<Interaction>, IInteractionRepository
    {
        public InteractionRepository(ClientManagementSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Interaction> UpdateAsync(int id, Interaction i)
        {
            var interaction = _dbContext.Set<Interaction>().Find(id);
            if (interaction != null)
            {
                interaction.EmpId = i.EmpId;
                interaction.ClientId = i.ClientId;
                interaction.IntType = i.IntType;
                interaction.IntDate = i.IntDate;
                interaction.Remarks = i.Remarks;

                int affected = await _dbContext.SaveChangesAsync();
                if (affected == 1)
                {
                    return interaction;
                }
            }

            return null;
        }
    }
}
