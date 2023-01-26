using Backend.Context;
using Backend.Implementation.Repository;
using Backend.Implementation.Services;
using Backend.Interface.Repositories;
using Backend.Interface.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
  
builder.Services.AddControllers();
builder.Services.AddScoped<IDesignService, DesignService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string connectionstring =  builder.Configuration.GetConnectionString("UncleTeeConnection");
builder.Services.AddDbContext<ApplicationContext>(x => x.UseMySql(connectionstring, ServerVersion.AutoDetect(connectionstring)));
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
