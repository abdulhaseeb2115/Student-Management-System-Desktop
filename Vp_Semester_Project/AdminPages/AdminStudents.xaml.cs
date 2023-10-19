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
using Vp_Semester_Project.AdminPages.AdminStudentsPages;

namespace Vp_Semester_Project
{
    /// <summary>
    /// Interaction logic for AdminStudents.xaml
    /// </summary>
    public partial class AdminStudents : Page
    {
        public AdminStudents()
        {
            InitializeComponent();
            PageFrame.Content = new ViewStudent();
            viewButton.BorderBrush = select;
        }
        //
        //
        //
        //
        //-----------------------
        //--<UTILITY FUNCTIONS>--
        //-----------------------

        SolidColorBrush select = Brushes.White;
        SolidColorBrush deSelect = Brushes.Transparent;

        //remove Selection//
        private void REMOVE_SELECTION()
        {
            //Removes the current selected item in Side Navbar
            viewButton.BorderBrush = deSelect;
            addButton.BorderBrush = deSelect;
            updateButton.BorderBrush = deSelect;
            deleteButton.BorderBrush = deSelect;
            promoteButton.BorderBrush = deSelect;
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

        //view//
        private void view_click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new ViewStudent();
            //change selection
            REMOVE_SELECTION();
            viewButton.BorderBrush = select;
        }


        //add//
        private void add_click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new AddStudent();
            //change selection
            REMOVE_SELECTION();
            addButton.BorderBrush = select;
        }

        //delete//
        private void delete_click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new DeleteStudent();
            //change selection
            REMOVE_SELECTION();
            deleteButton.BorderBrush = select;
        }

        //update//
        private void update_click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new UpdateStudent();
            //change selection
            REMOVE_SELECTION();
            updateButton.BorderBrush = select;
        }

        //promote//
        private void promote_click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new PromoteStudents();
            //change selection
            REMOVE_SELECTION();
            promoteButton.BorderBrush = select;
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
