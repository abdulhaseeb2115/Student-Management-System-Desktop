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
using Vp_Semester_Project.BackendClasses.StudentBackend;
using Vp_Semester_Project.BackendClasses.TeacherBackend;

namespace Vp_Semester_Project.Windows.Logins
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }


        private void login_click(object sender, RoutedEventArgs e)
        {
            if (idRoll.Text != "" && Password.Password != "")
            {
                if (studentLogin.IsChecked == true)
                {
                    try
                    {
                        //STUDENT//
                        string batchS = idRoll.Text.Substring(0, 2).ToUpper();
                        int batchY = int.Parse(idRoll.Text.Substring(2, 2).ToUpper());
                        int rollNo = int.Parse(idRoll.Text.Substring(9));
                        StudentBackend backend = new StudentBackend();
                        if (backend.CheckPassword(batchS, batchY, rollNo, Password.Password))
                        {
                            string[] s = backend.getName(batchS, batchY, rollNo);
                            Application.Current.MainWindow = new StudentWindow(batchS, batchY, rollNo, s[0], s[1]);
                            Application.Current.MainWindow.Show();
                            this.Close();
                        }
                        else
                        {
                            message.Text = "Invalid Password !";

                        }
                    }
                    catch (Exception ex)
                    {
                        message.Text = "Invalid Reg No !";
                    }
                }
                else if (teacherLogin.IsChecked == true)
                {
                    try
                    {
                        //TEACHER//
                        int id = int.Parse(idRoll.Text.Substring(2));
                        TeacherBackend backend = new TeacherBackend();
                        if (backend.CheckPassword(id, Password.Password))
                        {
                            string name = backend.getName(id);
                            Application.Current.MainWindow = new TeacherWindow(id, name);
                            Application.Current.MainWindow.Show();
                            this.Close();
                        }
                        else
                        {
                            message.Text = "Invalid Password !";

                        }
                    }
                    catch (Exception ex)
                    {
                        message.Text = "Invalid ID !";
                    }
                }
            }
            else
            {
                message.Text = "Fill All Fields !";
            }

        }

        private void adminLogin_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow = new AdminLogin();
            Application.Current.MainWindow.Show();
            this.Close();
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
