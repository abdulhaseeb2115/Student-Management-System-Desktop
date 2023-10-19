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
using Vp_Semester_Project.BackendClasses.StudentBackend;

namespace Vp_Semester_Project.StudentPages
{
    /// <summary>
    /// Interaction logic for StudentSettings.xaml
    /// </summary>
    public partial class StudentSettings : Page
    {

        string batchS;
        int batchY;
        int rollNo;
        string className;

        public StudentSettings(string bS, int bY, int rn, string cn)
        {
            batchS = bS;
            batchY = bY;
            rollNo = rn;
            className = cn;
            InitializeComponent();
        }

        StudentBackend backend = new StudentBackend();

        private void ClearFields()
        {
            newPass1.Password = newPass2.Password = oldPass.Password = "";
        }

        private void UpdatePassword(object sender, RoutedEventArgs e)
        {
            if (newPass1.Password != "" && newPass2.Password != "" && oldPass.Password != "")
            {

                if (backend.CheckPassword(batchS, batchY, rollNo, oldPass.Password))
                {
                    if (newPass1.Password.Equals(newPass2.Password))
                    {
                        outMessage.Text = backend.UpdatePassword(batchS, batchY, rollNo, newPass1.Password.ToString());
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
