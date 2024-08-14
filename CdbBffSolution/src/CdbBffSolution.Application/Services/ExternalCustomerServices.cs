using CdbBffSolution.Application.Dtos;
using CdbBffSolution.Application.IServices;
using CdbBffSolution.Domain.Entities;
using System.Net.Http.Json;

namespace CdbBffSolution.Application.Services
{
    public class ExternalCustomerServices : IExternalCustomerServices
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly Uri _baseApiUrl;


        public ExternalCustomerServices(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _baseApiUrl = new Uri("https://localhost:7276/api/Customer/");
        }

        public async Task AddCustomer(CustomerDto customerDto)
        {
            using var httpClient = _httpClientFactory.CreateClient();
            await httpClient.PostAsJsonAsync(_baseApiUrl + "create", customerDto);
        }

        public async Task DeleteCustomer(int idCustomer)
        {
            using var httpClient = _httpClientFactory.CreateClient();
            await httpClient.DeleteAsync(_baseApiUrl + $"delete?idCustomer={idCustomer}");
        }

        public async Task<List<Customer>> GetCustomer()
        {
            using var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetFromJsonAsync<Customer[]>($"{_baseApiUrl}list");

            return response?.ToList() ?? new List<Customer>();
        }

        public async Task UpdateCustomer(CustomerDto customerDto, int id)
        {
            using var httpClient = _httpClientFactory.CreateClient();
            await httpClient.PutAsJsonAsync(_baseApiUrl + "update/" + id, customerDto);
        }
    }
}
