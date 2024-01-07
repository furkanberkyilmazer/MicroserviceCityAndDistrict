using DistrictService.Bussines.Abstract;
using DistrictService.Bussines.Concrete;
using DistrictService.DataAccess.Abstract;
using DistrictService.DataAccess.Context;
using DistrictService.DataAccess.EntityFramework;
using DistrictService.DataAccess.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DistrictDbContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
builder.Services.AddScoped<IDistrictService, DistrictOfService>();
builder.Services.AddScoped(typeof(IGenericDal<>), typeof(GenericDal<>));
builder.Services.AddScoped<IDistrictDal, EfDistrictDal>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
