using CdbBffSolution.Domain.Entities;
using CdbBffSolution.Domain.IRepository;
using Dapper;
using System.Data;

namespace CdbBffSolution.Infrastructure.Repository
{
    public class ProductCustomerRepository : IProductCustomerRepository
    {
        private readonly IDbConnection _dbConnection;

        public ProductCustomerRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<ProductCustomer> Add(ProductCustomer productClient)
        {
            var comandoSql = @"INSERT INTO ProductClient (ProductId, ClientId, PurchaseDate, PurchaseValue)
                               VALUES
                               (@ProductId, @ClientId, @PurchaseDate, @PurchaseValue)";


            var parameters = new
            {
                ProductId = productClient.Product.Id,
                ClientId = productClient.Customer.Id,
                PurchaseDate = productClient.PurchaseDate,
                PurchaseValue = productClient.PurchaseValue
            };


            await _dbConnection.ExecuteAsync(comandoSql, parameters);
            return productClient;
        }

        public async Task<int> Delete(int id)
        {
            var comandoSql = @"DELETE FROM ProductClient WHERE Id = @Id";

            await _dbConnection.ExecuteAsync(comandoSql, new { id = id });
            return id;
        }

        public async Task<List<ProductCustomer>> GetAll()
        {
            var comandoSql = @"SELECT pc.Id, pc.ProductId, p.Name, p.Description, p.Value, p.ExpirationDate, p.InterestRate, p.IsActive,
                              pc.ClientId, c.FirstName, c.LastName, c.Email, c.BirthDate, c.IsActive AS ClientIsActive,
                              pc.PurchaseDate, pc.PurchaseValue
                       FROM ProductClient pc
                       JOIN Product p ON pc.ProductId = p.Id
                       JOIN Client c ON pc.ClientId = c.Id";

            var productClients = await _dbConnection.QueryAsync<ProductCustomer, ProductEntity, Customer, ProductCustomer>(
                comandoSql,
                (productClient, product, client) =>
                {
                    productClient.Product = product;
                    productClient.Customer = client;
                    return productClient;
                },
                splitOn: "ProductId,ClientId"
            );

            return productClients.ToList();
        }

        public async Task<ProductCustomer> GetById(int id)
        {
            var comandoSql = @"SELECT pc.Id, pc.ProductId, p.Name, p.Description, p.Value, p.ExpirationDate, p.InterestRate, p.IsActive,
                              pc.ClientId, c.FirstName, c.LastName, c.Email, c.BirthDate, c.IsActive AS ClientIsActive,
                              pc.PurchaseDate, pc.PurchaseValue
                       FROM ProductClient pc
                       JOIN Product p ON pc.ProductId = p.Id
                       JOIN Client c ON pc.ClientId = c.Id
                       WHERE pc.Id = @Id";

            var response = await _dbConnection.QueryAsync<ProductCustomer, ProductEntity, Customer, ProductCustomer>(
                comandoSql,
                (productClient, product, client) =>
                {
                    productClient.Product = product;
                    productClient.Customer = client;
                    return productClient;
                },
                new { Id = id },
                splitOn: "ProductId,ClientId"
            );

            return response.SingleOrDefault();
        }

        public async Task<ProductCustomer> Update(ProductCustomer productClient)
        {
            var comandoSql = @"UPDATE ProductClient
                   SET ProductId = @ProductId,
                       ClientId = @ClientId,
                       PurchaseDate = @PurchaseDate,
                       PurchaseValue = @PurchaseValue
                   WHERE Id = @Id";

            await _dbConnection.ExecuteAsync(comandoSql, productClient);
            return productClient;
        }
    }
}
