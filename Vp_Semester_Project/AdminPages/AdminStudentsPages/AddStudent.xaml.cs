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
    /// <summary>
    /// Interaction logic for AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Page
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void ClearFields()
        {
            NameInput.Text = FatherNameInput.Text = AddressInput.Text = EmailInput.Text = "";
            DOBInput.Text = null;
        }

        private void addStudent_Click(object sender, RoutedEventArgs e)
        {
            if (NameInput.Text != "" && FatherNameInput.Text != "" && DOBInput.Text != "" && EmailInput.Text != "" && AddressInput.Text != "")
            {
                AdminStudentBackend backend = new AdminStudentBackend();
                message.Text = backend.AddStudent(NameInput.Text, FatherNameInput.Text, DOBInput.SelectedDate, EmailInput.Text, AddressInput.Text);
                ClearFields();
            }
            else
            {
                message.Text = "Fill All Fields!";
            }
        }
    }
}
