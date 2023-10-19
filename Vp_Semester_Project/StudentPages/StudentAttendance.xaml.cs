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
using Vp_Semester_Project.BackendClasses.StudentBackend;
using Vp_Semester_Project.Database;

namespace Vp_Semester_Project.StudentPages
{
    /// <summary>
    /// Interaction logic for StudentAttendance.xaml
    /// </summary>
    public partial class StudentAttendance : Page
    {
        string batchS;
        int batchY;
        int rollNo;
        string className;
        public StudentAttendance(string bS, int bY, int rn, string cn)
        {
            batchS = bS;
            batchY = bY;
            rollNo = rn;
            className = cn;
            InitializeComponent();


            try
            {
                StudentBackend backend = new StudentBackend();
                List<Attendance> attendanceList = new List<Attendance>();
                int[] coursesList = backend.getCourses(cn);


                if (coursesList != null)
                {
                    for (int i = 0; i < coursesList.Length; i++)
                    {
                        string[] courseAttendance = backend.getAttendance(batchS, batchY, rollNo, coursesList[i]);
                        if (courseAttendance.Length == 2)
                        {
                            Attendance atten = new Attendance
                            {
                                Name = courseAttendance[0],
                                ValuePercentage = courseAttendance[1]
                            };
                            attendanceList.Add(atten);
                        }
                        else if (courseAttendance.Length > 2)
                        {
                            Attendance atten = new Attendance
                            {
                                Value = courseAttendance[0],
                                ValuePercentage = courseAttendance[1],
                                Color = courseAttendance[2],
                                Name = courseAttendance[3]
                            };
                            attendanceList.Add(atten);
                        }
                    }

                }

                attendanceBox.ItemsSource = attendanceList;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

    }
    public class Attendance
    {
        public string Value { get; set; }
        public string ValuePercentage { get; set; }
        public string Color { get; set; }
        public string Name { get; set; }

    }
}
