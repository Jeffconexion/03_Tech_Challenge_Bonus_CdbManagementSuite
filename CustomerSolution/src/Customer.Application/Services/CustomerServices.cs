using Customer.Application.Dtos;
using Customer.Application.IServices;
using Customer.Domain.Entities;
using Customer.Domain.IRepositories;

namespace Customer.Application.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerServices(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Client> Add(CustomerDto customerDto)
        {
            var client = new Client
            {
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
                BirthDate = customerDto.BirthDate,
                CreationDate = DateTime.Now,
                Email = customerDto.Email,
                IsActive = customerDto.IsActive
            };

            var response = await _customerRepository.Add(client);
            return response;
        }

        public async Task<int> Delete(int id)
        {
            var response = await _customerRepository.Delete(id);
            return response;
        }

        public async Task<List<Client>> GetAll()
        {
            var response = await _customerRepository.GetAll();
            return response;
        }

        public async Task<Client> GetById(int id)
        {
            var response = await _customerRepository.GetById(id);
            return response;
        }

        public async Task<Client> Update(CustomerDto customerDto, int id)
        {

            var record = await _customerRepository.GetById(id);
            if (record is not null)
            {
                record.FirstName = customerDto.FirstName;
                record.LastName = customerDto.LastName;
                record.BirthDate = customerDto.BirthDate;
                record.CreationDate = DateTime.Now;
                record.Email = customerDto.Email;
                record.IsActive = customerDto.IsActive;

                var response = await _customerRepository.Update(record);
                return response;
            }
            return record;

        }
    }
}
