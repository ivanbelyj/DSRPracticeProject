using DSRPracticeProject.Services.Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSRPracticeProject.Services.Books
{
    public interface IBookService
    {
        Task<IEnumerable<BookModel>> GetBooks(int offset = 0, int limit = 10);
        Task<BookModel> GetBook(int bookId);
        Task<BookModel> AddBook(AddBookModel book);
        Task UpdateBook(int bookId, UpdateBookModel book);
        Task DeleteBook(int bookId);
    }
}
