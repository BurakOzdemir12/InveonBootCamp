using BestPractises.Interfaces;
using BestPractises.Models;
using BestPractises.Results;
using Microsoft.AspNetCore.Mvc;

namespace BestPractises.Services
{
    public class LibraryServices : ILibraryService
    {
        ILibraryRepository _libraryRepository;
        public LibraryServices(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }
        public List<Book> GetBooks()
        {
            var bookList = _libraryRepository.GetBooks();
            return bookList;
        }
        public List<Article> GetArticles()
        {
            var articleList = _libraryRepository.GetArticles();
            return articleList;
        }
        public ServiceResult Create()
        {
            return new ServiceResult();

            return new ServiceResult()
            {
                ProblemDetails = new ProblemDetails()
                {
                    Status = 404
                }
            };
        }

        public PagedResult<Book> GetBooks(int pageNum, int pageSize)
        {
            var allBooks = _libraryRepository.GetBooks();
            var totalItems = allBooks.Count;
            var books = allBooks
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            return new PagedResult<Book>
            {
                Items = books,
                TotalItems = totalItems,
                PageNumber = pageNum,
                PageSize = pageSize
            };
        }



    }
}
