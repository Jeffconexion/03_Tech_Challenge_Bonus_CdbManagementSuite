using CdbBffSolution.Application.IServices;
using CdbBffSolution.Application.Services;
using CdbBffSolution.Domain.IRepository;
using CdbBffSolution.Infrastructure.ExternalServices;
using CdbBffSolution.Infrastructure.Repository;
using Refit;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

const string EXTERNAL_BASE_URL = "https://localhost:7293/api";

builder
    .Services
    .AddRefitClient<IExternalProductServicesApiClient>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri(EXTERNAL_BASE_URL));

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var stringConexao = configuration.GetValue<string>("ConnectionStringSQL");

builder.Services.AddTransient<IDbConnection>((conexao) => new SqlConnection(stringConexao));
builder.Services.AddTransient<IProductCustomerServices, ProductCustomerServices>();
builder.Services.AddTransient<IProductCustomerRepository, ProductCustomerRepository>();
builder.Services.AddTransient<IExternalProductServices, ExternalProductServices>();
builder.Services.AddTransient<IExternalCustomerServices, ExternalCustomerServices>();

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
