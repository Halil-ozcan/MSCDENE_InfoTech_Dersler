using System;
using ECommerceApp.Backend.Data.Abstract;
using ECommerceApp.Backend.Data.Concrete.Context;
using ECommerceApp.Backend.Entities.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceApp.Backend.Data.Concrete;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _appDbContext;
    private readonly IServiceProvider _serviceProvider;
    public UnitOfWork(AppDbContext appDbContext, IServiceProvider serviceProvider)
    {
        _appDbContext = appDbContext;
        _serviceProvider = serviceProvider;
    }

    public void Dispose()
    {
       _appDbContext.Dispose();
    }

    public int Save()
    {
        return _appDbContext.SaveChanges();
    }

    public async Task<int> SaveAsync()
    {
       return await _appDbContext.SaveChangesAsync();
    }

    public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity:class, IEntity
    {
       var repository = _serviceProvider.GetRequiredService<IGenericRepository<TEntity>>();
       return repository;
    }
}
