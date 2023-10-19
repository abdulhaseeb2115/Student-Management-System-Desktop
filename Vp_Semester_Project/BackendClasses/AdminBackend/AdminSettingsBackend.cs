using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Vp_Semester_Project.Database;

namespace Vp_Semester_Project.BackendClasses.AdminBackend
{
    class AdminSettingsBackend
    {
        public bool CheckPassword(string oldPass)
        {
            Vp_Semester_Project_DBEntities db = new Vp_Semester_Project_DBEntities();
            var r = from p in db.Admin_Password where p.Id == 1 select p;

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

        public string UpdatePassword(string newPass)
        {

            try
            {
                Vp_Semester_Project_DBEntities db = new Vp_Semester_Project_DBEntities();
                var r = from p in db.Admin_Password select p;
                Admin_Password ap = r.First();
                ap.Login_password = newPass;
                db.SaveChanges();
                return "Password Updated";
            }
            catch (Exception e)
            {
                //return "An Error Occured!";
                return e.ToString();
            }
        }

    }
}
