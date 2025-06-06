using System;
using System.Linq.Expressions;
using ECommerceApp.Backend.Entities.Abstract;

namespace ECommerceApp.Backend.Data.Abstract;

public interface IGenericRepository<TEntity> where TEntity:class, IEntity
{
    Task<TEntity> GetAsync(int id); // asenkron bir metot tanımlayacaksak task içinde yazmalıyız. ve Async diyerek de sonuna yazarız.
    Task<TEntity> GetAsync(
        Expression<Func<TEntity,bool>> predicate,
        bool includeDeleted=false,
        params Func<IQueryable<TEntity>,IQueryable<TEntity>>[] includes
    );
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<IEnumerable<TEntity>> GetAllAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>,IOrderedQueryable<TEntity>>? orderBy = null,
        bool includeDeleted = false,
        params Func<IQueryable<TEntity>, IQueryable<TEntity>>[] includes
    );
    Task<bool> ExistsAsync(
        Expression<Func<TEntity, bool>> predicate
    );
    Task<int> CountAsync();
    Task<int> CountAsync(
        Expression<Func<TEntity, bool>>? predicate=null,
        bool includeDeleted = false,
        params Func<IQueryable<TEntity>, IQueryable<TEntity>>[] includes
    );

    Task<TEntity> AddAsync(TEntity entity);
    void Update(TEntity entity);
    void BatchUpdate(IEnumerable<TEntity> entities);
    void Delete(TEntity entity);

}

