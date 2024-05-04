using System.Windows.Controls;

namespace LibraryManagement.Pages
{
    /// <summary>
    /// Interaction logic for AboutPage.xaml
    /// </summary>
    public partial class AboutPage : Page
    {
        Page about;
        Page regu;
        public AboutPage()
        {
            InitializeComponent();
            about = new AboutContent();
            regu = new Regulations();

            contentFrame.Navigate(about);
            bar.SelectedIndex = 0;
        }

        private void bar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (bar.SelectedIndex)
            {
                case 0:
                    contentFrame.Navigate(about);
                    break;
                case 1:
                    contentFrame.Navigate(regu);
                    break;
            }
        }
    }
}
