using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Vp_Semester_Project.Database;

namespace Vp_Semester_Project.BackendClasses.TeacherBackend
{
    class TeacherBackend
    {
        //{UTILITY FUNCTIONS}//
        //{Get Classes}//
        public string[][] getClasses(int id)
        {
            try
            {
                Vp_Semester_Project_DBEntities db = new Vp_Semester_Project_DBEntities();
                var r = from x in db.Class_Course_Teacher
                        where x.Teacher_id == id
                        join c in db.Course_Reg on x.Course_id equals c.Id
                        select new
                        {
                            ClassName = x.Class_name,
                            CourseId = x.Course_id,
                            CourseName = c.Name
                        };

                if (r.Count() > 0 && r != null)
                {

                    string[][] classNames = new string[r.Count()][];
                    for (int i = 0; i < r.Count(); i++)
                    {
                        classNames[i] = new string[3] { r.ToList().ElementAt(i).ClassName, r.ToList().ElementAt(i).CourseName, r.ToList().ElementAt(i).CourseId.ToString() };
                    }

                    return classNames;
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

        //{Get Students}//
        public List<Student_Reg> getStudents(string className)
        {
            try
            {
                Vp_Semester_Project_DBEntities db = new Vp_Semester_Project_DBEntities();
                var r = from x in db.Student_Reg
                        where x.Class_name == className
                        select x;

                if (r.Count() > 0 && r != null)
                {
                    return r.ToList();
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
        //--[ADD NOTIFICATION]--//
        public string AddNotification(string heading, string body, string notificationFor, string notificationFrom)
        {
            try
            {
                Vp_Semester_Project_DBEntities db = new Vp_Semester_Project_DBEntities();
                Notification n = new Notification();
                n.Header = heading;
                n.Body = body;
                n.From = notificationFrom;
                n.Date = DateTime.Now;
                n.For = notificationFor;

                db.Notifications.Add(n);
                db.SaveChanges();

                return "Notification Added";
            }
            catch (Exception e)
            {
                return "An Error Occured!";
                //return e.ToString();
            }

        }

        //--[CHECK PASSWORD]--//
        public bool CheckPassword(int id, string oldPass)
        {
            try
            {
                Vp_Semester_Project_DBEntities db = new Vp_Semester_Project_DBEntities();
                var r = from x in db.Teacher_Reg
                        where x.Id == id && x.Login_password == oldPass
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
        public string UpdatePassword(int id, string newPass)
        {

            try
            {
                Vp_Semester_Project_DBEntities db = new Vp_Semester_Project_DBEntities();
                var r = from x in db.Teacher_Reg
                        where x.Id == id
                        select x;
                Teacher_Reg tp = r.First();
                tp.Login_password = newPass;
                db.SaveChanges();
                return "Password Updated";
            }
            catch (Exception e)
            {
                //return "An Error Occured!";
                return e.ToString();
            }
        }

        //--[MARK ATTENDANCE]--//
        public void MarkAttendance(string batchS, int batchY, int rollNo, string className, int courseId, int status, DateTime date)
        {
            try
            {
                Vp_Semester_Project_DBEntities db = new Vp_Semester_Project_DBEntities();
                Student_Attendance attendance = new Student_Attendance
                {
                    Batch_s = batchS,
                    Batch_y = batchY,
                    Roll_no = rollNo,
                    Class_name = className,
                    Course_id = courseId,
                    attendance_status = status,
                    Date = date
                };

                db.Student_Attendance.Add(attendance);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                //return "An Error Occured!";
                MessageBox.Show(e.ToString());
            }
        }
        //--[UPLOAD MARKS]--//
        public void UploadMarks(string batchS, int batchY, int rollNo, string className, int courseId, string assesment, double average)
        {
            Vp_Semester_Project_DBEntities db = new Vp_Semester_Project_DBEntities();
            var r = from x in db.Student_marks
                    where x.Batch_s.Equals(batchS) && x.Batch_y.Equals(batchY) && x.Class_name.Equals(className) && x.Roll_no == rollNo && x.Course_id == courseId
                    select x;

            int marks = (int)average;
            if (r.Count() > 0)
            {
                try
                {
                    Student_marks m = r.First();
                    switch (assesment)
                    {
                        case "Quiz-1": { m.Quiz_1 = marks; break; };
                        case "Quiz-2": { m.Quiz_2 = marks; break; };
                        case "Quiz-3": { m.Quiz_3 = marks; break; };
                        case "Quiz-4": { m.Quiz_4 = marks; break; };
                        case "Assignment-1": { m.Assignment_1 = marks; break; };
                        case "Assignment-2": { m.Assignment_2 = marks; break; };
                        case "Assignment-3": { m.Assignment_3 = marks; break; };
                        case "Assignment-4": { m.Assignment_4 = marks; break; };
                        case "Mids": { m.Mids = marks; break; };
                        case "Terminals": { m.Terinals = marks; break; };
                    };
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
            else
            {
                try
                {
                    Student_marks m = new Student_marks
                    {
                        Batch_s = batchS,
                        Batch_y = batchY,
                        Roll_no = rollNo,
                        Class_name = className,
                        Course_id = courseId,
                        Quiz_1 = 0,
                        Quiz_2 = 0,
                        Quiz_3 = 0,
                        Quiz_4 = 0,
                        Assignment_1 = 0,
                        Assignment_2 = 0,
                        Assignment_3 = 0,
                        Assignment_4 = 0,
                        Mids = 0,
                        Terinals = 0,
                    };
                    switch (assesment)
                    {
                        case "Quiz-1": { m.Quiz_1 = marks; break; };
                        case "Quiz-2": { m.Quiz_2 = marks; break; };
                        case "Quiz-3": { m.Quiz_3 = marks; break; };
                        case "Quiz-4": { m.Quiz_4 = marks; break; };
                        case "Assignment-1": { m.Assignment_1 = marks; break; };
                        case "Assignment-2": { m.Assignment_2 = marks; break; };
                        case "Assignment-3": { m.Assignment_3 = marks; break; };
                        case "Assignment-4": { m.Assignment_4 = marks; break; };
                        case "Mids": { m.Mids = marks; break; };
                        case "Terminals": { m.Terinals = marks; break; };
                    };

                    db.Student_marks.Add(m);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }





        }

        //--[GET Name]--//
        public string getName(int id)
        {
            Vp_Semester_Project_DBEntities db = new Vp_Semester_Project_DBEntities();
            var r = from x in db.Teacher_Reg
                    where x.Id == id
                    select x;
            if (r.Count() == 1)
            {
                return r.First().Name;
            }
            else
            {
                return "";
            }
        }
    }
}
