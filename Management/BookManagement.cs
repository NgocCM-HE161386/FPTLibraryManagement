using LibraryManagement.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagement.Management
{
    internal class BookManagement
    {
        private static BookManagement instance = null;
        private static readonly object instanceLock = new object();
        private BookManagement() { }
        public static BookManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BookManagement();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Book> GetBookList()
        {
            List<Book> books;
            try
            {
                var myLibrary = new LibraryManagementContext();
                books = myLibrary.Books.Include(books => books.Category).Include(books => books.Publisher).Include(books => books.Author).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return books;
        }
        public Book GetBookByID(string bookID)
        {
            Book book = null;
            try
            {
                var myLibrary = new LibraryManagementContext();
                book = myLibrary.Books.SingleOrDefault(book => book.BookId == bookID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return book;
        }
        public void AddNew(Book book)
        {
            try
            {
                Book _book = GetBookByID(book.BookId);
                if (_book == null)
                {
                    var myLibrary = new LibraryManagementContext();
                    myLibrary.Books.Add(book);
                    myLibrary.SaveChanges();
                }
                else
                {
                    throw new Exception("The Book is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Book book)
        {
            try
            {
                Book b = GetBookByID(book.BookId);
                if (b != null)
                {
                    var myLibrary = new LibraryManagementContext();
                    myLibrary.Entry<Book>(book).State = EntityState.Modified;
                    myLibrary.SaveChanges();
                }
                else
                {
                    throw new Exception("The Book does not exist.");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Delete(Book book)
        {
            try
            {
                Book b = GetBookByID(book.BookId);
                if (b != null)
                {
                    var myLibrary = new LibraryManagementContext();
                    myLibrary.Books.Remove(book);
                    myLibrary.SaveChanges();
                }
                else
                {
                    throw new Exception("The Book does not exist.");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
