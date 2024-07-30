using CdbBffSolution.Application.Dtos;
using CdbBffSolution.Domain.Entities;

namespace CdbBffSolution.Application.IServices
{
    public interface IProductClientServices
    {
        Task<ProductClient> Add(ProductClientDto customerDto);
        Task<List<ProductClient>> GetAll();
        Task<ProductClient> GetById(int id);
        Task<ProductClient> Update(ProductClientDto customerDto, int id);
        Task<int> Delete(int id);
    }
}
