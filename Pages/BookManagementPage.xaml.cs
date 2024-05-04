using LibraryManagement.DataAccess;
using LibraryManagement.IRepository;
using LibraryManagement.Repository;
using LibraryManagement.Windows;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace LibraryManagement.Pages
{
    /// <summary>
    /// Interaction logic for BookManagementPage.xaml
    /// </summary>
    public partial class BookManagementPage : Page
    {
        IBookRepository bookRepository;
        IBorrowBookRepository borrowBookRepository;
        AddBook addBookWindow;
        EditBook editBookWindow;

        public BookManagementPage()
        {
            InitializeComponent();
            bookRepository = new BookRepository();
            borrowBookRepository = new BorrowBookRepository();
            lvBooks.ItemsSource = bookRepository.GetBooks();
        }

        private void btn_AddClicked(object sender, RoutedEventArgs e)
        {
            addBookWindow = new AddBook();
            addBookWindow.Show();
        }

        private void btn_EditClicked(object sender, RoutedEventArgs e)
        {
            if (lvBooks.SelectedIndex == -1)
            {
                MessageBox.Show("Choose a book first!");
            }
            else
            {
                editBookWindow = new EditBook();
                editBookWindow.book = (Book)lvBooks.SelectedItem;
                editBookWindow.Show();
            }

            /*            try
                        {
                            Book b = GetBookObject();
                            bookRepository.UpdateBook(b);
                            lvBooks.ItemsSource = bookRepository.GetBooks();
                            MessageBox.Show("Insert successful");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Insert fail");
                        }*/
        }

        private void btn_SearchClicked(object sender, RoutedEventArgs e)
        {
            var myLibrary = new LibraryManagementContext();
            IQueryable<Book> books = from s in myLibrary.Books.Include(s => s.Author).Include(s => s.Publisher).Include(s => s.Category) select s;

            books = books.Where(s => s.BookName
                .Contains(search_bookName.Text) && s.Author.AuthorName.Contains(search_author.Text));

            if (cboCategory.SelectedItem != null)
            {
                books = books.Where(s => s.CategoryId == Int32.Parse(cboCategory.SelectedValue.ToString()));
            }
            if (sortName.IsChecked == true)
            {
                if (sortAsc.IsChecked == true)
                {
                    books = books.OrderBy(s => s.BookName);
                }
                if (sortDes.IsChecked == true)
                {
                    books = books.OrderByDescending(s => s.BookName);
                }
            }
            if (sortAmount.IsChecked == true)
            {
                if (sortAsc.IsChecked == true)
                {
                    books = books.OrderBy(s => s.Amount);
                }
                if (sortDes.IsChecked == true)
                {
                    books = books.OrderByDescending(s => s.Amount);
                }
            }
            lvBooks.ItemsSource = books.ToList();
        }

        private void btn_RefreshClicked(object sender, RoutedEventArgs e)
        {
            cboCategory.SelectedIndex = -1;
            sortAmount.IsChecked = false;
            sortAsc.IsChecked = false;
            sortDes.IsChecked = false;
            sortName.IsChecked = false;
            search_author.Text = "";
            search_bookName.Text = "";
            lvBooks.ItemsSource = bookRepository.GetBooks();
            btnDelete.IsEnabled = false;
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var myLibrary = new LibraryManagementContext();
            IQueryable<BookCategory> categories = from s in myLibrary.BookCategories select s;
            cboCategory.ItemsSource = categories.ToList();
            cboCategory.DisplayMemberPath = "Category Name";
            cboCategory.SelectedValuePath = "Category Id";


        }

        private void btn_DeleteClicked(object sender, RoutedEventArgs e)
        {
            if (lvBooks.SelectedIndex == -1)
            {
                MessageBox.Show("Choose a book first!");
            }
            else
            {
                try
                {
                    Book b = (Book)lvBooks.SelectedItem;
                    var myLibrary = new LibraryManagementContext();
                    myLibrary.Books.Remove(b);
                    myLibrary.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Delete");
                }
            }
        }

        private void lvSelectionChange(object sender, SelectionChangedEventArgs e)
        {
            if (lvBooks.SelectedIndex == -1)
            {
            }
            else
            {
                Book b = (Book)lvBooks.SelectedItem;
                var myLibrary = new LibraryManagementContext();
                IQueryable<BorrowBook> borrows = from s in myLibrary.BorrowBooks.Include(s => s.Book) select s;
                borrows = borrows.Where(s => s.BookId == b.BookId);
                if (borrows.ToList().Count() == 0)
                {
                    btnDelete.IsEnabled = true;
                }
                else
                {
                    btnDelete.IsEnabled = false;
                }
            }
        }
    }
}
