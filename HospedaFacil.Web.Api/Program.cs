using HospedaFacil.Domain.Models;
using HospedaFacil.Insfraestructure.Data.MongoDB.Context;
using HospedaFacil.Insfraestructure.Data.MongoDB.Repository;
using HospedaFacil.Insfraestructure.Data.SQLServer.Context;
using HospedaFacil.Insfraestructure.Data.SQLServer.Repository;
using HospedaFacil.Insfraestructure.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuração de serviços
builder.Services.AddMvc();

// Registra Settings usando IOptions para o DI
builder.Services.Configure<MongoConnection>(builder.Configuration.GetSection("MongoConnection"));

// Constrói o settings manualmente e injeta como singleton
var mongoSettings = builder.Configuration.GetSection("MongoConnection").Get<MongoConnection>();
if (mongoSettings is null)
{
    throw new InvalidOperationException("Configuração da instância MongoConnection é inválida.");
}
builder.Services.AddSingleton(mongoSettings);
builder.Services.AddSingleton<MongoDbContext>();
builder.Services.AddScoped<Hotel>();

// Ajuste no SQL Server - adiciona DbContext e registra repositório
builder.Services.AddDbContext<SqlServerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection")));

builder.Services.AddScoped<IHospedaFacilWriteRepository, HospedaFacilWriteRepository>();  // Registra seu repositório SQL
builder.Services.AddScoped<IHospedaFacilReadRepository, HospedaFacilReadRepository>(); // Registra seu repositório MongoDB


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
