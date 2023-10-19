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

namespace Vp_Semester_Project.AdminPages.AdminSubjectsPages
{
    /// <summary>
    /// Interaction logic for DeleteSubject.xaml
    /// </summary>
    public partial class DeleteSubject : Page
    {
        public DeleteSubject()
        {
            InitializeComponent();
            getcourses();
        }

        private void getcourses()
        {
            AdminSubjectsBackend backend = new AdminSubjectsBackend();

            //Course List
            List<Cours> CourseList = new List<Cours>();
            string[][] course = backend.getCourses();
            for (int i = 0; i < course.Length; i++)
            {
                Cours c = new Cours();
                c.Id = int.Parse(course[i][0]);
                c.Name = course[i][1];
                CourseList.Add(c);
            }
            courseName.ItemsSource = CourseList;
        }


        private void courseName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (courseName.SelectedItem != null)
            {
                try
                {
                    AdminSubjectsBackend backend = new AdminSubjectsBackend();
                    string[] courseData = backend.ViewCourse(int.Parse(courseName.SelectedValue.ToString()));
                    if (courseData.Length == 1)
                    {
                        clearVisibility();
                        noDataLabel.Content = courseData[0];

                        noData.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        clearVisibility();
                        IdOutput.Content = "C - " + courseData[0];
                        NameOutput.Content = courseData[1];
                        CreditHrsOutput.Content = courseData[2];
                        PrerequisitesOutput.Content = courseData[3];

                        foundData.Visibility = Visibility.Visible;
                    }

                }
                catch (Exception)
                {
                    clearVisibility();
                    noDataLabel.Content = "Invalid Course ID !";
                    noData.Visibility = Visibility.Visible;
                }
            }
        }


        private void clearVisibility()
        {
            noData.Visibility = Visibility.Hidden;
            foundData.Visibility = Visibility.Hidden;
        }


        private void deleteCourse_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                AdminSubjectsBackend backend = new AdminSubjectsBackend();
                message.Text = backend.DeleteCourse(int.Parse(courseName.SelectedValue.ToString()));
                courseName.SelectedValue.ToString();

                courseName_SelectionChanged(courseName, null);
            }
            catch (Exception ex)
            {
                message.Text = ex.ToString();
            }

        }
    }

    public class Cours
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
