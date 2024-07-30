using Product.Application.Dtos;
using Product.Application.IServices;
using Product.Domain.Entities;
using Product.Domain.IRepository;

namespace Product.Application.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepository;

        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductEntity> Add(ProductDto productDto)
        {
            var product = new ProductEntity
            {
                Name = productDto.Name,
                CreationDate = DateTime.Now,
                Description = productDto.Description,
                ExpirationDate = productDto.ExpirationDate,
                InterestRate = productDto.InterestRate,
                IsActive = productDto.IsActive,
                Value = productDto.Value
            };

            var response = await _productRepository.Add(product);
            return response;
        }

        public async Task<int> Delete(int id)
        {
            var response = await _productRepository.Delete(id);
            return response;
        }

        public async Task<List<ProductEntity>> GetAll()
        {
            var response = await _productRepository.GetAll();
            return response;
        }

        public async Task<ProductEntity> GetById(int id)
        {
            var response = await _productRepository.GetById(id);
            return response;
        }

        public async Task<ProductEntity> Update(ProductDto productDto, int id)
        {
            var record = await _productRepository.GetById(id);
            if (record is not null)
            {
                record.Name = productDto.Name;
                record.ExpirationDate = productDto.ExpirationDate;
                record.InterestRate = productDto.InterestRate;
                record.IsActive = productDto.IsActive;
                record.Value = productDto.Value;

                var response = await _productRepository.Update(record);
                return response;
            }
            return record;
        }
    }
}
