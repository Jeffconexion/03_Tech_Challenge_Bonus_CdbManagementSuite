using Dapper;
using Product.Domain.Entities;
using Product.Domain.IRepository;
using System.Data;

namespace Product.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _dbConnection;

        public ProductRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<ProductEntity> Add(ProductEntity product)
        {
            var comandoSql = @"INSERT INTO Product (Name, Description, Value, CreationDate, ExpirationDate, InterestRate, IsActive)
                  VALUES
                  (@Name, @Description, @Value, @CreationDate, @ExpirationDate, @InterestRate, @IsActive)";


            await _dbConnection.ExecuteAsync(comandoSql, product);
            return product;
        }

        public async Task<int> Delete(int id)
        {
            var comandoSql = @"DELETE FROM Product WHERE id = @id";

            await _dbConnection.ExecuteAsync(comandoSql, new { id = id });
            return id;
        }

        public async Task<List<ProductEntity>> GetAll()
        {
            var comandoSql = @"SELECT * FROM Product";
            return _dbConnection.QueryAsync<ProductEntity>(comandoSql).Result.ToList();
        }

        public async Task<ProductEntity> GetById(int id)
        {
            var comandoSql = @"SELECT * FROM Product WHERE id = @id";
            var response = await _dbConnection.QueryAsync<ProductEntity>(comandoSql, new { id = id });
            return response.SingleOrDefault();
        }

        public async Task<ProductEntity> Update(ProductEntity product)
        {
            var comandoSql = @"UPDATE Product
                                            SET Name = @Name,
                                                Description = @Description,
                                                Value = @Value,
                                                CreationDate = @CreationDate,
                                                ExpirationDate = @ExpirationDate,
                                                InterestRate = @InterestRate,
                                                IsActive = @IsActive
                                            WHERE Id = @Id";


            await _dbConnection.ExecuteAsync(comandoSql, product);
            return product;
        }
    }
}
