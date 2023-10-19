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
using Vp_Semester_Project.AdminPages;

namespace Vp_Semester_Project
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        
        //Border Brush Colors//
        SolidColorBrush select = Brushes.White;
        SolidColorBrush deSelect = Brushes.Transparent;
        
        
        public AdminWindow()
        {
            InitializeComponent();
            PageFrame.Content = new AdminDashboard();
            dashboardButton.BorderBrush = select;
        }


        //
        //
        //
        //
        //-----------------------
        //--<UTILITY FUNCTIONS>--
        //-----------------------



        //close Application//
        private void logout_click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //minimise Application
        private void minimise_click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }


        //remove Selection//
        private void REMOVE_SELECTION()
        {
            //Removes the current selected item in Side Navbar
            dashboardButton.BorderBrush = deSelect;
            notificationButton.BorderBrush = deSelect;
            studentsButton.BorderBrush = deSelect;
            teachersButton.BorderBrush = deSelect;
            classesButton.BorderBrush = deSelect;
            subjectsButton.BorderBrush = deSelect;
            settingsButton.BorderBrush = deSelect;
        }


        //------------------------
        //--</UTILITY FUNCTIONS>--
        //------------------------
        //
        //
        //
        //



        //
        //
        //
        //
        //-----------------------
        //--<SIDENAV FUNCTIONS>--
        //-----------------------

        //dashboard//
        private void dashboard_click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new AdminDashboard();
            //change selection
            REMOVE_SELECTION();
            dashboardButton.BorderBrush = select;
        }


        //notifications//
        private void notifications_click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new AdminNotifications();
            //change selection
            REMOVE_SELECTION();
            notificationButton.BorderBrush = select;
        }

        //students//
        private void students_click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new AdminStudents();
            //change selection
            REMOVE_SELECTION();
            studentsButton.BorderBrush = select;
        }

        //teachers//
        private void teachers_click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new AdminTeacher();
            //change selection
            REMOVE_SELECTION();
            teachersButton.BorderBrush = select;
        }

        //classess//
        private void classess_click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new AdminClasses();
            //change selection
            REMOVE_SELECTION();
            classesButton.BorderBrush = select;
        }

        //subjects//
        private void subjects_click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new AdminSubjects();
            //change selection
            REMOVE_SELECTION();
            subjectsButton.BorderBrush = select;
        }
        
        //settings//
        private void settings_click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new AdminSettings();
            //change selection
            REMOVE_SELECTION();
            settingsButton.BorderBrush = select;
        }

       


        //------------------------
        //--</SIDENAV FUNCTIONS>--
        //------------------------
        //
        //
        //
        //

    }
}

