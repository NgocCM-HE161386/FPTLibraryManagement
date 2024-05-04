using LibraryManagement.Management;
using System;
using System.Windows;

namespace LibraryManagement
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private MainWindow _mainWindow;
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = txtUser.Text;
                String password = txtPass.Password;

                bool isAdmin = AdminManagement.Instance.AdminLogin(name, password);
                if (isAdmin)
                {
                    _mainWindow = new MainWindow();
                    _mainWindow.Show();
                    this.Close();
                }
                else
                {
                    txtFail.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                txtFail.Visibility = Visibility.Visible;
                //MessageBox.Show(ex.Message);
            }

        }
    }
}
