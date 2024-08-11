using CdbBffSolution.Domain.Entities;
using Refit;

namespace CdbBffSolution.Infrastructure.ExternalServices
{
    public interface IExternalProductServicesApiClient
    {
        [Get("/Product/list")]
        Task<List<ProductEntity>> GetAll();
    }
}
