using AutoMapper;
using ECommerceApp.Backend.Business.Abstract;
using ECommerceApp.Backend.Business.Concrete;
using ECommerceApp.Backend.Business.Mappings;
using ECommerceApp.Backend.Data.Abstract;
using ECommerceApp.Backend.Data.Concrete;
using ECommerceApp.Backend.Data.Concrete.Context;
using ECommerceApp.Backend.Data.Concrete.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext'imizi containere ekliyoruz.
builder.Services.AddDbContext<AppDbContext>(options=>{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

// Servislerimizi Ekliyoruz
builder.Services.AddScoped<ICategoryService, CategoryService>();

// Repository'lerimizi ekliyoruz.
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));

//AutoMapper
builder.Services.AddAutoMapper(typeof(Profile));

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
