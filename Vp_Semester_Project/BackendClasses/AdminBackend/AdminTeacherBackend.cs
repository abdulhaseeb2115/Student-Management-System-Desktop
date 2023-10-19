using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Vp_Semester_Project.Database;

namespace Vp_Semester_Project.BackendClasses.AdminBackend
{
    class AdminTeacherBackend
    {
        //{ UTILITY FUNCTIONS }//


        ///{Get Teacher ID}///
        private int Get_Id()
        {
            Vp_Semester_Project_DBEntities db = new Vp_Semester_Project_DBEntities();
            var r = from s in db.Teacher_Reg
                    select s;
            return r.ToList().Last().Id;
        }


        //[ CORE Functions ]//
        
        //--[VIEW]--//
        public string[] ViewTeacher(int Id)
        {
            string[] teacherData;
            try
            {
                Vp_Semester_Project_DBEntities db = new Vp_Semester_Project_DBEntities();
                var r = from t in db.Teacher_Reg where t.Id == Id select t;


                if (r != null && r.Count() > 0)
                {

                    teacherData = new string[] { r.First().Id.ToString(), r.First().Name.ToString(), r.First().Father_name, r.First().Qualification, r.First().Email, r.First().Phone, r.First().Address, r.First().Login_password };
                }
                else
                {
                    teacherData = new string[] { "No Record Found!" };
                }


            }
            catch (Exception e)
            {
                teacherData = new string[] { e.ToString() };
            }

            return teacherData;
        }

        //--[ADD]--//
        public string AddTeacher(string name, string fathername, string qualification, string email, string phone, string Address)
        {
            try
            {
                Vp_Semester_Project_DBEntities db = new Vp_Semester_Project_DBEntities();
                Teacher_Reg newTeacher = new Teacher_Reg
                {
                    Name = name,
                    Father_name = fathername,
                    Qualification = qualification,
                    Email = email,
                    Phone = phone,
                    Address = Address,
                    Login_password = "12345"
                };


                db.Teacher_Reg.Add(newTeacher);
                db.SaveChanges();
                return "Teacher Added with Id - " + Get_Id();
            }
            catch (Exception e)
            {
                return e.ToString();
                //return "An Error Occured!";
            }
        }

        //--[DELETE]--//
        public string DeleteTeacher(int Id)
        {
            try
            {
                Vp_Semester_Project_DBEntities db = new Vp_Semester_Project_DBEntities();
                var r = from t in db.Teacher_Reg where t.Id == Id select t;
                Teacher_Reg teacher = r.First();
                db.Teacher_Reg.Remove(teacher);
                db.SaveChanges();
                return "Teacher Deleted !";
            }
            catch (Exception e)
            {
                return e.ToString();
                //return "An Error Occured !";
            }
        }

        //--[UPDATE]--//
        public string UpdateTeacher(int Id, string qualification, string email, string phone, string address, string password)
        {
            try
            {
                Vp_Semester_Project_DBEntities db = new Vp_Semester_Project_DBEntities();
                var r = from t in db.Teacher_Reg where t.Id == Id select t;

                Teacher_Reg teacher = r.First();
                teacher.Qualification = qualification;
                teacher.Email = email;
                teacher.Phone = phone;
                teacher.Address = address;
                teacher.Login_password = password;

                db.SaveChanges();
                return "Teacher Data Updated !";
            }
            catch (Exception e)
            {
                return e.ToString();
                //return "An Error Occured !";
            }
        }
    }
}
