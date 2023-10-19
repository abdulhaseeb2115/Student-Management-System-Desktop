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
using Vp_Semester_Project.AdminPages.AdminClassesPages;

namespace Vp_Semester_Project
{
    /// <summary>
    /// Interaction logic for AdminClasses.xaml
    /// </summary>
    public partial class AdminClasses : Page
    {
        public AdminClasses()
        {
            InitializeComponent();
            PageFrame.Content = new ViewClass();
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
            deleteButton.BorderBrush = deSelect;
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
        private void viewClass_click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new ViewClass();
            //change selection
            REMOVE_SELECTION();
            viewButton.BorderBrush = select;
        }


        //add//
        private void addSubject_click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new AddSubjectClass();
            //change selection
            REMOVE_SELECTION();
            addButton.BorderBrush = select;
        }

        //delete//
        private void deleteSubject_click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new DeleteSubjectClass();
            //change selection
            REMOVE_SELECTION();
            deleteButton.BorderBrush = select;
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


