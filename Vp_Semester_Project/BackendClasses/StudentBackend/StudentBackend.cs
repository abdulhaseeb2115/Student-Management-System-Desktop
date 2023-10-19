using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Vp_Semester_Project.Database;

namespace Vp_Semester_Project.BackendClasses.StudentBackend
{
    class StudentBackend
    {
        //{UTILITY FUNCTIONS}//
        public int[] getCourses(string className)
        {
            try
            {
                Vp_Semester_Project_DBEntities db = new Vp_Semester_Project_DBEntities();
                var r = from x in db.Class_Course_Teacher where x.Class_name.Equals(className) select x;

                if (r.Count() > 0 && r != null)
                {

                    int[] courseIds = new int[r.Count()];
                    for (int i = 0; i < r.Count(); i++)
                    {
                        courseIds[i] = r.ToList().ElementAt(i).Course_id;
                    }

                    return courseIds;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }






        //[CORE FUNCTIONS]//
        //--[DASHBOARD]--//
        public List<Notification> getNotification(string className)
        {
            try
            {
                Vp_Semester_Project_DBEntities db = new Vp_Semester_Project_DBEntities();
                var r = from x in db.Notifications where x.For.Equals(className) select x;

                return r.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }


        //--[ATTENDANCE]--//
        public string[] getAttendance(string batchS, int batchY, int rollNo, int courseId)
        {
            try
            {

                Vp_Semester_Project_DBEntities db = new Vp_Semester_Project_DBEntities();

                var n = from c in db.Course_Reg where c.Id == courseId select c;
                string courseName = n.ToList().First().Name;


                var r = from x in db.Student_Attendance where x.Batch_s.Equals(batchS) && x.Batch_y == batchY && x.Roll_no == rollNo && x.Course_id == courseId select x;


                if (r.Count() > 0)
                {

                    double present = 0;
                    for (int i = 0; i < r.Count(); i++)
                    {
                        if (r.ToList().ElementAt(i).attendance_status == 1)
                        {
                            present += 1;
                        }
                    }

                    double average = present / r.Count() * 100;
                    string color = "";
                    if (average >= 80)
                    {
                        color = "Green";
                    }
                    else
                    {
                        color = "Red";
                    }


                    return new string[] { average.ToString(), average + "%", color, courseName };
                }
                else
                {
                    return new string[] { courseName, "No Data Found !" };
                }

            }
            catch (Exception ex)
            {
                return new string[] { ex.ToString() };
            }
        }


        //--[ATTENDANCE]--//
        public int[] getMarks(string batchS, int batchY, int rollNo, int courseId)
        {
            try
            {
                Vp_Semester_Project_DBEntities db = new Vp_Semester_Project_DBEntities();
                var r = from x in db.Student_marks
                        where x.Batch_s.Equals(batchS) && x.Batch_y == batchY && x.Roll_no == rollNo && x.Course_id == courseId
                        select x;

                if (r.Count() > 0)
                {
                    var m = r.ToList().First();
                    return new int[] { m.Quiz_1, m.Quiz_2, m.Quiz_3, m.Quiz_4, m.Assignment_1, m.Assignment_2, m.Assignment_3, m.Assignment_4, m.Mids, m.Terinals };
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        //--[CHECK PASSWORD]--//

        public bool CheckPassword(string batchS, int batchY, int rollNo, string oldPass)
        {
            try
            {
                Vp_Semester_Project_DBEntities db = new Vp_Semester_Project_DBEntities();
                var r = from x in db.Student_Reg
                        where x.Batch_s.Equals(batchS) && x.Batch_y == batchY && x.Roll_no == rollNo && x.Login_password == oldPass
                        select x;

                if (r.Count() == 0)
                {
                    return false;
                }
                else
                {
                    if (r.First().Login_password.Equals(oldPass))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }

        }


        //--[UPDATE PASSWORD]--//

        public string UpdatePassword(string batchS, int batchY, int rollNo, string newPass)
        {

            try
            {
                Vp_Semester_Project_DBEntities db = new Vp_Semester_Project_DBEntities();
                var r = from x in db.Student_Reg
                        where x.Batch_s.Equals(batchS) && x.Batch_y == batchY && x.Roll_no == rollNo
                        select x;
                Student_Reg sp = r.First();
                sp.Login_password = newPass;
                db.SaveChanges();
                return "Password Updated";
            }
            catch (Exception e)
            {
                //return "An Error Occured!";
                return e.ToString();
            }
        }

        public string[] getName(string batchS, int batchY, int rollNo)
        {
            Vp_Semester_Project_DBEntities db = new Vp_Semester_Project_DBEntities();
            var r = from x in db.Student_Reg
                    where x.Batch_s.Equals(batchS) && x.Batch_y == batchY && x.Roll_no == rollNo
                    select x;
            if (r.Count() == 1)
            {

                return new string[] { r.First().Name, r.First().Class_name };
            }
            else
            {
                return new string[] { "" };
            }
        }

    }
}
