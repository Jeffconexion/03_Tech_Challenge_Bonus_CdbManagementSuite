using CdbBffSolution.Domain.Entities;

namespace CdbBffSolution.Application.IServices
{
    public interface IExternalProductServices
    {
        Task<List<ProductEntity>> GetAllAsync();
    }
}
