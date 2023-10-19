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

namespace Vp_Semester_Project.AdminPages.AdminStudentsPages
{
    public partial class UpdateStudent : Page
    {
        AdminStudentBackend backend = new AdminStudentBackend();
        public UpdateStudent()
        {
            InitializeComponent();
        }

        int serialNo = 0;
        bool suspended;

        private void clearVisibility()
        {
            noData.Visibility = Visibility.Hidden;
            foundData.Visibility = Visibility.Hidden;
            message.Text = "";
        }

        private void clearFields()
        {
            InputRegNo.Text = "";
            RegNoOutput.Content = "";
            NameOutput.Content = "";
            EmailOutput.Text = "";
            AddressOutput.Text = "";
            PasswordOutput.Text = "";
            DobOutput.Text = null;
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            if (InputRegNo.Text != "")
            {
                try
                {
                    string batchS = InputRegNo.Text.Substring(0, 2).ToUpper();
                    int batchY = int.Parse(InputRegNo.Text.Substring(2, 2).ToUpper());
                    int rollNo = int.Parse(InputRegNo.Text.Substring(9));

                    AdminStudentBackend backend = new AdminStudentBackend();
                    string[] studentData = backend.ViewStudent(batchS, batchY, rollNo);
                    if (studentData.Length == 1)
                    {
                        clearVisibility();
                        noDataLabel.Content = studentData[0];

                        noData.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        clearVisibility();
                        serialNo = int.Parse(studentData[0]);
                        RegNoOutput.Content = studentData[1];
                        NameOutput.Content = studentData[4];

                        DobOutput.SelectedDate = DateTime.Parse(studentData[6]);
                        EmailOutput.Text = studentData[7];
                        AddressOutput.Text = studentData[8];
                        PasswordOutput.Text = studentData[9];
                        if (studentData[3] == "Suspended")
                        {
                            this.suspended = true;
                            suspentionBtn.Content = "REMOVE SUSPENTION";
                        }
                        else
                        {
                            this.suspended = false;
                            suspentionBtn.Content = "SUSPEND";
                        }

                        foundData.Visibility = Visibility.Visible;
                        suspentionBtn.Visibility = Visibility.Visible;

                    }

                }
                catch (Exception)
                {
                    clearVisibility();
                    noDataLabel.Content = "Invalid Reg No !";
                    noData.Visibility = Visibility.Visible;
                }
            }
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            if (serialNo > 0)
            {
                if (EmailOutput.Text != "" && AddressOutput.Text != "" && PasswordOutput.Text != "")
                {

                    try
                    {
                        AdminStudentBackend backend = new AdminStudentBackend();
                        message.Text = backend.UpdateStudent(serialNo, EmailOutput.Text, AddressOutput.Text, (DateTime)DobOutput.SelectedDate, PasswordOutput.Text);
                        clearFields();
                        suspentionBtn.Visibility = Visibility.Hidden;
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

        private void suspention_Click(object sender, RoutedEventArgs e)
        {
            if (serialNo > 0)
            {
                AdminStudentBackend backend = new AdminStudentBackend();
                try
                {
                    if (suspended)
                    {
                        message.Text = backend.StudentSuspention(serialNo, "Not suspended");
                        this.suspended = false;
                        suspentionBtn.Content = "SUSPEND";
                    }
                    else
                    {
                        message.Text = backend.StudentSuspention(serialNo, "Suspended");
                        this.suspended = true;
                        suspentionBtn.Content = "REMOVE SUSPENTION";
                    }
                }
                catch (Exception e1)
                {
                    message.Text = e1.ToString();
                    //Clipboard.SetText(e1.ToString());
                    message.Text = "An Error Occured !";
                }
            }
        }

    }

}
