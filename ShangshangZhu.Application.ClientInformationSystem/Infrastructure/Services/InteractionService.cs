using ApplicationCore.Entities;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class InteractionService: IInteractionsService
    {
        private readonly IInteractionsRepository _interactionsRepository;
        public InteractionService(IInteractionsRepository interactionsRepository)
        {
            _interactionsRepository = interactionsRepository;
        }

        public async Task<InteractionResponseModel> CreateInteraction(InteractionRequestModel interactionRequestModel)
        {
            var interaction = new Interactions
            {
                ClientId = interactionRequestModel.ClientId,
                EmpId = interactionRequestModel.EmpId,
                IntType = interactionRequestModel.type,
                IntDate = interactionRequestModel.Date,
                Remarks = interactionRequestModel.Remarks,
            };
            var createdInteraction = await _interactionsRepository.AddAsync(interaction);
            var response = new InteractionResponseModel
            {
                Id = createdInteraction.Id,
                ClientId = createdInteraction.ClientId,
                EmpId = createdInteraction.EmpId,
                type = createdInteraction.IntType,
                Date = createdInteraction.IntDate,
                Remarks = createdInteraction.Remarks,
            };
            return response;
        }

        public async Task DeleteInteraction(int id)
        {
            var interaction = await _interactionsRepository.GetByIdAsync(id);
            await _interactionsRepository.DeleteAsync(interaction);
        }

        public async Task<List<InteractionResponseModel>> GetAllInteractions()
        {
            var interactions = await _interactionsRepository.GetAllInteractions();
            var interactionList = new List<InteractionResponseModel>();
            foreach (var interaction in interactions)
            {
                interactionList.Add(new InteractionResponseModel 
                {
                    Id = interaction.Id,
                    ClientId = interaction.ClientId,
                    EmpId = interaction.EmpId,
                    type = interaction.IntType,
                    Date = interaction.IntDate,
                    Remarks = interaction.Remarks,
                });
            }
            return interactionList;
        }

        public async Task<InteractionResponseModel> GetInteractionById(int id)
        {
            var interaction = await _interactionsRepository.GetByIdAsync(id);
            var response = new InteractionResponseModel
            {
                Id = interaction.Id,
                ClientId = interaction.ClientId,
                EmpId = interaction.EmpId,
                type = interaction.IntType,
                Date = interaction.IntDate,
                Remarks = interaction.Remarks,
            };
            return response;
        }

        public async Task<InteractionResponseModel> UpdateInteraction(InteractionUpdateRequestModel interactionUpdateRequestModel, int id)
        {
            var dbInteraction = await _interactionsRepository.GetByIdAsync(id);
            if (dbInteraction == null)
            {
                throw new Exception("No Client Exist");
            }
            var interaction = new Interactions
            {
                Id = dbInteraction.Id,
                ClientId = interactionUpdateRequestModel.ClientId == 0 ? dbInteraction.ClientId : interactionUpdateRequestModel.ClientId,
                EmpId = interactionUpdateRequestModel.EmpId == 0 ? dbInteraction.EmpId : interactionUpdateRequestModel.EmpId,
                IntType = interactionUpdateRequestModel.type == 0 ? dbInteraction.IntType : interactionUpdateRequestModel.type,
                IntDate = interactionUpdateRequestModel.Date == null ? dbInteraction.IntDate : interactionUpdateRequestModel.Date,
                Remarks = interactionUpdateRequestModel.Remarks == null ? dbInteraction.Remarks : interactionUpdateRequestModel.Remarks,
            };
            var updatedInteraction = await _interactionsRepository.UpdateAsync(interaction);
            var response = new InteractionResponseModel
            {
                Id = updatedInteraction.Id,
                ClientId = updatedInteraction.ClientId,
                EmpId = updatedInteraction.EmpId,
                type = updatedInteraction.IntType,
                Date = updatedInteraction.IntDate,
                Remarks = updatedInteraction.Remarks,
            };
            return response;
        }
    }
}
