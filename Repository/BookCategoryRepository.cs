using LibraryManagement.DataAccess;
using LibraryManagement.IRepository;
using LibraryManagement.Management;
using System.Collections.Generic;

namespace LibraryManagement.Repository
{
    internal class BookCategoryRepository : IBookCategoryRepository
    {
        public IEnumerable<BookCategory> GetBookCategories() => BookCategoryManagement.Instance.GetBookCategoryList();

        public BookCategory GetBookCategoryByID(int categoryId) => BookCategoryManagement.Instance.GetBookCategoryByID(categoryId);
    }
}
