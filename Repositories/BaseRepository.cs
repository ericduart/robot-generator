using Microsoft.EntityFrameworkCore;
using robot_generator.Repositories.Interfaces;

namespace robot_generator.Repositories;

public abstract class BaseRepository<TContext, TModel> : IBaseRepository<TModel>, IDisposable
    where TContext : DbContext, new()
{
    
    protected readonly TContext Context;

    public BaseRepository()
    {
        Context = new TContext();
    }
    
    public abstract TModel GetById(string id);

    public abstract IEnumerable<TModel> GetAll();

    public abstract void Add(TModel entity);

    public abstract void Update(TModel entity);

    public abstract void Delete(TModel entity);

    public virtual void SaveChanges()
    {
        Context.SaveChanges();
    }

    public virtual void Migrate()
    {
        Context.Database.Migrate();
    }

    public void Dispose()
    {
        Context.Dispose();
    }
}