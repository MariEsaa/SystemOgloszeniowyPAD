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
    /// Logika interakcji dla klasy AddEditWorkExperience.xaml
    /// </summary>
    public partial class AddEditWorkExperience : Window
    {
        public List<WorkExperience> WorkExperiences { get; set; }
        int ID = 0;
        public AddEditWorkExperience(List<WorkExperience> workExperiences)
        {
            InitializeComponent();
            WorkExperiences = workExperiences;
            Title = "Dodaj doswiadczenie zawodowe";
            AddEditBtn.Content = "Dodaj doświadczenie";
            AddEditBtn.Click += AddWorkExperience_Click;
        }
        public AddEditWorkExperience(WorkExperience workExperiences, int id)
        {
            InitializeComponent();
            ID = id;
            PositionTxt.Text = workExperiences.Position;
            CompanyNameTxt.Text = workExperiences.CompanyName;
            LocationTxt.Text = workExperiences.Location;
            PeriodOfEmploymentFrom.SelectedDate = workExperiences.PeriodOfEmploymentFrom;
            PeriodOfEmploymentTo.SelectedDate = workExperiences.PeriodOfEmploymentTo;
            ResponsibilitiesTxt.Text = workExperiences.Responsibilities;
            AddEditBtn.Content = "Edytuj doświadczenie";
            Title = "Edytuj doswiadczenie zawodowe";
            TitleTxt.Content = "Edytuj doswiadczenie zawodowe";
            AddEditBtn.Click += EditWorkExperience_Click;
        }
        private void AddWorkExperience_Click(object sender, RoutedEventArgs e)
        {
            bool success = true;
            if (string.IsNullOrWhiteSpace(PositionTxt.Text) || string.IsNullOrWhiteSpace(CompanyNameTxt.Text) || string.IsNullOrWhiteSpace(LocationTxt.Text)
               || string.IsNullOrWhiteSpace(ResponsibilitiesTxt.Text))
            {
                MessageBox.Show("Uzupełnij wszystkie pola!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Information);
                success = false;
            }
            else
            {
                if (PositionTxt.Text.Length < 3 || PositionTxt.Text.Length > 40)
                {
                    MessageBox.Show("Stanowisko musi mieć od 3 do 40 znaków", "Niepoprawne stanowisko!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
                if (CompanyNameTxt.Text.Length < 3 || CompanyNameTxt.Text.Length > 40)
                {
                    MessageBox.Show("Nazwa firmy musi mieć od 3 do 40 znaków", "Niepoprawna nazwa firmy!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
                if (LocationTxt.Text.Length < 3 || LocationTxt.Text.Length > 50)
                {
                    MessageBox.Show("Lokalizacja musi mieć od 3 do 50 znaków", "Niepoprawna lokalizacja!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
                if (ResponsibilitiesTxt.Text.Length < 3 || ResponsibilitiesTxt.Text.Length > 50)
                {
                    MessageBox.Show("Obowiązki muszą mieć od 3 do 50 znaków", "Niepoprawne obowiązki!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
            }
            if (success)
            {
                var id = App.LoggedUser.Id;
                var workExperience = new WorkExperience(id,PositionTxt.Text,CompanyNameTxt.Text,LocationTxt.Text, PeriodOfEmploymentFrom.SelectedDate?.Date ?? DateTime.MinValue,PeriodOfEmploymentTo.SelectedDate?.Date ?? DateTime.MinValue, ResponsibilitiesTxt.Text);
                DataBase.AddWorkExperience(workExperience);

                ProfileWindow profileWindow = new ProfileWindow();
                profileWindow.Show();
                this.Close();
            }
        }
        private void EditWorkExperience_Click(object sender, RoutedEventArgs e)
        {
            bool success = true;
            if (string.IsNullOrWhiteSpace(PositionTxt.Text) || string.IsNullOrWhiteSpace(CompanyNameTxt.Text) || string.IsNullOrWhiteSpace(LocationTxt.Text)
               || string.IsNullOrWhiteSpace(ResponsibilitiesTxt.Text))
            {
                MessageBox.Show("Uzupełnij wszystkie pola!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Information);
                success = false;
            }
            else
            {
                if (PositionTxt.Text.Length < 3 || PositionTxt.Text.Length > 40)
                {
                    MessageBox.Show("Stanowisko musi mieć od 3 do 40 znaków", "Niepoprawne stanowisko!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
                if (CompanyNameTxt.Text.Length < 3 || CompanyNameTxt.Text.Length > 40)
                {
                    MessageBox.Show("Nazwa firmy musi mieć od 3 do 40 znaków", "Niepoprawna nazwa firmy!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
                if (LocationTxt.Text.Length < 3 || LocationTxt.Text.Length > 50)
                {
                    MessageBox.Show("Lokalizacja musi mieć od 3 do 50 znaków", "Niepoprawna lokalizacja!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
                if (ResponsibilitiesTxt.Text.Length < 3 || ResponsibilitiesTxt.Text.Length > 50)
                {
                    MessageBox.Show("Obowiązki muszą mieć od 3 do 50 znaków", "Niepoprawne obowiązki!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
            }
            if (success)
            {
                var id = App.LoggedUser.Id;
                var workExperience = new WorkExperience(id, PositionTxt.Text, CompanyNameTxt.Text, LocationTxt.Text, PeriodOfEmploymentFrom.SelectedDate?.Date ?? DateTime.MinValue, PeriodOfEmploymentTo.SelectedDate?.Date ?? DateTime.MinValue, ResponsibilitiesTxt.Text);
                DataBase.UpdateWorkExperience(workExperience, ID);

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
