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

namespace Vp_Semester_Project.AdminPages
{
    /// <summary>
    /// Interaction logic for AdminNotifications.xaml
    /// </summary>
    public partial class AdminNotifications : Page
    {
        public AdminNotifications()
        {
            InitializeComponent();
            classList.Visibility = Visibility.Hidden;
        }

        enum notificationFor
        {
            Teacher,
            Student
        }

        notificationFor nf;

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

            RadioButton choice = sender as RadioButton;
            if (choice.Content.Equals("Teachers"))
            {
                nf = notificationFor.Teacher;
                classList.Visibility = Visibility.Hidden;
            }
            else
            {
                classList.Visibility = Visibility.Visible;
                nf = notificationFor.Student;
            }
        }

        private void classList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cl = sender as ComboBox;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AdminNotificationBackend backend = new AdminNotificationBackend();
            if (nf == notificationFor.Teacher)
            {
                message.Text = backend.AddNotification(heading.Text, body.Text, "Teachers", null);
            }
            else if (nf == notificationFor.Student)
            {
                message.Text = backend.AddNotification(heading.Text, body.Text, "Students", classList.Text.ToString());
            }
        }

    }
}
