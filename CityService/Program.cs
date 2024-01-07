using CityService.Bussines.Abstract;
using CityService.Bussines.Concrete;
using CityService.DataAccess.Abstract;
using CityService.DataAccess.Context;
using CityService.DataAccess.EntityFramework;
using CityService.DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<CityDbContext>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
builder.Services.AddScoped<ICityService, CityOfService>();
builder.Services.AddScoped(typeof(IGenericDal<>), typeof(GenericDal<>));
builder.Services.AddScoped<ICityDal, EfCityDal>();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

///
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
