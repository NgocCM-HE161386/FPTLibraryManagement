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
    /// Interaction logic for ReaderManagementPage.xaml
    /// </summary>
    public partial class ReaderManagementPage : Page
    {
        IStudentRepository studentRepository;
        public ReaderManagementPage()
        {
            InitializeComponent();
            studentRepository = new StudentRepository();
            lvStudents.ItemsSource = studentRepository.GetStudents();
        }

        private void btn_RefreshClicked(object sender, RoutedEventArgs e)
        {
            rd_studentid.IsChecked = false;
            rd_studentname.IsChecked = false;
            sortName.IsChecked = false;
            sortDOB.IsChecked = false;
            sortDes.IsChecked = false;
            sortAcs.IsChecked = false;
            sortDes.IsChecked = false;
            search_id.Text = "";
            search_name.Text = "";
            lvStudents.ItemsSource = studentRepository.GetStudents();
            lvBorrow.ItemsSource = "";

        }

        private void btn_SearchClicked(object sender, RoutedEventArgs e)
        {
            var myLibrary = new LibraryManagementContext();
            IQueryable<Student> studentsIQ = from s in myLibrary.Students select s;
            if (rd_studentid.IsChecked == true)
            {
                if (!String.IsNullOrEmpty(search_id.Text))
                {
                    studentsIQ = studentsIQ.Where(s => s.StudentId
                    .Contains(search_id.Text));
                }
            }
            if (rd_studentname.IsChecked == true)
            {
                if (!String.IsNullOrEmpty(search_name.Text))
                {
                    studentsIQ = studentsIQ.Where(s => s.StudentName
                    .Contains(search_name.Text));
                }
            }
            if (sortName.IsChecked == true)
            {
                if (sortAcs.IsChecked == true)
                {
                    studentsIQ = studentsIQ.OrderBy(s => s.StudentName);
                }
                if (sortDes.IsChecked == true)
                {
                    studentsIQ = studentsIQ.OrderByDescending(s => s.StudentName);
                }
            }
            if (sortDOB.IsChecked == true)
            {
                if (sortAcs.IsChecked == true)
                {
                    studentsIQ = studentsIQ.OrderBy(s => s.Dob);
                }
                if (sortDes.IsChecked == true)
                {
                    studentsIQ = studentsIQ.OrderByDescending(s => s.Dob);
                }
            }
            lvStudents.ItemsSource = studentsIQ.ToList();
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            var myLibrary = new LibraryManagementContext();
            IQueryable<BorrowBook> borrows = from s in myLibrary.BorrowBooks.Include(s => s.Book) select s;
            borrows = borrows.Where(s => s.StudentId
                    .Contains(tbStudentId.Text));
            lvBorrow.ItemsSource = borrows.ToList();
        }
    }
}
