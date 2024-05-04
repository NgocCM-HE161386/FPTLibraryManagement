using LibraryManagement.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagement.Management
{
    internal class BookCategoryManagement
    {
        private static BookCategoryManagement instance = null;
        private static readonly object instanceLock = new object();
        private BookCategoryManagement() { }
        public static BookCategoryManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BookCategoryManagement();
                    }
                    return instance;
                }
            }
        }
        public BookCategory GetBookCategoryByID(int categoryId)
        {
            BookCategory category = null;
            try
            {
                var myLibrary = new LibraryManagementContext();
                category = myLibrary.BookCategories.SingleOrDefault(category => category.CategoryId == categoryId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return category;
        }
        public IEnumerable<BookCategory> GetBookCategoryList()
        {
            List<BookCategory> categories;
            try
            {
                var myLibrary = new LibraryManagementContext();
                categories = myLibrary.BookCategories.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return categories;
        }
    }
}
