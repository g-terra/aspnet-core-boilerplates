using Microsoft.EntityFrameworkCore;

namespace aspnet_core_boilerplate_code_first.Repositories;

public partial class GenericRepository<TEntity, TContext>
{
    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<TEntity>
        InsertAsync(TEntity entity)
    {
        var entityEntry = await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);

        if (entity != null)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}