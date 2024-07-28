using Customer.Application.Dtos;
using Customer.Domain.Entities;

namespace Customer.Application.IServices
{
    public interface ICustomerServices
    {
        Task<Client> Add(CustomerDto customerDto);
        Task<List<Client>> GetAll();
        Task<Client> GetById(int id);
        Task<Client> Update(CustomerDto customerDto, int id);
        Task<int> Delete(int id);
    }
}
