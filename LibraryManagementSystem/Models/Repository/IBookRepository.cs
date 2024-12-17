namespace LibraryManagementSystem.Models.Repository
{
    public interface IBookRepository
    {
        Task<Book>GetByIdAsync(int id);
        Task<List<Book>> GetAllAsync();
        Task AddSync(Book book);
        Task UpdateAsync(Book book);
        Task DeleteAsync(int id);
    }
}
