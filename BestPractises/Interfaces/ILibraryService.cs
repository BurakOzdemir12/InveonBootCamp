using BestPractises.Models;
using BestPractises.Results;

namespace BestPractises.Interfaces
{
    public interface ILibraryService
    {
        PagedResult<Book> GetBooks(int pageNum, int pageSize);
        List<Book> GetBooks();
        List<Article> GetArticles();

    }
}
