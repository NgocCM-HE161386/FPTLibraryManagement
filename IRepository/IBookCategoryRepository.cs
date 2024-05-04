using LibraryManagement.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.IRepository
{
    internal interface IBookCategoryRepository
    {
        IEnumerable<BookCategory> GetBookCategories();
        BookCategory GetBookCategoryByID(int categoryId);
    }
}
