using CdbBffSolution.Application.IServices;
using CdbBffSolution.Domain.Entities;
using CdbBffSolution.Infrastructure.ExternalServices;

namespace CdbBffSolution.Application.Services
{
    public class ExternalProductServices : IExternalProductServices
    {
        private readonly IExternalProductServicesApiClient _apiClient;

        public ExternalProductServices(IExternalProductServicesApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<ProductEntity>> GetAllAsync()
        {
            var response = await _apiClient.GetAll();
            return response;
        }
    }
}
