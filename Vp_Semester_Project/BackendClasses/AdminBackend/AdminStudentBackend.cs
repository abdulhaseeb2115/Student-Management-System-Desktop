using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Vp_Semester_Project.Database;

namespace Vp_Semester_Project.BackendClasses.AdminBackend
{
    class AdminStudentBackend
    {
        //{ UTILITY FUNCTIONS }//



        ///{Get Batch_S}///
        private string Get_Batch_s()
        {
            int month = DateTime.Now.Month;
            if (month >= 2 && month <= 8)
            {
                return "SP";

            }
            else
            {
                return "FA";
            }


        }


        ///{Get Batch_Y}///
        private int Get_Batch_y()
        {
            return DateTime.Now.Year - 2000;
        }


        ///{Get Roll_No}///
        private int Get_Roll_No()
        {
            string batchS = Get_Batch_s();
            int batchY = Get_Batch_y();

            Vp_Semester_Project_DBEntities db = new Vp_Semester_Project_DBEntities();
            var r = from s in db.Student_Reg
                    where s.Batch_s.Equals(batchS) && s.Batch_y.Equals(batchY)
                    select s;
            return r.ToList().Last().Roll_no + 1;
        }



        //[ CORE Functions ]//


        //--[VIEW]--//
        public string[] ViewStudent(string batchS, int batchY, int rollNo)
        {
            string[] studentData;
            try
            {
                Vp_Semester_Project_DBEntities db = new Vp_Semester_Project_DBEntities();
                var r = from s in db.Student_Reg where (s.Batch_s.Equals(batchS) && s.Batch_y.Equals(batchY) && s.Roll_no == rollNo) select s;


                if (r != null && r.Count() > 0)
                {
                    string regNo = r.First().Batch_s + r.First().Batch_y + "-BSE-" + r.First().Roll_no.ToString();

                    studentData = new string[] { r.First().SerialNo.ToString(), regNo, r.First().Class_name, r.First().Status, r.First().Name.ToString(), r.First().Father_name, r.First().Dob.ToString(), r.First().Email, r.First().Address, r.First().Login_password };
                }
                else
                {
                    studentData = new string[] { "No Record Found!" };
                }


            }
            catch (Exception e)
            {
                studentData = new string[] { e.ToString() };
            }

            return studentData;
        }


        //--[ADD]--//
        public string AddStudent(string name, string fatherName, DateTime? dob, string email, string address)
        {
            try
            {
                Vp_Semester_Project_DBEntities db = new Vp_Semester_Project_DBEntities();

                string batchS = Get_Batch_s();
                int batchY = Get_Batch_y();
                int rollNo = Get_Roll_No();

                Student_Reg newStudent = new Student_Reg
                {
                    Batch_s = batchS,
                    Batch_y = batchY,
                    Roll_no = rollNo,
                    Class_name = "BSE-1",
                    Status = "Not Suspended",
                    Name = name,
                    Father_name = fatherName,
                    Dob = (DateTime)dob,
                    Email = email,
                    Address = address,
                    Login_password = "12345"
                };


                db.Student_Reg.Add(newStudent);
                db.SaveChanges();
                return "Student Added with Reg No " + batchS + batchY + "-BSE-" + rollNo;
            }
            catch (Exception e)
            {
                Clipboard.SetText(e.ToString());
                return e.ToString();
                //return "An Error Occured!";
            }
        }


        //--[DELETE]--//
        public string DeleteStudent(int serial_no)
        {
            try
            {
                Vp_Semester_Project_DBEntities db = new Vp_Semester_Project_DBEntities();
                var r = from s in db.Student_Reg where s.SerialNo.Equals(serial_no) select s;
                Student_Reg student = r.First();
                db.Student_Reg.Remove(student);
                db.SaveChanges();
                return "Student Deleted !";
            }
            catch (Exception e)
            {
                return e.ToString();
                //return "An Error Occured !";
            }

        }

        //--[UPDATE]--//
        public string UpdateStudent(int serial_no, string email, string address, DateTime dob, string password)
        {
            try
            {
                Vp_Semester_Project_DBEntities db = new Vp_Semester_Project_DBEntities();
                var r = from s in db.Student_Reg where s.SerialNo.Equals(serial_no) select s;

                Student_Reg student = r.First();
                student.Email = email;
                student.Address = address;
                student.Dob = dob;
                student.Login_password = password;

                db.SaveChanges();
                return "Student Data Updated !";
            }
            catch (Exception e)
            {
                return e.ToString();
                //return "An Error Occured !";
            }
        }

        //--[SUSPENTION]--//
        public string StudentSuspention(int serial_no, string status)
        {
            try
            {
                Vp_Semester_Project_DBEntities db = new Vp_Semester_Project_DBEntities();
                var r = from s in db.Student_Reg where s.SerialNo.Equals(serial_no) select s;

                Student_Reg student = r.First();
                student.Status = status;
                db.SaveChanges();
                return "Suspention Status Updated";
            }
            catch (Exception e)
            {
                return e.ToString();
                //return "An Error Occured !";
            }



        }

        //--[PROMOTE]--//
        public string PromoteStudents()
        {
            try
            {

                Vp_Semester_Project_DBEntities db = new Vp_Semester_Project_DBEntities();
                var r = from x in db.Student_Reg select x;
                foreach (var item in r)
                {
                    switch (item.Class_name)
                    {
                        case "BSE-1": { item.Class_name = "BSE-2"; break; };
                        case "BSE-2": { item.Class_name = "BSE-3"; break; };
                        case "BSE-3": { item.Class_name = "BSE-4"; break; };
                        case "BSE-4": { item.Class_name = "BSE-5"; break; };
                        case "BSE-5": { item.Class_name = "BSE-6"; break; };
                        case "BSE-6": { item.Class_name = "BSE-7"; break; };
                        case "BSE-7": { item.Class_name = "BSE-8"; break; };
                        case "BSE-8": { item.Class_name = "Graduate"; break; };
                    };
                }

                db.SaveChanges();
                return "Students Promoted";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return "An Error Occured !";
            }
        }
    }
}
