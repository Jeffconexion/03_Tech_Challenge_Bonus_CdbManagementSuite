using CdbBffSolution.Application.Dtos;
using CdbBffSolution.Application.IServices;
using CdbBffSolution.Domain.Entities;
using CdbBffSolution.Domain.IRepository;

namespace CdbBffSolution.Application.Services
{
    public class ProductClientServices : IProductClientServices
    {
        private readonly IProductClientRepository _productClientRepository;

        public ProductClientServices(IProductClientRepository productClientRepository)
        {
            _productClientRepository = productClientRepository;
        }

        public async Task<ProductClient> Add(ProductClientDto productClientDto)
        {
            var productClient = new ProductClient
            {
                ClientId = productClientDto.ClientId,
                ProductId = productClientDto.ProductId,
                PurchaseValue = productClientDto.PurchaseValue,
                PurchaseDate = productClientDto.PurchaseDate
            };

            var response = await _productClientRepository.Add(productClient);
            return response;
        }

        public async Task<int> Delete(int id)
        {
            var response = await _productClientRepository.Delete(id);
            return response;
        }

        public async Task<List<ProductClient>> GetAll()
        {
            var response = await _productClientRepository.GetAll();
            return response;
        }

        public async Task<ProductClient> GetById(int id)
        {
            var response = await _productClientRepository.GetById(id);
            return response;
        }

        public async Task<ProductClient> Update(ProductClientDto productClientDto, int id)
        {
            var record = await _productClientRepository.GetById(id);
            if (record is not null)
            {
                record.ProductId = productClientDto.ProductId;
                record.ClientId = productClientDto.ClientId;
                record.PurchaseDate = productClientDto.PurchaseDate;
                record.PurchaseValue = productClientDto.PurchaseValue;

                var response = await _productClientRepository.Update(record);
                return response;
            }
            return record;
        }
    }
}
