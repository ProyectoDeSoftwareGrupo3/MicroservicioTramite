using Application.Interfaces;
using Application.UseCases;
using Infrastructure.Persistence;
using Infrastructure.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TramiteRepository.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TramiteRepositoryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TramiteRepositoryContext") ?? throw new InvalidOperationException("Connection string 'TramiteRepositoryContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var connectionString = builder.Configuration["ConnectionString"];

builder.Services.AddDbContext<TramiteDbContext>(options => options.UseSqlServer(connectionString));

//Estados de los Tramites
builder.Services.AddScoped<ITramiteEstadoQuery, TramiteEstadoQuery>();
builder.Services.AddScoped<ITramiteEstadoService, TramiteEstadoService>();

//Tipos de Tramites
builder.Services.AddScoped<ITramiteTipoQuery, TramiteTipoQuery>();
builder.Services.AddScoped<ITramiteTipoService, TramiteTipoService>();

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
