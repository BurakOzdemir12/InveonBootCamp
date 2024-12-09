using BestPractises.Models;

namespace BestPractises.Interfaces
{
    public interface ILibraryRepository
    {
        List<Book> GetBooks();
        List<Article> GetArticles();
    }
}
