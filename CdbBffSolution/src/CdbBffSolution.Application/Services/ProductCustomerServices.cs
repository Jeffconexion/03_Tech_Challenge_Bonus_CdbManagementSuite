﻿using CdbBffSolution.Application.Dtos;
using CdbBffSolution.Application.IServices;
using CdbBffSolution.Domain.Entities;
using CdbBffSolution.Domain.IRepository;

namespace CdbBffSolution.Application.Services
{
    // Este serviço (`ProductCustomerServices`) realiza chamadas HTTP para obter dados de produtos e clientes
    // utilizando a biblioteca Refit. O Refit simplifica a criação de clientes HTTP ao gerar implementações baseadas
    // em interfaces, permitindo que escrevamos chamadas de API como métodos de interface.
    //
    // No `ProductCustomerServices`, injetamos essa interface e utilizamos seus métodos para fazer as requisições.
    // Isso facilita a manutenção e organização do código, garantindo uma separação clara das responsabilidades.
    public class ProductCustomerServices : IProductCustomerServices
    {
        private readonly IProductCustomerRepository _productCustomerRepository;

        public ProductCustomerServices(IProductCustomerRepository productCustomerRepository)
        {
            _productCustomerRepository = productCustomerRepository;
        }

        public async Task<ProductCustomer> Add(ProductCustomerDto productCustomerDto)
        {
            var productCustomer = new ProductCustomer
            {
                Customer = new Customer { Id = productCustomerDto.Customer.Id },
                PurchaseValue = productCustomerDto.PurchaseValue,
                PurchaseDate = productCustomerDto.PurchaseDate.Date,
                Product = new ProductEntity { Id = productCustomerDto.Product.Id }
            };

            var response = await _productCustomerRepository.Add(productCustomer);
            return response;
        }

        public async Task<int> Delete(int id)
        {
            var response = await _productCustomerRepository.Delete(id);
            return response;
        }

        public async Task<List<ProductCustomer>> GetAll()
        {
            var response = await _productCustomerRepository.GetAll();
            return response;
        }

        public async Task<ProductCustomer> GetById(int id)
        {
            var response = await _productCustomerRepository.GetById(id);
            return response;
        }

        public async Task<ProductCustomer> Update(ProductCustomerDto productCustomerDto, int id)
        {
            var record = await _productCustomerRepository.GetById(id);
            if (record is not null)
            {

                record.PurchaseDate = productCustomerDto.PurchaseDate;
                record.PurchaseValue = productCustomerDto.PurchaseValue;

                var response = await _productCustomerRepository.Update(record);
                return response;
            }
            return record;
        }
    }
}
