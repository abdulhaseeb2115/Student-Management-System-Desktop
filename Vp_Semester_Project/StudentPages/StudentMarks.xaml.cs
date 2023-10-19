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
using Vp_Semester_Project.BackendClasses.StudentBackend;

namespace Vp_Semester_Project.StudentPages
{
    /// <summary>
    /// Interaction logic for StudentMarks.xaml
    /// </summary>
    public partial class StudentMarks : Page
    {

        string batchS;
        int batchY;
        int rollNo;
        string className;
        public StudentMarks(string bS,int bY,int rn,string cn)
        {
            batchS = bS;
            batchY = bY;
            rollNo = rn;
            className = cn;
            InitializeComponent();
            getcourses();
        }

        private void getcourses()
        {
            AdminClassesBackend backend = new AdminClassesBackend();

            //Course List
            List<Course> CourseList = new List<Course>();
            string[][] course = backend.getCourses();
            for (int i = 0; i < course.Length; i++)
            {
                Course c = new Course();
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
                StudentBackend backend = new StudentBackend();
                int[] marks = backend.getMarks(batchS,batchY,rollNo, int.Parse(courseName.SelectedValue.ToString()));

                if (marks!=null)
                {
                    q1.Content = marks[0];
                    q2.Content = marks[1];
                    q3.Content = marks[2];
                    q4.Content = marks[3];
                    a1.Content = marks[4];
                    a2.Content = marks[5];
                    a3.Content = marks[6];
                    a4.Content = marks[7];
                    mids.Content = marks[8];
                    terminal.Content = marks[9];
                }
            }
        }


    }

    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}