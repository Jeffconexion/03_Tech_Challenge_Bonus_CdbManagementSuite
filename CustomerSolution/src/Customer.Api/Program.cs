using Customer.Application.IServices;
using Customer.Application.Services;
using Customer.Domain.IRepositories;
using Customer.Infrastructure.Repositories;
using System.Data;
using System.Data.SqlClient;


var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//** Aqui fica a injeção da coniguração do nosso BD **//
var stringConexao = configuration.GetValue<string>("ConnectionStringSQL");

builder.Services.AddTransient<IDbConnection>((conexao) => new SqlConnection(stringConexao));
builder.Services.AddTransient<ICustomerServices, CustomerServices>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
