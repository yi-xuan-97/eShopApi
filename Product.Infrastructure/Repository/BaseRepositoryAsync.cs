using System.Linq.Expressions;
using eShop.ApplicationCore.Interface.Repository;
using eShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace eShop.Infrastructure.Repository;

public class BaseRepositoryAsync<T>:IRepositoryAsync<T> where T: class
{
    private readonly eShopDbContext _context;

    public BaseRepositoryAsync(eShopDbContext dbContext)
    {
        _context = dbContext;
    }

    public async Task<int> DeleteAsync(int id)
    {

        var entity = await GetByIdAsync(id);
        _context.Remove(entity);
        return await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> Filter(Expression<Func<T, bool>> filter)
    {
        return await _context.Set<T>().Where(filter).ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        var result = await _context.Set<T>().FindAsync(id);
        return result;
    }

    public Task<int> InsertAsync(T entity)
    {
        _context.Set<T>().AddAsync(entity);
        return _context.SaveChangesAsync();
        //Task<int> != int
    }

    public Task<int> UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        return _context.SaveChangesAsync();
    }
}