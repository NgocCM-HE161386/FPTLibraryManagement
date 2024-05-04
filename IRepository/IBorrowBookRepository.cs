using LibraryManagement.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.IRepository
{
    internal interface IBorrowBookRepository
    {
        IEnumerable<BorrowBook> GetBorrowList();
        BorrowBook GetBorrowBook(string bookId, string studentId);
        void InsertBorrowBook(BorrowBook borrow);
        void DeleteBorrowBook(BorrowBook borrow);
        void UpdateBorrowBook(BorrowBook borrow);
    }
}
