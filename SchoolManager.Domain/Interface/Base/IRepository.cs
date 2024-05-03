namespace SchoolManager.Domain.Interface.Base
{
    public interface IRepository<T> where T : class
    {
        Task<int> Insert(T entity);
        Task<bool> Update(T entity);
        Task<IEnumerable<T>> GetAll();
    }
}
