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
    /// Interaction logic for PromoteStudents.xaml
    /// </summary>
    public partial class PromoteStudents : Page
    {
        public PromoteStudents()
        {
            InitializeComponent();
        }

        private void promote_Click(object sender, RoutedEventArgs e)
        {
            AdminStudentBackend backend = new AdminStudentBackend();
            message.Text = backend.PromoteStudents();
        }
    }
}
