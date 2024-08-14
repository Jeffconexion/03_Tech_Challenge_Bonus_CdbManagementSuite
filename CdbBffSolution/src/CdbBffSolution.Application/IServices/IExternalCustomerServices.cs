using CdbBffSolution.Application.Dtos;
using CdbBffSolution.Domain.Entities;

namespace CdbBffSolution.Application.IServices
{
    public interface IExternalCustomerServices
    {
        Task AddCustomer(CustomerDto customerDto);
        Task<List<Customer>> GetCustomer();
        Task UpdateCustomer(CustomerDto customerDto, int id);
        Task DeleteCustomer(int idCustomer);
    }
}
