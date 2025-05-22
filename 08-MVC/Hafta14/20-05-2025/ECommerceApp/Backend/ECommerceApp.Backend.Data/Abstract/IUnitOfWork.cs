using System;
using ECommerceApp.Backend.Entities.Abstract;

namespace ECommerceApp.Backend.Data.Abstract;

public interface IUnitOfWork:IDisposable
{
    IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity:class, IEntity;
    int Save();
    Task<int> SaveAsync();

}
