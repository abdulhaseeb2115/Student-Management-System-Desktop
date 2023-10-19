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
using Vp_Semester_Project.BackendClasses.TeacherBackend;
using Vp_Semester_Project.Database;

namespace Vp_Semester_Project.TeacherPages
{
    /// <summary>
    /// Interaction logic for TeacherUploadMarks.xaml
    /// </summary>
    public partial class TeacherUploadMarks : Page
    {
        string teacherName;
        int id;
        public TeacherUploadMarks(int id,string name)
        {
            this.id = id;
            this.teacherName = name;

            InitializeComponent();
            List<Classes> classesList = new List<Classes>();
            TeacherBackend backend = new TeacherBackend();
            string[][] classNames = backend.getClasses(id);
            if (className != null && classNames.Length > 0)
            {
                for (int i = 0; i < classNames.Length; i++)
                {
                    classesList.Add(new Classes { Name = classNames[i][0] + " (" + classNames[i][1] + ")", CourseId = classNames[i][0] + classNames[i][2] });
                }
            }

            className.ItemsSource = classesList;
        }

        private void className_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            if (className.SelectedItem != null)
            {
                TeacherBackend backend = new TeacherBackend();
                List<Student_Reg> sl = backend.getStudents(className.SelectedValue.ToString().Substring(0, 5));
                List<Attendance> studentsList = new List<Attendance>();
                for (int i = 0; i < sl.Count(); i++)
                {
                    Attendance a = new Attendance
                    {
                        RegNo = sl.ElementAt(i).Batch_s + sl.ElementAt(i).Batch_y + "-BSE-" + sl.ElementAt(i).Roll_no,
                        Name = sl.ElementAt(i).Name
                    };
                    studentsList.Add(a);
                }

                attendanceList.ItemsSource = studentsList;
                topHeadings.Visibility = Visibility.Visible;
                submitBtn.Visibility = Visibility.Visible;
            }
            else
            {
                List<Attendance> studentsList = new List<Attendance>();
                attendanceList.ItemsSource = studentsList;
            }
        }

        private void submitBtn_click(object sender, RoutedEventArgs e)
        {
            if (className.SelectedValue != null && className.SelectedItem != null && assesmentName.SelectedItem != null && totalMarks.SelectedItem != null)
            {
                TeacherBackend backend = new TeacherBackend();
                for (int i = 0; i < attendanceList.Items.Count; i++)
                {
                    ContentPresenter c = attendanceList.ItemContainerGenerator.ContainerFromItem(attendanceList.Items[i]) as ContentPresenter;
                    DataTemplate myDataTemplate = c.ContentTemplate;

                    Label regNo = (Label)myDataTemplate.FindName("regNo", c);
                    TextBox obtainedMarks = (TextBox)myDataTemplate.FindName("marks", c);


                    string batchS = regNo.Content.ToString().Substring(0, 2).ToUpper();
                    int batchY = int.Parse(regNo.Content.ToString().Substring(2, 2).ToUpper());
                    int rollNo = int.Parse(regNo.Content.ToString().Substring(9));
                    string cn = className.SelectedValue.ToString().Substring(0, 5);
                    int courseId = int.Parse(className.SelectedValue.ToString().Substring(5));

                    ComboBoxItem ci = assesmentName.SelectedItem as ComboBoxItem;
                    string assesment = ci.Content.ToString();
                    ci = totalMarks.SelectedItem as ComboBoxItem;
                    double total = int.Parse(ci.Content.ToString());
                    double obtained = int.Parse(obtainedMarks.Text);


                    double average = obtained / total * 10;

                    backend.UploadMarks(batchS, batchY, rollNo, cn, courseId, assesment, average);
                }


                className.SelectedItem = null;
                assesmentName.SelectedItem = null;
                totalMarks.SelectedItem = null;
                className.Text = "Select a Class";
                assesmentName.Text = "Select Assesment";
                totalMarks.Text = "Total Marks";
                message.Text = "Marks Uploaded";
                topHeadings.Visibility = Visibility.Hidden;
                submitBtn.Visibility = Visibility.Hidden;
                className_SelectionChanged(className, null);
            }
            else
            {
                message.Text = "Fill all Fields !";
            }

        }

    }
    //    public class Classes
    //    {
    //        public string Name { get; set; }
    //        public string CourseId { get; set; }
    //    }
    //    public class Attendance
    //    {
    //        public string RegNo { get; set; }
    //        public string Name { get; set; }
    //    }
}
