namespace Movies.contract
{
    public interface IGenericRespository<T> where T: class
    {
        Task<T> GetAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T Entity);
        Task UpdateAsync(T Entity);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);

    }
}
