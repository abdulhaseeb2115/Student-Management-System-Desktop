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

namespace Vp_Semester_Project.AdminPages.AdminTeachersPages
{
    /// <summary>
    /// Interaction logic for UpdateTeacher.xaml
    /// </summary>
    public partial class UpdateTeacher : Page
    {
        public UpdateTeacher()
        {
            InitializeComponent();
        }

        private void clearVisibility()
        {
            noData.Visibility = Visibility.Hidden;
            foundData.Visibility = Visibility.Hidden;
            message.Text = "";
        }

        private void clearFields()
        {
            InputRegNo.Text = "";
            IdOutput.Content = "";
            NameOutput.Content = "";
            QualificationOutput.Text = "";
            EmailOutput.Text = "";
            PhoneOutput.Text = "";
            AddressOutput.Text = "";
            PasswordOutput.Text = "";
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            if (InputRegNo.Text != "")
            {
                try
                {
                    AdminTeacherBackend backend = new AdminTeacherBackend();
                    string[] teacherData = backend.ViewTeacher(int.Parse(InputRegNo.Text.Substring(2)));
                    if (teacherData.Length == 1)
                    {
                        clearVisibility();
                        noDataLabel.Content = teacherData[0];

                        noData.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        clearVisibility();
                        IdOutput.Content = "T-" + teacherData[0];
                        NameOutput.Content = teacherData[1];

                        QualificationOutput.Text = teacherData[3];
                        EmailOutput.Text = teacherData[4];
                        PhoneOutput.Text = teacherData[5];
                        AddressOutput.Text = teacherData[6];
                        PasswordOutput.Text = teacherData[7];


                        foundData.Visibility = Visibility.Visible;
                    }

                }
                catch (Exception)
                {
                    clearVisibility();
                    noDataLabel.Content = "Invalid Teacher ID !";
                    noData.Visibility = Visibility.Visible;
                }
            }
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(IdOutput.Content.ToString().Substring(2)) > 0)
            {
                if (QualificationOutput.Text != "" && EmailOutput.Text != "" && PhoneOutput.Text != "" && AddressOutput.Text != "" && PasswordOutput.Text != "")
                {
                    try
                    {
                        AdminTeacherBackend backend = new AdminTeacherBackend();
                        message.Text = backend.UpdateTeacher(int.Parse(IdOutput.Content.ToString().Substring(2)), QualificationOutput.Text, EmailOutput.Text, PhoneOutput.Text, AddressOutput.Text, PasswordOutput.Text);
                        clearFields();
                    }
                    catch (Exception e1)
                    {
                        clearFields();
                        message.Text = e1.ToString();
                        //Clipboard.SetText(e1.ToString());
                        message.Text = "An Error Occured !";
                    }
                }
                else
                {
                    message.Text = "Fill All Fields !";
                }
            }
        }

    }
}
