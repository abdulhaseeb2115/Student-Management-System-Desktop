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
    /// Interaction logic for TeacherAddNotification.xaml
    /// </summary>
    public partial class TeacherAddNotification : Page
    {
        string teacherName;
        int id;
        public TeacherAddNotification(int id, string name)
        {
            this.id = id;
            this.teacherName = name;

            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            TeacherBackend backend = new TeacherBackend();
            message.Text = backend.AddNotification(heading.Text,body.Text,classList.Text,teacherName);
        }
    }
}
