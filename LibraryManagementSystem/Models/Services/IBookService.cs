namespace LibraryManagementSystem.Models.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetBooksAsync();
        Task <Book> GetBookByIdAsync(int id);
        Task AddBookAsync(Book book);
        Task DeleteBookAsync(int id);
        Task UpdateBookAsync(Book book);
    }
}
