using CdbBffSolution.Application.Dtos;
using CdbBffSolution.Domain.Entities;

namespace CdbBffSolution.Application.IServices
{
    public interface IProductCustomerServices
    {
        Task<ProductCustomer> Add(ProductCustomerDto customerDto);
        Task<List<ProductCustomer>> GetAll();
        Task<ProductCustomer> GetById(int id);
        Task<ProductCustomer> Update(ProductCustomerDto customerDto, int id);
        Task<int> Delete(int id);
    }
}
