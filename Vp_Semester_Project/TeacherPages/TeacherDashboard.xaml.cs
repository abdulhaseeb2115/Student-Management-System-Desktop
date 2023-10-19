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
using Vp_Semester_Project.Database;

namespace Vp_Semester_Project.TeacherPages
{
    /// <summary>
    /// Interaction logic for TeacherDashboard.xaml
    /// </summary>
    public partial class TeacherDashboard : Page
    {
        string teacherName;
        int id;
        public TeacherDashboard(int id, string name)
        {
            this.id = id;
            this.teacherName = name;

            InitializeComponent();
            try
            {
                StudentBackend backend = new StudentBackend();
                List<Notification> notif = backend.getNotification("Teachers");

                notificationBox.ItemsSource = notif;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
