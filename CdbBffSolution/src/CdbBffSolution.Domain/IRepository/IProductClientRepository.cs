using CdbBffSolution.Domain.Entities;

namespace CdbBffSolution.Domain.IRepository
{
    public interface IProductClientRepository
    {
        Task<ProductClient> Add(ProductClient customerDto);
        Task<List<ProductClient>> GetAll();
        Task<ProductClient> GetById(int id);
        Task<ProductClient> Update(ProductClient customerDto);
        Task<int> Delete(int id);
    }
}
