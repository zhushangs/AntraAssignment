using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IClientsService
    {
        Task<List<ClientResponseModel>> GetAllClients();
        Task<ClientResponseModel> CreateClient(ClientRequestModel clientRequestModel);
        Task<ClientResponseModel> GetClientById(int id);
        Task<ClientResponseModel> UpdateClient(ClientUpdateRequestModel clientUpdateRequestModel, int id);
        Task DeleteClient(int id);
    }
}
