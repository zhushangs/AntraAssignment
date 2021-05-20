using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IInteractionsService
    {
        Task<List<InteractionResponseModel>> GetAllInteractions();
        Task<InteractionResponseModel> CreateInteraction(InteractionRequestModel interactionRequestModel);
        Task<InteractionResponseModel> GetInteractionById(int id);
        Task<InteractionResponseModel> UpdateInteraction(InteractionUpdateRequestModel interactionUpdateRequestModel, int id);
        Task DeleteInteraction(int id);
    }
}
