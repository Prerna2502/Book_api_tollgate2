using cgi_tollgate_assignment_book_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cgi_tollgate_assignment_book_api.DAL
{
    public class BookRepository : IBookRepository
    {
        /*
       Use constructor Injection to inject all required dependencies.
       */
        private readonly BookDataContext db;
        public BookRepository(BookDataContext _db)
        {
            db = _db;
        }
        /*
      * This method should be used to save a new book.
      */
        public Book AddBook(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
            return db.Find<Book>(book.BookId);
            //throw new NotImplementedException();
        }

        /*
       * This method should be used to delete an existing book.
       */
        public bool DeleteBook(int id)
        {
            var book = db.Find<Book>(id);
            if (book != null)
            {
                db.Books.Remove(book);
                db.SaveChanges();
                return true;
            }
            return false;
            //throw new NotImplementedException();
        }

        /*
       * This method should be used to get a book base on specified bookId.
       */
        public Book GetBookById(int id)
        {
            return db.Find<Book>(id);
            //throw new NotImplementedException();
        }

        /*
       * This method should be used to retreive all books.
       */
        public List<Book> GetBooks()
        {
            return db.Books.ToList<Book>();
            //throw new NotImplementedException();
        }

        /*
       * This method should be used to update an existing book based on specified bookId.
       */
        public bool UpdateBook(int id, Book book)
        {
            if (id != book.BookId)
            {
                return false;
            }
            db.Update<Book>(book);
            db.SaveChanges();
            return true;
            //throw new NotImplementedException();
        }
    }
}
