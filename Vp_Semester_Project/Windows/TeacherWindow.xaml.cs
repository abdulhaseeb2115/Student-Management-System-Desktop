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
using System.Windows.Shapes;
using Vp_Semester_Project.TeacherPages;

namespace Vp_Semester_Project.Windows
{
    /// <summary>
    /// Interaction logic for TeacherWindow.xaml
    /// </summary>
    public partial class TeacherWindow : Window
    {
        //Border Brush Colors//
        SolidColorBrush select = Brushes.White;
        SolidColorBrush deSelect = Brushes.Transparent;
        int id;
        string name;


        public TeacherWindow(int id, string name)
        {
            InitializeComponent();
            this.id = id;
            this.name = name;

            teacherId.Content = "T-"+id;
            teacherName.Content = name;

            dashboardButton.BorderBrush = select;
            PageFrame.Content = new TeacherDashboard(id,name);
        }


        //
        //
        //
        //
        //-----------------------
        //--<UTILITY FUNCTIONS>--
        //-----------------------


        //close Application//
        private void Logout_click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        //remove Selection//
        private void REMOVE_SELECTION()
        {
            //Removes the current selected item in Side Navbar
            dashboardButton.BorderBrush = deSelect;
            notificationButton.BorderBrush = deSelect;
            attendanceButton.BorderBrush = deSelect;
            marksButton.BorderBrush = deSelect;
            settingsButton.BorderBrush = deSelect;
        }


        //------------------------
        //--</UTILITY FUNCTIONS>--
        //------------------------
        //
        //
        //
        //



        private void Dashboard_click(object sender, RoutedEventArgs e)
        {
            REMOVE_SELECTION();
            dashboardButton.BorderBrush = select;
            PageFrame.Content = new TeacherDashboard(id, name);
        }
        private void Notification_click(object sender, RoutedEventArgs e)
        {
            REMOVE_SELECTION();
            notificationButton.BorderBrush = select;
            PageFrame.Content = new TeacherAddNotification(id, name);
        }
        private void Attendance_click(object sender, RoutedEventArgs e)
        {
            REMOVE_SELECTION();
            attendanceButton.BorderBrush = select;
            PageFrame.Content = new TeacherUploadAttendance(id, name);
        }
        private void Marks_click(object sender, RoutedEventArgs e)
        {
            REMOVE_SELECTION();
            marksButton.BorderBrush = select;
            PageFrame.Content = new TeacherUploadMarks(id, name);
        }
        private void Settings_click(object sender, RoutedEventArgs e)
        {
            REMOVE_SELECTION();
            settingsButton.BorderBrush = select;
            PageFrame.Content = new TeacherSettings(id, name);
        }
    }
}
