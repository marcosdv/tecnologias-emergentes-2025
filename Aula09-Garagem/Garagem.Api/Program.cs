using Garagem.Application.Repositories;
using Garagem.Application.Services;
using Garagem.Application.Services.Interfaces;
using Garagem.Repository.Contexts;
using Garagem.Repository.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//DI - Injecao de Dependencias - INICIO

builder.Services.AddDbContext<DataContext>(
    opt => opt.UseInMemoryDatabase("banco_dados")
);

builder.Services.AddScoped<IModeloRepository, ModeloRepository>();
builder.Services.AddScoped<IVeiculoRepository, VeiculoRepository>();

builder.Services.AddScoped<IModeloService, ModeloService>();

//DI - Injecao de Dependencias - FIM

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
