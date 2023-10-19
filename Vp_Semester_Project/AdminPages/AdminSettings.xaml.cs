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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Vp_Semester_Project.BackendClasses.AdminBackend;

namespace Vp_Semester_Project.AdminPages
{
    /// <summary>
    /// Interaction logic for AdminSettings.xaml
    /// </summary>
    public partial class AdminSettings : Page
    {

        AdminSettingsBackend backend = new AdminSettingsBackend();
        public AdminSettings()
        {
            InitializeComponent();
        }

        private void ClearFields()
        {
            newPass1.Password = newPass2.Password = oldPass.Password = "";
        }

        private void UpdatePassword(object sender, RoutedEventArgs e)
        {
            if (newPass1.Password != "" && newPass2.Password != "" && oldPass.Password != "")
            {

                if (backend.CheckPassword(oldPass.Password))
                {
                    if (newPass1.Password.Equals(newPass2.Password))
                    {
                        outMessage.Text = backend.UpdatePassword(newPass1.Password.ToString());
                        ClearFields();
                    }
                    else
                    {
                        outMessage.Text = "Passwords Don't Match!";
                    }
                }
                else
                {
                    outMessage.Text = "Old Password Incorrect!";
                }
            }
            else
            {
                outMessage.Text = "Fill All Fields!";
            }

        }
    }
}
