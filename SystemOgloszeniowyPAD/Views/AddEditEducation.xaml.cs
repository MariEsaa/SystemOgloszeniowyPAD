using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Logika interakcji dla klasy AddEditEducation.xaml
    /// </summary>
    public partial class AddEditEducation : Window
    {
        public List<Education> Educations { get; set; }
        int ID = 0;
        public AddEditEducation(List<Education> educations)
        {
            InitializeComponent();
            Educations = educations;
            Title = "Dodaj doswiadczenie zawodowe";
            AddEditBtn.Content = "Dodaj wykształcenie";
            AddEditBtn.Click += AddEducation_Click;            
            EducationLevelCmb.SelectedIndex = 0;
        }
        public AddEditEducation(Education educations, int id)
        {
            InitializeComponent();
            ID = id;
            SchoolNameTxt.Text = educations.SchoolName;
            LocationTxt.Text = educations.Location;
            DirectionTxt.Text = educations.Direction;
            EducationLevelCmb.Text = educations.EducationLevel;
            PeriodFrom.SelectedDate = educations.PeriodFrom;
            PeriodTo.SelectedDate = educations.PeriodTo;
            Title = "Edytuj doswiadczenie zawodowe";
            TitleTxt.Content = "Edytuj doswiadczenie zawodowe";
            AddEditBtn.Content = "Edytuj wykształcenie";
            AddEditBtn.Click += EditEducation_Click;
        }
        private void AddEducation_Click(object sender, RoutedEventArgs e)
        {
            bool success = true;
            if (string.IsNullOrWhiteSpace(SchoolNameTxt.Text) || string.IsNullOrWhiteSpace(LocationTxt.Text) || string.IsNullOrWhiteSpace(DirectionTxt.Text))
            {
                MessageBox.Show("Uzupełnij wszystkie pola!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Information);
                success = false;
            }
            else
            {
                if (SchoolNameTxt.Text.Length < 3 || SchoolNameTxt.Text.Length > 40)
                {
                    MessageBox.Show("Nazwa szkoły musi mieć od 3 do 40 znaków", "Niepoprawne stanowisko!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
                if (LocationTxt.Text.Length < 3 || LocationTxt.Text.Length > 50)
                {
                    MessageBox.Show("Lokalizacja musi mieć od 3 do 50 znaków", "Niepoprawna lokalizacja!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
                if (DirectionTxt.Text.Length < 3 || DirectionTxt.Text.Length > 50)
                {
                    MessageBox.Show("Kierunek musi mieć od 3 do 50 znaków", "Niepoprawny kierunek!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
            }
            if (success)
            {
                var id = App.LoggedUser.Id;
                string selectedValue = EducationLevelCmb.Text;

                var education = new Education(id, SchoolNameTxt.Text, LocationTxt.Text, selectedValue, DirectionTxt.Text, PeriodFrom.SelectedDate?.Date ?? DateTime.MinValue, PeriodTo.SelectedDate?.Date ?? DateTime.MinValue);
                DataBase.AddEducation(education);

                ProfileWindow profileWindow = new ProfileWindow();
                profileWindow.Show();
                this.Close();
            }
        }
        private void EditEducation_Click(object sender, RoutedEventArgs e)
        {
            bool success = true;
            if (string.IsNullOrWhiteSpace(SchoolNameTxt.Text) || string.IsNullOrWhiteSpace(LocationTxt.Text) || string.IsNullOrWhiteSpace(DirectionTxt.Text))
            {
                MessageBox.Show("Uzupełnij wszystkie pola!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Information);
                success = false;
            }
            else
            {
                if (SchoolNameTxt.Text.Length < 3 || SchoolNameTxt.Text.Length > 40)
                {
                    MessageBox.Show("Nazwa szkoły musi mieć od 3 do 40 znaków", "Niepoprawne stanowisko!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
                if (LocationTxt.Text.Length < 3 || LocationTxt.Text.Length > 50)
                {
                    MessageBox.Show("Lokalizacja musi mieć od 3 do 50 znaków", "Niepoprawna lokalizacja!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
                if (DirectionTxt.Text.Length < 3 || DirectionTxt.Text.Length > 50)
                {
                    MessageBox.Show("Kierunek musi mieć od 3 do 50 znaków", "Niepoprawny kierunek!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
            }
            if (success)
            {
                var id = App.LoggedUser.Id;
                string selectedValue = EducationLevelCmb.Text;

                var education = new Education(id, SchoolNameTxt.Text, LocationTxt.Text, selectedValue, DirectionTxt.Text, PeriodFrom.SelectedDate?.Date ?? DateTime.MinValue, PeriodTo.SelectedDate?.Date ?? DateTime.MinValue);
                DataBase.UpdateEducation(education, ID);

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
