using CdbBffSolution.Domain.Entities;

namespace CdbBffSolution.Domain.IRepository
{
    public interface IProductCustomerRepository
    {
        Task<ProductCustomer> Add(ProductCustomer customerDto);
        Task<List<ProductCustomer>> GetAll();
        Task<ProductCustomer> GetById(int id);
        Task<ProductCustomer> Update(ProductCustomer customerDto);
        Task<int> Delete(int id);
    }
}
