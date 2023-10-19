using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Vp_Semester_Project.Database;

namespace Vp_Semester_Project.BackendClasses.AdminBackend
{
    class AdminClassesBackend
    {
        //{UTILITY FUNCTIONS}//

        //{get teachers}//
        public string[][] getTeachers()
        {
            Vp_Semester_Project_DBEntities db = new Vp_Semester_Project_DBEntities();


            var r1 = from x in db.Teacher_Reg select x;

            if (r1 != null && r1.Count() > 0)
            {
                string[][] s = new string[r1.Count()][];

                for (int i = 0; i < r1.Count(); i++)
                {
                    s[i] = new string[2] { r1.ToList().ElementAt(i).Id.ToString(), r1.ToList().ElementAt(i).Name };
                }
                return s;
            }
            else
            {
                string[][] s = new string[1][];
                s[0] = new string[1] { "No Data Found !" };
                return s;
            }

        }

        //{get teachers}//
        public string[][] getCourses()
        {
            Vp_Semester_Project_DBEntities db = new Vp_Semester_Project_DBEntities();


            var r1 = from x in db.Course_Reg select x;

            if (r1 != null && r1.Count() > 0)
            {
                string[][] s = new string[r1.Count()][];

                for (int i = 0; i < r1.Count(); i++)
                {
                    s[i] = new string[2] { r1.ToList().ElementAt(i).Id.ToString(), r1.ToList().ElementAt(i).Name };
                }
                return s;
            }
            else
            {
                string[][] s = new string[1][];
                s[0] = new string[1] { "No Data Found !" };
                return s;
            }

        }






        //[CORE FUNCTIONS]//

        //--[VIEW CLASS]--//
        public string[][] ViewClass(string className)
        {
            Vp_Semester_Project_DBEntities db = new Vp_Semester_Project_DBEntities();

            var r = from n in db.Student_Reg where n.Class_name.Equals(className) select n;

            var r1 = from x in db.Class_Course_Teacher
                     where x.Class_name.Equals(className)
                     join c in db.Course_Reg on x.Course_id equals c.Id
                     join t in db.Teacher_Reg on x.Teacher_id equals t.Id
                     select new
                     {
                         CourseName = c.Name,
                         TeacherName = t.Name,
                         Id = x.Id
                     };

            if (r1 != null && r1.Count() > 0)
            {
                string[][] s = new string[r1.Count() + 1][];


                s[0] = new string[1] { r.Count().ToString() };

                for (int i = 1; i <= r1.Count(); i++)
                {
                    s[i] = new string[3] { r1.ToList().ElementAt(i - 1).CourseName, r1.ToList().ElementAt(i - 1).TeacherName, r1.ToList().ElementAt(i - 1).Id.ToString() };
                }
                return s;
            }
            else
            {
                string[][] s = new string[1][];
                s[0] = new string[1] { "No Data Found !" };
                return s;
            }

        }

        //--[ADD SUBJECT]--//
        public string AssignNewCourse(string className, int courseId, int teacherId)
        {
            try
            {
                Vp_Semester_Project_DBEntities db = new Vp_Semester_Project_DBEntities();
                Class_Course_Teacher cct = new Class_Course_Teacher
                {
                    Class_name = className,
                    Course_id = courseId,
                    Teacher_id = teacherId
                };
                db.Class_Course_Teacher.Add(cct);
                db.SaveChanges();
                return "Course Assigned to " + className;
            }
            catch (Exception e)
            {
                return e.ToString();
                //return "An error Occured";
            }
        }

        //--[DELETE SUBJECT]--//
        public void RemoveCourse(int Id)
        {
            try
            {
                Vp_Semester_Project_DBEntities db = new Vp_Semester_Project_DBEntities();
                var r = from x in db.Class_Course_Teacher where x.Id == Id select x;

                Class_Course_Teacher cct = r.First();
                db.Class_Course_Teacher.Remove(cct);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }



    }
}
