using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vp_Semester_Project.Database;

namespace Vp_Semester_Project.BackendClasses.AdminBackend
{
    class AdminDashboardBackend
    {

        public int GetTotalTeachers()
        {
            Vp_Semester_Project_DBEntities db = new Vp_Semester_Project_DBEntities();
            var r = from t in db.Teacher_Reg select t;
            return r.Count();
        }
        public int GetTotalStudents()
        {
            Vp_Semester_Project_DBEntities db = new Vp_Semester_Project_DBEntities();
            var r = from s in db.Student_Reg select s;
            return r.Count();
        }
        public int GetClassStrength(String className)
        {
            Vp_Semester_Project_DBEntities db = new Vp_Semester_Project_DBEntities();
            var r = from s in db.Student_Reg where s.Class_name.Equals(className) select s;
            return r.Count();
        }
    }
}
