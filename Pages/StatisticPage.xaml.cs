using LibraryManagement.DataAccess;
using LibraryManagement.IRepository;
using LibraryManagement.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace LibraryManagement.Pages
{
    /// <summary>
    /// Interaction logic for StatisticPage.xaml
    /// </summary>
    public partial class StatisticPage : Page
    {
        IBorrowBookRepository borrowBookRepository;
        public StatisticPage()
        {
            borrowBookRepository = new BorrowBookRepository();
            InitializeComponent();
            lvBorrows.ItemsSource = borrowBookRepository.GetBorrowList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var myLibrary = new LibraryManagementContext();
            IQueryable<Book> books = from s in myLibrary.Books select s;
            IQueryable<BookCategory> c = from s in myLibrary.BookCategories select s;
            IQueryable<Author> a = from s in myLibrary.Authors select s;
            IQueryable<Publisher> p = from s in myLibrary.Publishers select s;

            countAuthor.Text = a.ToList().Count.ToString();
            countPublisher.Text = p.ToList().Count.ToString();
            countBook.Text = books.ToList().Count.ToString();
            countCategory.Text = c.ToList().Count.ToString();

        }

        private void btnBorrowingClick(object sender, RoutedEventArgs e)
        {
            var myLibrary = new LibraryManagementContext();
            IQueryable<BorrowBook> books = from s in myLibrary.BorrowBooks.Include(s => s.Student).Include(s => s.Book) select s;

            books = books.Where(s => s.ReturnDate >= DateTime.Today);

            lvBorrows.ItemsSource = books.ToList();
        }

        private void btnExpiredClick(object sender, RoutedEventArgs e)
        {
            var myLibrary = new LibraryManagementContext();
            IQueryable<BorrowBook> books = from s in myLibrary.BorrowBooks.Include(s => s.Student).Include(s => s.Book) select s;

            books = books.Where(s => s.ReturnDate < DateTime.Today);

            lvBorrows.ItemsSource = books.ToList();
        }
    }
}
