using System;
using System.Linq.Expressions;
using ECommerceApp.Backend.Data.Abstract;
using ECommerceApp.Backend.Data.Concrete.Context;
using ECommerceApp.Backend.Entities.Abstract;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Backend.Data.Concrete.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
{
    private readonly AppDbContext _appDbContext;
    private readonly DbSet<TEntity> _dbSet;

    public GenericRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
        _dbSet = _appDbContext.Set<TEntity>();
    }

    public  async Task<TEntity> AddAsync(TEntity entity) 
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public void BatchUpdate(IEnumerable<TEntity> entities)
    {
        _dbSet.UpdateRange(entities);
    }

    public async Task<int> CountAsync()
    {
       return await _dbSet.CountAsync();
    }

    public async Task<int> CountAsync(
        Expression<Func<TEntity, bool>>? predicate=null, 
        bool includeDeleted = false, 
        params Func<IQueryable<TEntity>, IQueryable<TEntity>>[] includes)
    {
        IQueryable<TEntity> query = _dbSet;
        if(includeDeleted)
        {
            query = query.IgnoreQueryFilters();
        }
        if(predicate is not null)
        {
            query = query.Where(predicate);
        }
        if(includes is not null)
        {
            query = includes.Aggregate(query,(current,include)=> include(current));
        }
        var result = await query.CountAsync();
        return result;
    }

    public void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
    {
       return await _dbSet.AnyAsync(predicate);

    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(
        Expression<Func<TEntity, bool>>? predicate = null, 
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, 
        bool includeDeleted = false, 
        params Func<IQueryable<TEntity>, 
        IQueryable<TEntity>>[] includes)
    {
        IQueryable<TEntity> query = _dbSet;
        if(includeDeleted)
        {
            query = query.IgnoreQueryFilters();
        }
        if(predicate is not null)
        {
            query = query.Where(predicate);
        }
        if(orderBy is not null)
        {
            query = orderBy(query);
        }
        if(includes is not null)
        {
            query = includes.Aggregate(query, (current,include)=> include(current));
        }
        return await query.ToListAsync();
    }

    public async Task<TEntity> GetAsync(int id)
    {
       var result = await _dbSet.FindAsync(id);
       return result!;
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, bool includeDeleted = false, params Func<IQueryable<TEntity>, IQueryable<TEntity>>[] includes)
    {
        IQueryable<TEntity> query = _dbSet;
        if (includeDeleted)
        {
            query = query.IgnoreQueryFilters();
        }
        if (predicate is not null)
        {
            query = query.Where(predicate);
        }
        if (includes is not null)
        {
            query = includes.Aggregate(query, (current, include) => include(current));
        }
        var result =  await query.FirstOrDefaultAsync();
        return result!;
    }

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }
}
