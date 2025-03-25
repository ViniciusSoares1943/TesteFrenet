using FrenetOrder.Data;
using FrenetOrder.Repository;
using FrenetOrder.Repository.Interface;
using FrenetOrder.Service;
using FrenetOrder.Service.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NLog.Config;
using NLog.Targets;
using NLog;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using NLog.Web;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;
using NLog.Extensions.Logging;


var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IShippingService, ShippingService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddSingleton<IJwtService, JwtService>();

builder.Services.AddDbContext<DbContextClass>();

LogManager.Setup().LoadConfigurationFromFile("nlog.config");

builder.Logging.ClearProviders();
builder.Logging.AddNLog();

builder.Logging.AddFilter("FrenetOrder", LogLevel.Information);

var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"] ?? throw new Exception("Erro interno ao iniciar aplicação, configurações de autenticação não informadas"));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["Jwt:Issuer"],
            ValidAudience = configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Teste técnico Frenet",
        Version = "v1",
        Description = "API para gerenciamento de pedidos de logística",
        Contact = new OpenApiContact
        {
            Name = "Vinicius Correia Soares",
            Email = "vinicius.soares.01@hotmail.com"
        }
    });

    // Caminho para o arquivo XML da documentação
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);

    // Configuração para Autenticação JWT no Swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insira seu token JWT"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Teste técnico Frenet");
        options.RoutePrefix = string.Empty;
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();