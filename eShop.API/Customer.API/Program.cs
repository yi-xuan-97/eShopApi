using Customer.ApplicationCore.RepositoryInterface;
using Customer.Infrustructure.Data;
using Customer.Infrustructure.Repository;
using JWTAuth;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICustomerRepositoryAsync, CustomerRepositoryAsync>();
builder.Services.AddDbContext<eShopDbContext>(
    option =>
    {
        option.UseSqlServer(builder.Configuration.GetConnectionString("eShopDbConnection"));
    }
);
builder.Services.AddCustomJwtAuthentication();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();