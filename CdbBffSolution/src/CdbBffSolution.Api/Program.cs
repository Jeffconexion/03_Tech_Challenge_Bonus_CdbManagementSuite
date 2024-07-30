using CdbBffSolution.Application.IServices;
using CdbBffSolution.Application.Services;
using CdbBffSolution.Domain.IRepository;
using CdbBffSolution.Infrastructure.Repository;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var stringConexao = configuration.GetValue<string>("ConnectionStringSQL");

builder.Services.AddTransient<IDbConnection>((conexao) => new SqlConnection(stringConexao));
builder.Services.AddTransient<IProductClientServices, ProductClientServices>();
builder.Services.AddTransient<IProductClientRepository, ProductClientRepository>();

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
