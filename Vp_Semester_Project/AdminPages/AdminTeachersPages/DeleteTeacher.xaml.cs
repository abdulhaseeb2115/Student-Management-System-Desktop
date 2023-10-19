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
    /// Interaction logic for DeleteTeacher.xaml
    /// </summary>
    public partial class DeleteTeacher : Page
    {
        public DeleteTeacher()
        {
            InitializeComponent();
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
                        IDOutput.Content = "T-" + teacherData[0];
                        NameOutput.Content = teacherData[1];
                        FatherNameOutput.Content = teacherData[2];
                        QualificationOutput.Content = teacherData[3];

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

        private void clearVisibility()
        {
            noData.Visibility = Visibility.Hidden;
            foundData.Visibility = Visibility.Hidden;
            message.Text = "";
        }

        private void clearFields()
        {
            InputRegNo.Text = "";
            IDOutput.Content = "";
            QualificationOutput.Content = "";
            NameOutput.Content = "";
            FatherNameOutput.Content = "";
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (IDOutput.Content.ToString() != "")
            {
                try
                {
                    AdminTeacherBackend backend = new AdminTeacherBackend();
                    message.Text = backend.DeleteTeacher(int.Parse(IDOutput.Content.ToString().Substring(2)));
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
        }
    }
}
