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
    /// Logika interakcji dla klasy AddEditLanguages.xaml
    /// </summary>
    public partial class AddEditLanguages : Window
    {
        public List<Language> Languages { get; set; }
        int ID = 0;
        public AddEditLanguages(List<Language> languages)
        {
            InitializeComponent();
            LanguagesLevelCmb.SelectedIndex = 0;
            Title = "Dodaj język";
            AddEditBtn.Content = "Dodaj język";
            AddEditBtn.Click += AddLanguage_Click;
        }
        public AddEditLanguages(Language languages, int id)
        {
            InitializeComponent();
            ID = id;
            LanguagesTxt.Text = languages.Languages;
            LanguagesLevelCmb.Text = languages.LanguageLevel;
            Title = "Edytuj język";
            TitleTxt.Content = "Edytuj język";
            AddEditBtn.Content = "Edytuj język";
            AddEditBtn.Click += EditLanguage_Click;
        }
        private void AddLanguage_Click(object sender, RoutedEventArgs e)
        {
            bool success = true;
            if (string.IsNullOrWhiteSpace(LanguagesTxt.Text))
            {
                MessageBox.Show("Uzupełnij wszystkie pola!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Information);
                success = false;
            }
            else
            {
                if (LanguagesTxt.Text.Length < 3 || LanguagesTxt.Text.Length > 40)
                {
                    MessageBox.Show("Język musi mieć od 3 do 40 znaków", "Niepoprawny język!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
            }
            if (success)
            {
                var id = App.LoggedUser.Id;
                string selectedValue = LanguagesLevelCmb.Text;

                var language = new Language(id, LanguagesTxt.Text,selectedValue);
                DataBase.AddLanguage(language);

                ProfileWindow profileWindow = new ProfileWindow();
                profileWindow.Show();
                this.Close();
            }
        }
        private void EditLanguage_Click(object sender, RoutedEventArgs e)
        {
            bool success = true;
            if (string.IsNullOrWhiteSpace(LanguagesTxt.Text))
            {
                MessageBox.Show("Uzupełnij wszystkie pola!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Information);
                success = false;
            }
            else
            {
                if (LanguagesTxt.Text.Length < 3 || LanguagesTxt.Text.Length > 40)
                {
                    MessageBox.Show("Język musi mieć od 3 do 40 znaków", "Niepoprawny język!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
            }
            if (success)
            {
                var id = App.LoggedUser.Id;
                string selectedValue = LanguagesLevelCmb.Text;

                var language = new Language(id, LanguagesTxt.Text, selectedValue);
                DataBase.UpdateLanguage(language, ID);

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
