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
namespace Vp_Semester_Project.StudentPages
{
    /// <summary>
    /// Interaction logic for StudentDashboard.xaml
    /// </summary>
    public partial class StudentDashboard : Page 
    {
        string batchS;
        int batchY;
        int rollNo;
        string className;
        public StudentDashboard(string bS, int bY, int rn, string cn)
        {
            batchS = bS;
            batchY = bY;
            rollNo = rn;
            className = cn;
            InitializeComponent();

            try
            {
                StudentBackend backend = new StudentBackend();
                List<Notification> notif = backend.getNotification(cn);

                notificationBox.ItemsSource = notif;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

    }
}

