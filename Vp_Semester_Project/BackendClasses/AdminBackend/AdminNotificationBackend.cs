using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Vp_Semester_Project.Database;

namespace Vp_Semester_Project.BackendClasses.AdminBackend
{
    class AdminNotificationBackend
    {

        public string AddNotification(string heading, string body, string notificationFor, string className)
        {
            try
            {
                Vp_Semester_Project_DBEntities db = new Vp_Semester_Project_DBEntities();
                Notification n = new Notification();
                n.Header = heading;
                n.Body = body;
                n.From = "Admin";
                n.Date = DateTime.Now;
                if (notificationFor.Equals("Teachers"))
                {
                    n.For = "Teachers";
                }
                else if (notificationFor.Equals("Students"))
                {
                    n.For = className;
                }

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
    }
}
