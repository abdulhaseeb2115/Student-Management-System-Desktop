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
using Vp_Semester_Project.BackendClasses.TeacherBackend;

namespace Vp_Semester_Project.TeacherPages
{
    /// <summary>
    /// Interaction logic for TeacherSettings.xaml
    /// </summary>
    public partial class TeacherSettings : Page
    {
        string teacherName;
        int id;

        public TeacherSettings(int id, string name)
        {
            this.id = id;
            this.teacherName = name;

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
                TeacherBackend backend = new TeacherBackend();
                if (backend.CheckPassword(id, oldPass.Password))
                {
                    if (newPass1.Password.Equals(newPass2.Password))
                    {
                        outMessage.Text = backend.UpdatePassword(id, newPass1.Password.ToString());
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
