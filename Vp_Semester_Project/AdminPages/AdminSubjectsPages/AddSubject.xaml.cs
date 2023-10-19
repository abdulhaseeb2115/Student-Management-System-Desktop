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

namespace Vp_Semester_Project.AdminPages.AdminSubjectsPages
{
    /// <summary>
    /// Interaction logic for AddSubject.xaml
    /// </summary>
    public partial class AddSubject : Page
    {
        public AddSubject()
        {
            InitializeComponent();
        }

        private void ClearFields()
        {
            NameInput.Text = CreditHrsInput.Text = PrerequisitesInput.Text = "";
        }

        private void addStudent_Click(object sender, RoutedEventArgs e)
        {
            if (NameInput.Text != "" && CreditHrsInput.Text != "" && PrerequisitesInput.Text != "")
            {
                AdminSubjectsBackend backend = new AdminSubjectsBackend();
                message.Text = backend.AddCourse(NameInput.Text, CreditHrsInput.Text, PrerequisitesInput.Text);
                ClearFields();
            }
            else
            {
                message.Text = "Fill All Fields!";
            }
        }
    }
}
