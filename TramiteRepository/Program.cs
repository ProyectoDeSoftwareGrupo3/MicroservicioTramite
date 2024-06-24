using Application.Interfaces.IEmail;
using Application.Interfaces.IMappers;
using Application.Interfaces.ITramite;
using Application.Interfaces.ITramiteEstado;
using Application.Interfaces.ITramiteTipo;
using Application.Interfaces.Services;
using Application.Mappers;
using Application.UseCases;
using Infrastructure.Command;
using Infrastructure.Persistence;
using Infrastructure.Query;
using Infrastructure.Services;
using Infrastructure.Services.Http;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JwtOptions:Issuer"],
            ValidAudience = builder.Configuration["JwtOptions:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtOptions:SigningKey"]))
        };
    });

builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Microservicio Tramite",
        Description = "Tramites Animales"
    });

    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header
    });

    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
           }, Array.Empty<string>()
       }
    });
});

builder.Services.AddHttpClient<AnimalApiClient>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7055/"); // URL base de la API externa
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddHttpClient<UserApiClient>(client =>
{
    client.BaseAddress = new Uri("https://localhost:44350/"); // URL base de la API externa
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});


var connectionString = builder.Configuration["ConnectionString"];
builder.Services.AddDbContext<TramiteDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddHttpContextAccessor();
//Estados de los Tramites
builder.Services.AddScoped<ITramiteEstadoQuery, TramiteEstadoQuery>();
builder.Services.AddScoped<ITramiteEstadoService, TramiteEstadoService>();

//Tipos de Tramites
builder.Services.AddScoped<ITramiteTipoQuery, TramiteTipoQuery>();


builder.Services.AddScoped<ITramiteQuery, TramiteQuery>();
builder.Services.AddScoped<ITramiteCommand, TramiteCommand>();
builder.Services.AddScoped<ITramiteService, TramiteService>();


builder.Services.AddScoped<ITramiteTipoMapper, TramiteTipoMapper>();
builder.Services.AddScoped<ITramiteEstadoMapper, TramiteEstadoMapper>();
builder.Services.AddScoped<ITramiteMapper, TramiteMapper>();

builder.Services.AddScoped<IAnimalService, AnimalService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IEmailService, EmailService>();

//builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(policy =>
{
    policy.AllowAnyOrigin();
    policy.AllowAnyMethod();
    policy.AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
