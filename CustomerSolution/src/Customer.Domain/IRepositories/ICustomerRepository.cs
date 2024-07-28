

using Customer.Domain.Entities;

namespace Customer.Domain.IRepositories
{
    public interface ICustomerRepository
    {
        Task<Client> Add(Client customerDto);
        Task<List<Client>> GetAll();
        Task<Client> GetById(int id);
        Task<Client> Update(Client customerDto);
        Task<int> Delete(int id);
    }
}
