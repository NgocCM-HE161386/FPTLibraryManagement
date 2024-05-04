using LibraryManagement.Pages;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace LibraryManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Page homePage;
        Page bookManagementPage;
        Page readerManagementPage;
        Page borrowBookPage;
        Page statisticPage;
        Page aboutPage;
        public MainWindow()
        {
            InitializeComponent();
            homePage = new HomePage();
            bookManagementPage = new BookManagementPage();
            readerManagementPage = new ReaderManagementPage();
            borrowBookPage = new BorrowBookPage();
            statisticPage = new StatisticPage();
            aboutPage = new AboutPage();

            navFrame.Navigate(homePage);
            sidebar.SelectedIndex = 0;
        }

        private void sidebar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (sidebar.SelectedIndex)
            {
                case 0:
                    navFrame.Navigate(homePage);
                    break;
                case 1:
                    navFrame.Navigate(bookManagementPage);
                    break;
                case 2:
                    navFrame.Navigate(readerManagementPage);
                    break;
                case 3:
                    navFrame.Navigate(borrowBookPage);
                    break;
                case 4:
                    navFrame.Navigate(statisticPage);
                    break;
                case 5:
                    navFrame.Navigate(aboutPage);
                    break;
            }
        }

        private void navFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
