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
using Vp_Semester_Project.StudentPages;

namespace Vp_Semester_Project.Windows
{
    /// <summary>
    /// Interaction logic for StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        //Border Brush Colors//
        SolidColorBrush select = Brushes.White;
        SolidColorBrush deSelect = Brushes.Transparent;

        string batchS;
        int batchY;
        int rollNo;
        string name;
        string className;


        public StudentWindow(string bS, int bY, int rN, string n, string c)
        {
            InitializeComponent();
            batchS = bS;
            batchY = bY;
            rollNo = rN;
            name = n;
            className = c;

            studentRegNo.Content = bS + bY + "-BSE-" + rN;
            studentName.Content = n;

            dashboardButton.BorderBrush = select;
            PageFrame.Content = new StudentDashboard(batchS,batchY,rollNo,className);
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
            PageFrame.Content = new StudentDashboard(batchS, batchY, rollNo, className);
        }
        private void Attendance_click(object sender, RoutedEventArgs e)
        {
            REMOVE_SELECTION();
            attendanceButton.BorderBrush = select;
            PageFrame.Content = new StudentAttendance(batchS, batchY, rollNo, className);
        }
        private void Marks_click(object sender, RoutedEventArgs e)
        {
            REMOVE_SELECTION();
            marksButton.BorderBrush = select;
            PageFrame.Content = new StudentMarks(batchS, batchY, rollNo, className);
        }
        private void Settings_click(object sender, RoutedEventArgs e)
        {
            REMOVE_SELECTION();
            settingsButton.BorderBrush = select;
            PageFrame.Content = new StudentSettings(batchS, batchY, rollNo, className);
        }
    }
}
