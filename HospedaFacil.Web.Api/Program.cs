var builder = WebApplication.CreateBuilder(args);

// Configura��o de servi�os
builder.Services.AddMvc();

// Registra Settings usando IOptions para o DI
builder.Services.Configure<Settings>(builder.Configuration.GetSection("MongoConnection"));

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
