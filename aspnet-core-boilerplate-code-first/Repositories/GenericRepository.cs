using Microsoft.EntityFrameworkCore;

namespace aspnet_core_boilerplate_code_first.Repositories;

public partial class GenericRepository<TEntity, TContext> : IRepository<TEntity>
    where TEntity : class where TContext : DbContext

{
    private readonly TContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public GenericRepository(TContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _dbSet.ToList();
    }

    public TEntity? GetById(int id)
    {
        return _dbSet.Find(id);
    }

    public TEntity Insert(TEntity entity)
    {
        var entityEntry = _dbSet.Add(entity);
        _context.SaveChanges();
        return entityEntry.Entity;
    }

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
        _context.SaveChanges();
    }

    public void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var entity = _dbSet.Find(id);

        if (entity == null) return;
        _dbSet.Remove(entity);
        _context.SaveChanges();
    }
}