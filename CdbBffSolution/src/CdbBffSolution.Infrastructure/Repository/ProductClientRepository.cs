using CdbBffSolution.Domain.Entities;
using CdbBffSolution.Domain.IRepository;
using Dapper;
using System.Data;

namespace CdbBffSolution.Infrastructure.Repository
{
    public class ProductClientRepository : IProductClientRepository
    {
        private readonly IDbConnection _dbConnection;

        public ProductClientRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<ProductClient> Add(ProductClient productClient)
        {
            var comandoSql = @"INSERT INTO ProductClient (ProductId, ClientId, PurchaseDate, PurchaseValue)
                               VALUES
                               (@ProductId, @ClientId, @PurchaseDate, @PurchaseValue)";


            var parameters = new
            {
                ProductId = productClient.Product.Id,
                ClientId = productClient.Client.Id,
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

        public async Task<List<ProductClient>> GetAll()
        {
            var comandoSql = @"SELECT pc.Id, pc.ProductId, p.Name, p.Description, p.Value, p.ExpirationDate, p.InterestRate, p.IsActive,
                              pc.ClientId, c.FirstName, c.LastName, c.Email, c.BirthDate, c.IsActive AS ClientIsActive,
                              pc.PurchaseDate, pc.PurchaseValue
                       FROM ProductClient pc
                       JOIN Product p ON pc.ProductId = p.Id
                       JOIN Client c ON pc.ClientId = c.Id";

            var productClients = await _dbConnection.QueryAsync<ProductClient, Product, Client, ProductClient>(
                comandoSql,
                (productClient, product, client) =>
                {
                    productClient.Product = product;
                    productClient.Client = client;
                    return productClient;
                },
                splitOn: "ProductId,ClientId"
            );

            return productClients.ToList();
        }

        public async Task<ProductClient> GetById(int id)
        {
            var comandoSql = @"SELECT pc.Id, pc.ProductId, p.Name, p.Description, p.Value, p.ExpirationDate, p.InterestRate, p.IsActive,
                              pc.ClientId, c.FirstName, c.LastName, c.Email, c.BirthDate, c.IsActive AS ClientIsActive,
                              pc.PurchaseDate, pc.PurchaseValue
                       FROM ProductClient pc
                       JOIN Product p ON pc.ProductId = p.Id
                       JOIN Client c ON pc.ClientId = c.Id
                       WHERE pc.Id = @Id";

            var response = await _dbConnection.QueryAsync<ProductClient, Product, Client, ProductClient>(
                comandoSql,
                (productClient, product, client) =>
                {
                    productClient.Product = product;
                    productClient.Client = client;
                    return productClient;
                },
                new { Id = id },
                splitOn: "ProductId,ClientId"
            );

            return response.SingleOrDefault();
        }

        public async Task<ProductClient> Update(ProductClient productClient)
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
