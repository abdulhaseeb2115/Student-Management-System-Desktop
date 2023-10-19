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

namespace Vp_Semester_Project.AdminPages.AdminClassesPages
{
    public partial class ViewClass : Page
    {
        AdminClassesBackend backend = new AdminClassesBackend();
        public ViewClass()
        {
            InitializeComponent();
        }



        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FetchData();
        }


        private void FetchData()
        {
            ComboBoxItem cb = (ComboBoxItem)className.SelectedItem;
            if (!cb.Content.Equals("Select a Class"))
            {
                mainBorder.Visibility = Visibility.Hidden;
                noData.Visibility = Visibility.Hidden;

                string[][] s = backend.ViewClass(cb.Content.ToString());
                if (s.Length == 1)
                {
                    noDataLabel.Content = s[0][0];
                    noData.Visibility = Visibility.Visible;
                }
                else
                {
                    //Clear Grid
                    subjectTeacherList.RowDefinitions.Clear();
                    subjectTeacherList.Children.Clear();

                    //Strength Label
                    RowDefinition strengthRow = new RowDefinition();
                    strengthRow.Height = new GridLength(50);
                    subjectTeacherList.RowDefinitions.Add(strengthRow);

                    Label strength = new Label
                    {
                        Content = "Total Strength",
                        Style = Resources["MainBorderLabel"] as Style,
                        FontWeight = FontWeights.Bold
                    };
                    subjectTeacherList.Children.Add(strength);
                    Grid.SetRow(strength, subjectTeacherList.RowDefinitions.Count - 1);
                    Grid.SetColumn(strength, 0);

                    Label strengthValue = new Label
                    {
                        Content = s[0][0],
                        Style = Resources["MainBorderLabel"] as Style
                    };
                    subjectTeacherList.Children.Add(strengthValue);
                    Grid.SetRow(strengthValue, subjectTeacherList.RowDefinitions.Count - 1);
                    Grid.SetColumn(strengthValue, 2);




                    //Heading Label
                    RowDefinition headingRow = new RowDefinition();
                    headingRow.Height = new GridLength(50);
                    subjectTeacherList.RowDefinitions.Add(headingRow);

                    Label subjectLabel = new Label
                    {
                        Content = "Subjects",
                        Style = Resources["MainBorderLabel"] as Style,
                        FontWeight = FontWeights.Bold
                    };
                    subjectTeacherList.Children.Add(subjectLabel);
                    Grid.SetRow(subjectLabel, subjectTeacherList.RowDefinitions.Count - 1);
                    Grid.SetColumn(subjectLabel, 0);

                    Label teacherLabel = new Label
                    {
                        Content = "Teachers",
                        Style = Resources["MainBorderLabel"] as Style,
                        FontWeight = FontWeights.Bold
                    };
                    subjectTeacherList.Children.Add(teacherLabel);
                    Grid.SetRow(teacherLabel, subjectTeacherList.RowDefinitions.Count - 1);
                    Grid.SetColumn(teacherLabel, 2);




                    for (int i = 1; i < s.Length; i++)
                    {

                        RowDefinition row = new RowDefinition
                        {
                            Height = new GridLength(50)
                        };

                        subjectTeacherList.RowDefinitions.Add(row);

                        Label subject = new Label
                        {
                            Content = s[i][0],
                            Style = Resources["MainBorderLabel"] as Style
                        };
                        subjectTeacherList.Children.Add(subject);
                        Grid.SetRow(subject, subjectTeacherList.RowDefinitions.Count - 1);
                        Grid.SetColumn(subject, 0);

                        Label teacher = new Label
                        {
                            Content = s[i][1],
                            Style = Resources["MainBorderLabel"] as Style
                        };
                        subjectTeacherList.Children.Add(teacher);
                        Grid.SetRow(teacher, subjectTeacherList.RowDefinitions.Count - 1);
                        Grid.SetColumn(teacher, 2);

                    }

                    mainBorder.Visibility = Visibility.Visible;
                }
            }
        }

    }
}
