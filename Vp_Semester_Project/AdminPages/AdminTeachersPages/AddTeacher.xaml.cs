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
    /// Interaction logic for AddTeacher.xaml
    /// </summary>
    public partial class AddTeacher : Page
    {
        public AddTeacher()
        {
            InitializeComponent();
        }

        private void ClearFields()
        {
            NameInput.Text = FatherNameInput.Text = QualificationInput.Text = AddressInput.Text = EmailInput.Text = PhoneInput.Text = "";
        }

        private void addTeacher_Click(object sender, RoutedEventArgs e)
        {
            if (NameInput.Text != "" && FatherNameInput.Text != "" && QualificationInput.Text != "" && EmailInput.Text != "" && QualificationInput.Text != "" && AddressInput.Text != "")
            {
                AdminTeacherBackend backend = new AdminTeacherBackend();
                message.Text = backend.AddTeacher(NameInput.Text, FatherNameInput.Text, QualificationInput.Text, EmailInput.Text, PhoneInput.Text, AddressInput.Text);
                ClearFields();
            }
            else
            {
                message.Text = "Fill All Fields!";
            }
        }
    }
}
