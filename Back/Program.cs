using Back.Bussiness.Interfaces;
using Back.Bussiness.Repository;
using Back.Bussiness.Services;
using Back.Comun.Encrypt;
using Back.Data.Repository;
using DataAccess.Contexto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Dev");

builder.Services.AddDbContext<ContextoDB>(options => options.UseSqlServer(connectionString));
builder.Services.AddSingleton<Token>();
var key = Encoding.UTF8.GetBytes("kfklerflkejrgkljelktjgklrelkjllolololo");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = false,
            ValidIssuer = "yourdomain.com",
            ValidAudience = "yourdomain.com",
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "API con JWT", Version = "v1" });

    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Ingrese el token JWT en este formato: Bearer {token}",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    };

    options.AddSecurityDefinition("Bearer", securityScheme);

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            securityScheme,
            new string[] {}
        }
    });
});
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IItemRepository, ItemRepository>();
builder.Services.AddTransient<IItemService, ItemService>();
builder.Services.AddTransient<IStoreRepository, StoreRepository>();
builder.Services.AddTransient<IStoreService, StoreService>();
builder.Services.AddTransient<ICartRepository, CartRepository>();
builder.Services.AddTransient<ICartService, CartService>();
builder.Services.AddTransient<IItemStoreRepository, ItemStoreRepository>();
builder.Services.AddTransient<IItemStoreService, ItemStoreService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
