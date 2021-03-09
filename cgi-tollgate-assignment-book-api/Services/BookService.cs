using cgi_tollgate_assignment_book_api.DAL;
using cgi_tollgate_assignment_book_api.Exceptions;
using cgi_tollgate_assignment_book_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cgi_tollgate_assignment_book_api.Services
{
    public class BookService : IBookService
    {
        /*
        Use constructor Injection to inject all required dependencies.
        */
        private readonly IBookRepository repo;
        public BookService(IBookRepository _repo)
        {
            repo = _repo;
        }

        /*
	    * This method should be used to save a new book.
	    */
        public Book AddBook(Book book)
        {
            return repo.AddBook(book);
            //throw new NotImplementedException();
        }

        /* This method should be used to delete an existing book.
         * Throw BookNotFoundException in case book not found based on specified bookId. 
         */
        public bool DeleteBook(int id)
        {
            var result = repo.DeleteBook(id);
            if (result)
                return result;
            throw new BookNotFoundException($"Book with id: {id} does not exists");
            //throw new NotImplementedException();
        }

        /* This method should be used to get a book by bookId. 
         * Throw BookNotFoundException in case book not found based on specified bookId.
         */
        public Book GetBookById(int id)
        {
            var result = repo.GetBookById(id);
            if (result != null)
                return result;
            throw new BookNotFoundException($"Book with id: {id} does not exists");
            //throw new NotImplementedException();
        }

        /* This method should be used to get a book all books. */
        public List<Book> GetBooks()
        {
            return repo.GetBooks();
            //throw new NotImplementedException();
        }

        /* This method should be used to update a book by bookId.
         * Throw BookNotFoundException in case book not found based on specified bookId. 
         */
        public bool UpdateBook(int id, Book book)
        {
            var result = repo.UpdateBook(id, book);
            if (result)
                return result;
            throw new BookNotFoundException($"Book with id: {id} does not exists");
            //throw new NotImplementedException();
        }
    }
}
