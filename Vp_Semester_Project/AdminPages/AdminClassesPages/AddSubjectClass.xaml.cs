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

namespace Vp_Semester_Project.AdminPages.AdminClassesPages
{
    public partial class AddSubjectClass : Page
    {
        public AddSubjectClass()
        {
            InitializeComponent();
            AdminClassesBackend backend = new AdminClassesBackend();

            //Teacher List
            List<Classes> ClassList = new List<Classes>();
            ClassList.Add(new Classes { Name = "BSE-1" });
            ClassList.Add(new Classes { Name = "BSE-2" });
            ClassList.Add(new Classes { Name = "BSE-3" });
            ClassList.Add(new Classes { Name = "BSE-4" });
            ClassList.Add(new Classes { Name = "BSE-5" });
            ClassList.Add(new Classes { Name = "BSE-6" });
            ClassList.Add(new Classes { Name = "BSE-7" });
            ClassList.Add(new Classes { Name = "BSE-8" });
            className.ItemsSource = ClassList;





            //Teacher List
            List<Teachers> TeacherList = new List<Teachers>();
            string[][] teacher = backend.getTeachers();
            for (int i = 0; i < teacher.Length; i++)
            {
                Teachers t = new Teachers();
                t.Id = int.Parse(teacher[i][0]);
                t.Name = teacher[i][1];
                TeacherList.Add(t);
            }
            teacherName.ItemsSource = TeacherList;





            //Course List
            List<Courses> CourseList = new List<Courses>();
            string[][] course = backend.getCourses();
            for (int i = 0; i < course.Length; i++)
            {
                Courses c = new Courses();
                c.Id = int.Parse(course[i][0]);
                c.Name = course[i][1];
                CourseList.Add(c);
            }
            courseName.ItemsSource = CourseList;

        }



        private void add_Click(object sender, RoutedEventArgs e)
        {
            AdminClassesBackend backend = new AdminClassesBackend();

            if (className.SelectedValue != null && teacherName.SelectedValue != null && courseName.SelectedValue != null)
            {
                message.Text = backend.AssignNewCourse(className.SelectedValue.ToString(), int.Parse(courseName.SelectedValue.ToString()), int.Parse(teacherName.SelectedValue.ToString()));

                className.SelectedItem = courseName.SelectedItem = teacherName.SelectedItem = null;
                className.Text = "Select a Class";
                courseName.Text = "Select a Course";
                teacherName.Text = "Select a Teacher";
            }
            else
            {
                message.Text = "Select All Fields !";
            }

        }

    }

    public class Teachers
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Courses
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Classes
    {
        public string Name { get; set; }
    }
}
