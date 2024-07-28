using Customer.Domain.Entities;
using Customer.Domain.IRepositories;
using Dapper;
using System.Data;

namespace Customer.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbConnection _dbConnection;

        public CustomerRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Client> Add(Client client)
        {
            var comandoSql = @"INSERT INTO Client (FirstName, LastName, Email, BirthDate, CreationDate, IsActive)
                              VALUES
                              (@FirstName,@LastName,@Email,@BirthDate,@CreationDate,@IsActive)";

            await _dbConnection.ExecuteAsync(comandoSql, client);
            return client;
        }

        public async Task<int> Delete(int id)
        {
            var comandoSql = @"DELETE FROM Client WHERE id = @id";

            await _dbConnection.ExecuteAsync(comandoSql, new { id = id });
            return id;
        }

        public async Task<List<Client>> GetAll()
        {
            var comandoSql = @"SELECT * FROM Client";
            return _dbConnection.QueryAsync<Client>(comandoSql).Result.ToList();
        }

        public async Task<Client> GetById(int id)
        {
            var comandoSql = @"SELECT * FROM Client WHERE id = @id";
            var response = await _dbConnection.QueryAsync<Client>(comandoSql, new { id = id });
            return response.SingleOrDefault();
        }

        public async Task<Client> Update(Client client)
        {
            var comandoSql = @"UPDATE Client
                   SET FirstName = @FirstName,
                       LastName = @LastName,
                       Email = @Email,
                       BirthDate = @BirthDate,
                       IsActive = @IsActive
                       WHERE Id = @Id";

             await _dbConnection.ExecuteAsync(comandoSql, client);
            return client;
        }
    }
}
