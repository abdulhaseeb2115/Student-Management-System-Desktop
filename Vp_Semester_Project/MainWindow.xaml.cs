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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Vp_Semester_Project.Windows;
using System.ComponentModel;
using System.Threading;
using Vp_Semester_Project.Windows.Logins;

namespace Vp_Semester_Project
{
    public partial class MainWindow : Window
    {
        BackgroundWorker bg = new BackgroundWorker();
        public MainWindow()
        {
            //Application.Current.MainWindow = new Login();
            //Application.Current.MainWindow = new StudentWindow("FA",21,4,"aaa","BSE-1");
            //Application.Current.MainWindow.Show();
            //this.Close();
            InitializeComponent();

            bg.DoWork += Bg_DoWork;
            bg.ProgressChanged += Bg_ProgressChanged;
            bg.RunWorkerCompleted += Bg_RunWorkerCompleted;
            bg.WorkerSupportsCancellation = true;
            bg.WorkerReportsProgress = true;

            bg.RunWorkerAsync();
        }


        private void Bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Application.Current.MainWindow = new StudentWindow();
            //Application.Current.MainWindow = new TeacherWindow();
            //Application.Current.MainWindow = new AdminWindow();
            Application.Current.MainWindow = new Login();
            Application.Current.MainWindow.Show();
            this.Close();
        }


        private void Bg_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progress.Content = e.ProgressPercentage*10 + "%";
            bar.Value = e.ProgressPercentage * 10;
        }


        private void Bg_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 10; i++)
            {
                bg.ReportProgress(i);
                System.Threading.Thread.Sleep(500);
            }
        }
    }




}
