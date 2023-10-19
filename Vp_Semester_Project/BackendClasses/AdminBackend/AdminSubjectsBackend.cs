using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Vp_Semester_Project.Database;

namespace Vp_Semester_Project.BackendClasses.AdminBackend
{
    class AdminSubjectsBackend
    { //{UTILITY FUNCTIONS}//

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

        //{get course_id}//
        public int getCourseId()
        {
            Vp_Semester_Project_DBEntities db = new Vp_Semester_Project_DBEntities();
            var r = from x in db.Course_Reg select x;

            return r.ToList().Last().Id;
        }



        //[CORE FUNCTIONS]//

        //--[VIEW]--//
        public string[] ViewCourse(int id)
        {
            Vp_Semester_Project_DBEntities db = new Vp_Semester_Project_DBEntities();

            var r = from x in db.Course_Reg where x.Id == id select x;
            string[] courseData = { r.First().Id.ToString(), r.First().Name, r.First().Credit_hrs, r.First().Prerequisites };
            return courseData;
        }


        //--[ADD]--//
        public string AddCourse(string name, string creditHrs, string prerequisites)
        {
            try
            {
                Vp_Semester_Project_DBEntities db = new Vp_Semester_Project_DBEntities();
                Course_Reg c = new Course_Reg
                {
                    Name = name,
                    Credit_hrs = creditHrs,
                    Prerequisites = prerequisites
                };
                db.Course_Reg.Add(c);
                db.SaveChanges();

                return "Course Registered With ID " + getCourseId();
            }
            catch (Exception e)
            {
                return e.ToString();
            }

        }


        //--[DELETE]--/
        public string DeleteCourse(int id)
        {
            try
            {
                Vp_Semester_Project_DBEntities db = new Vp_Semester_Project_DBEntities();
                var r = from x in db.Course_Reg where x.Id == id select x;

                Course_Reg c = r.First();
                db.Course_Reg.Remove(c);
                db.SaveChanges();

                return "Course Deleted";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return "An Error Occured";
            }

        }


        //--[UPDATE]--//
        public string UpdateCourse(int id, string creditHrs, string prerequisites)
        {
            try
            {
                Vp_Semester_Project_DBEntities db = new Vp_Semester_Project_DBEntities();
                var r = from x in db.Course_Reg where x.Id == id select x;

                Course_Reg c = r.First();
                c.Credit_hrs = creditHrs;
                c.Prerequisites = prerequisites;

                db.SaveChanges();
                return "Course Data Updated !";
            }
            catch (Exception e)
            {
                return e.ToString();
                //return "An Error Occured !";
            }
        }
    }
}
