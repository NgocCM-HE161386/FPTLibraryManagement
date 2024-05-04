using LibraryManagement.DataAccess;
using LibraryManagement.IRepository;
using LibraryManagement.Management;
using System.Collections.Generic;

namespace LibraryManagement.Repository
{
    internal class BorrowBookRepository : IBorrowBookRepository
    {
        public void DeleteBorrowBook(BorrowBook borrow) => BorrowBookManagement.Instance.Remove(borrow);

        public BorrowBook GetBorrowBook(string bookId, string studentId) => BorrowBookManagement.Instance.GetBorrowBook(bookId, studentId);

        public IEnumerable<BorrowBook> GetBorrowList() => BorrowBookManagement.Instance.GetBorrowBookList();

        public void InsertBorrowBook(BorrowBook borrow) => BorrowBookManagement.Instance.AddNew(borrow);

        public void UpdateBorrowBook(BorrowBook borrow) => BorrowBookManagement.Instance.Update(borrow);
    }
}
