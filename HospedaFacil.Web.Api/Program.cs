using HospedaFacil.Domain.Models;
using HospedaFacil.Insfraestructure.Data.MongoDB.Context;
using HospedaFacil.Insfraestructure.Data.MongoDB.Repository;
using HospedaFacil.Insfraestructure.Data.SQLServer.Context;
using HospedaFacil.Insfraestructure.Data.SQLServer.Repository;
using HospedaFacil.Insfraestructure.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configura��o de servi�os
builder.Services.AddMvc();

// Registra Settings usando IOptions para o DI
builder.Services.Configure<MongoConnection>(builder.Configuration.GetSection("MongoConnection"));

// Constr�i o settings manualmente e injeta como singleton
var mongoSettings = builder.Configuration.GetSection("MongoConnection").Get<MongoConnection>();
if (mongoSettings is null)
{
    throw new InvalidOperationException("Configura��o da inst�ncia MongoConnection � inv�lida.");
}
builder.Services.AddSingleton(mongoSettings);
builder.Services.AddSingleton<MongoDbContext>();
builder.Services.AddScoped<Hotel>();

// Ajuste no SQL Server - adiciona DbContext e registra reposit�rio
builder.Services.AddDbContext<SqlServerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection")));

builder.Services.AddScoped<IHospedaFacilWriteRepository, HospedaFacilWriteRepository>();  // Registra seu reposit�rio SQL
builder.Services.AddScoped<IHospedaFacilReadRepository, HospedaFacilReadRepository>(); // Registra seu reposit�rio MongoDB


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
