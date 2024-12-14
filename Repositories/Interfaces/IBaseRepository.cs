namespace robot_generator.Repositories.Interfaces;

public interface IBaseRepository<T>
{
    public T GetById(string id);
    public IEnumerable<T> GetAll();
    public void Add(T entity);
    public void Update(T entity);
    public void Delete(T entity);
    
}