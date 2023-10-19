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
using Vp_Semester_Project.BackendClasses.AdminBackend;

namespace Vp_Semester_Project.AdminPages
{
    /// <summary>
    /// Interaction logic for AdminDashboard.xaml
    /// </summary>
    public partial class AdminDashboard : Page
    {

        AdminDashboardBackend backEnd = new AdminDashboardBackend();

        public AdminDashboard()
        {
            InitializeComponent();
            ShowStrengths();
        }

        private void ShowStrengths()
        {
            totalTeachers.Content = backEnd.GetTotalTeachers();
            totalStudents.Content = backEnd.GetTotalStudents();
            bse1.Content = backEnd.GetClassStrength("BSE-1");
            bse2.Content = backEnd.GetClassStrength("BSE-2");
            bse3.Content = backEnd.GetClassStrength("BSE-3");
            bse4.Content = backEnd.GetClassStrength("BSE-4");
            bse5.Content = backEnd.GetClassStrength("BSE-5");
            bse6.Content = backEnd.GetClassStrength("BSE-6");
            bse7.Content = backEnd.GetClassStrength("BSE-7");
            bse8.Content = backEnd.GetClassStrength("BSE-8");
        }

    }
}
