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
using System.Windows.Shapes;
using SystemOgloszeniowyPAD.Classes;

namespace SystemOgloszeniowyPAD.Views
{
    /// <summary>
    /// Logika interakcji dla klasy AddEditCourses.xaml
    /// </summary>
    public partial class AddEditCourses : Window
    {
        public List<Courses> Courses { get; set; }
        int ID = 0;
        public AddEditCourses(List<Courses> courses)
        {
            InitializeComponent();
            Courses = courses;
            Title = "Dodaj kurs,szkolenie";
            AddEditBtn.Content = "Dodaj kurs,szkolenie";
            AddEditBtn.Click += AddCourse_Click;
        }
        public AddEditCourses(Courses courses,int id)
        {
            InitializeComponent();
            ID = id;
            TrainingNameTxt.Text = courses.TrainingName;
            OrganiserTxt.Text = courses.Organiser;
            PeriodFrom.SelectedDate = courses.PeriodFrom;
            PeriodTo.SelectedDate = courses.PeriodTo;
            Title = "Edytuj kurs,szkolenie";
            TitleTxt.Content = "Edytuj kurs,szkolenie";
            AddEditBtn.Content = "Edytuj kurs,szkolenie";
            AddEditBtn.Click += EditCourse_Click;
        }
        private void AddCourse_Click(object sender, RoutedEventArgs e)
        {
            bool success = true;
            if (string.IsNullOrWhiteSpace(TrainingNameTxt.Text) || string.IsNullOrWhiteSpace(OrganiserTxt.Text))
            {
                MessageBox.Show("Uzupełnij wszystkie pola!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Information);
                success = false;
            }
            else
            {
                if (TrainingNameTxt.Text.Length < 3 || TrainingNameTxt.Text.Length > 40)
                {
                    MessageBox.Show("Nazwa szkolenia musi mieć od 3 do 40 znaków", "Niepoprawna nazwa szkolenia !", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
                if (OrganiserTxt.Text.Length < 3 || OrganiserTxt.Text.Length > 40)
                {
                    MessageBox.Show("Organizator musi mieć od 3 do 40 znaków", "Niepoprawny orgrnizator!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
            }
            if (success)
            {
                var id = App.LoggedUser.Id;
                var course = new Courses(id, TrainingNameTxt.Text, OrganiserTxt.Text, PeriodFrom.SelectedDate?.Date ?? DateTime.MinValue, PeriodTo.SelectedDate?.Date ?? DateTime.MinValue);
                DataBase.AddCourse(course);

                ProfileWindow profileWindow = new ProfileWindow();
                profileWindow.Show();
                this.Close();
            }
        }
        private void EditCourse_Click(object sender, RoutedEventArgs e)
        {
            bool success = true;
            if (string.IsNullOrWhiteSpace(TrainingNameTxt.Text) || string.IsNullOrWhiteSpace(OrganiserTxt.Text))
            {
                MessageBox.Show("Uzupełnij wszystkie pola!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Information);
                success = false;
            }
            else
            {
                if (TrainingNameTxt.Text.Length < 3 || TrainingNameTxt.Text.Length > 40)
                {
                    MessageBox.Show("Nazwa szkolenia musi mieć od 3 do 40 znaków", "Niepoprawna nazwa szkolenia !", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
                if (OrganiserTxt.Text.Length < 3 || OrganiserTxt.Text.Length > 40)
                {
                    MessageBox.Show("Organizator musi mieć od 3 do 40 znaków", "Niepoprawny orgrnizator!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
            }
            if (success)
            {
                var id = App.LoggedUser.Id;
                var course = new Courses(id, TrainingNameTxt.Text, OrganiserTxt.Text, PeriodFrom.SelectedDate?.Date ?? DateTime.MinValue, PeriodTo.SelectedDate?.Date ?? DateTime.MinValue);
                DataBase.UpdateCourse(course, ID);

                ProfileWindow profileWindow = new ProfileWindow();
                profileWindow.Show();
                this.Close();
            }
        }
        private void BackToProfilePanelBtn_Click(object sender, RoutedEventArgs e)
        {
            ProfileWindow profileWindow = new ProfileWindow();
            profileWindow.Show();
            this.Close();
        }
    }
}
