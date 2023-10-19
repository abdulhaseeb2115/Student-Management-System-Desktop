using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Vp_Semester_Project.BackendClasses.AdminBackend;

namespace Vp_Semester_Project.Windows.Logins
{
    /// <summary>
    /// Interaction logic for AdminLogin.xaml
    /// </summary>
    public partial class AdminLogin : Window
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void login_click(object sender, RoutedEventArgs e)
        {
            if (Password.Password != "")
            {

                AdminSettingsBackend backend = new AdminSettingsBackend();
                if (backend.CheckPassword(Password.Password))
                {
                    Application.Current.MainWindow = new AdminWindow();
                    Application.Current.MainWindow.Show();
                    this.Close();
                }
                else
                {
                    message.Text = "Invalid Password !";
                }
            }
            else
            {
                message.Text = "Enter Password!";
            }
        }


        private void close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
