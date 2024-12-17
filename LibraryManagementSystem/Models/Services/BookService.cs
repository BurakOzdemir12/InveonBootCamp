﻿
using LibraryManagementSystem.Models.Repository;

namespace LibraryManagementSystem.Models.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository=  bookRepository;
        }
        public async Task AddBookAsync(Book book)
        {
            await _bookRepository.AddSync(book);
        }

        public async Task DeleteBookAsync(int id)
        {
            await _bookRepository.DeleteAsync(id);
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
           return await _bookRepository.GetByIdAsync(id);
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            return await _bookRepository.GetAllAsync();
        }

        public async Task UpdateBookAsync(Book book)
        {
            await _bookRepository.UpdateAsync(book);
        }
    }
}