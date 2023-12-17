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
    /// Logika interakcji dla klasy AddEditBasicInformation.xaml
    /// </summary>
    public partial class AddEditBasicInformation : Window
    {
        public List<BasicInformations> BasicInformation { get; set; }
        private int ID {  get; set; }
        public AddEditBasicInformation(List<BasicInformations> basicInformations)
        {
            InitializeComponent();
            BasicInformation = basicInformations;
            Title = "Dodaj Informacje";
            AddEditBtn.Click += AddBasicInformations_Click;
            
        }
        public AddEditBasicInformation(List<BasicInformations> basicInformations, int id)
        {
            InitializeComponent();
            ID = id;
            List<BasicInformations> basicInfoList = DataBase.WriteBasicInformations(ID);

            if (basicInfoList.Count > 0)
            {
                BasicInformations userBasicInfo = basicInfoList[0]; // Zakładam, że dla jednego użytkownika jest tylko jedną informację podstawową

                // Przypisz dane do odpowiednich pól
                Dispatcher.Invoke(() =>
                {
                    NameTxt.Text = userBasicInfo.Name;
                    SurnameTxt.Text = userBasicInfo.Surname;
                    EmailTxt.Text = userBasicInfo.Email;
                    BirthDate.SelectedDate = userBasicInfo.BirthDate;
                    PhoneNumberTxt.Text = userBasicInfo.PhoneNumber;
                    ProfilePictureTxt.Text = userBasicInfo.ProfilePicture;
                    ResidenceTxt.Text = userBasicInfo.Residence;
                });

            }
            basicInformations = DataBase.WriteBasicInformations(ID);

            Title = "Edytuj Informacje";
            TitleTxt.Content = "Edytuj Informacje";
            AddEditBtn.Content = "Edytuj Informacje";
            AddEditBtn.Click += EditBasicInformations_Click;
        }


        private void AddBasicInformations_Click(object sender, RoutedEventArgs e)
        {
            bool success = true;
            if (string.IsNullOrWhiteSpace(NameTxt.Text) || string.IsNullOrWhiteSpace(SurnameTxt.Text) || string.IsNullOrWhiteSpace(EmailTxt.Text) 
               || string.IsNullOrWhiteSpace(PhoneNumberTxt.Text) || string.IsNullOrWhiteSpace(ProfilePictureTxt.Text) || string.IsNullOrWhiteSpace(ResidenceTxt.Text))
            {
                MessageBox.Show("Uzupełnij wszystkie pola!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Information);
                success = false;
            }
            else
            {
                if (!(NameTxt.Text.All(char.IsLetter)) || NameTxt.Text.Length < 3 || NameTxt.Text.Length > 40)
                {
                    MessageBox.Show("Imie musi mieć od 3 do 40 znaków i może zawierać tylko litery", "Niepoprawne imie!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
                if (!(SurnameTxt.Text.All(char.IsLetter)) || SurnameTxt.Text.Length < 3 || SurnameTxt.Text.Length > 40)
                {
                    MessageBox.Show("Nazwisko musi mieć od 3 do 40 znaków i może zawierać tylko litery", "Niepoprawne naziwsko!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
                if (!(IsValidEmail(EmailTxt.Text)) || EmailTxt.Text.Length < 3 || EmailTxt.Text.Length > 50)
                {
                    MessageBox.Show("Email musi mieć od 3 do 50 znaków i musi zawierać @", "Niepoprawny email!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
                if (!(PhoneNumberTxt.Text.All(char.IsDigit)) || PhoneNumberTxt.Text.Length < 9 || PhoneNumberTxt.Text.Length > 9)
                {
                    MessageBox.Show("Numer telefonu musi mieć 9 znaków i może zawierać tylko liczby", "Niepoprawny numer telfonu!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
                if (ProfilePictureTxt.Text.Length < 3 || ProfilePictureTxt.Text.Length > 1000)
                {
                    MessageBox.Show("Zdjęcie profilowe musi mieć od 3 do 1000 znaków i może zawierać tylko litery i cyfry", "Niepoprawne zdjęcie profilowe!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
                if (ResidenceTxt.Text.Length < 3 || ResidenceTxt.Text.Length > 50)
                {
                    MessageBox.Show("Miejsce zamieszkania musi mieć od 3 do 50 znaków", "Niepoprawne miejsce zamieszkania!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
            }
            if (success)
            {
                var id = App.LoggedUser.Id;
                var basicInformations = new BasicInformations(id,NameTxt.Text,SurnameTxt.Text,BirthDate.SelectedDate?.Date ?? DateTime.MinValue, EmailTxt.Text,PhoneNumberTxt.Text,ProfilePictureTxt.Text,ResidenceTxt.Text);
                DataBase.AddBasicInformations(basicInformations);

                ProfileWindow profileWindow = new ProfileWindow();
                profileWindow.Show();
                this.Close();
            }
        }
        private void EditBasicInformations_Click(object sender, RoutedEventArgs e)
        {
            bool success = true;
            if (string.IsNullOrWhiteSpace(NameTxt.Text) || string.IsNullOrWhiteSpace(SurnameTxt.Text) || string.IsNullOrWhiteSpace(EmailTxt.Text)
               || string.IsNullOrWhiteSpace(PhoneNumberTxt.Text) || string.IsNullOrWhiteSpace(ProfilePictureTxt.Text) || string.IsNullOrWhiteSpace(ResidenceTxt.Text))
            {
                MessageBox.Show("Uzupełnij wszystkie pola!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Information);
                success = false;
            }
            else
            {
                if (!(NameTxt.Text.All(char.IsLetter)) || NameTxt.Text.Length < 3 || NameTxt.Text.Length > 40)
                {
                    MessageBox.Show("Imie musi mieć od 3 do 40 znaków i może zawierać tylko litery", "Niepoprawne imie!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
                if (!(SurnameTxt.Text.All(char.IsLetter)) || SurnameTxt.Text.Length < 3 || SurnameTxt.Text.Length > 40)
                {
                    MessageBox.Show("Nazwisko musi mieć od 3 do 40 znaków i może zawierać tylko litery", "Niepoprawne naziwsko!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
                if (!(IsValidEmail(EmailTxt.Text)) || SurnameTxt.Text.Length < 3 || SurnameTxt.Text.Length > 50)
                {
                    MessageBox.Show("Email musi mieć od 3 do 50 znaków i musi zawierać @", "Niepoprawny email!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
                if (!(PhoneNumberTxt.Text.All(char.IsDigit)) || PhoneNumberTxt.Text.Length < 9 || PhoneNumberTxt.Text.Length > 9)
                {
                    MessageBox.Show("Numer telefonu musi mieć 9 znaków i może zawierać tylko liczby", "Niepoprawny numer telfonu!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
                if (ProfilePictureTxt.Text.Length < 3 || ProfilePictureTxt.Text.Length > 1000)
                {
                    MessageBox.Show("Zdjęcie profilowe musi mieć od 3 do 1000 znaków i może zawierać tylko litery i cyfry", "Niepoprawne zdjęcie profilowe!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
                if (ResidenceTxt.Text.Length < 3 || ResidenceTxt.Text.Length > 50)
                {
                    MessageBox.Show("Miejsce zamieszkania musi mieć od 3 do 50 znaków", "Niepoprawne miejsce zamieszkania!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
            }
            if (success)
            {
                var id = App.LoggedUser.Id;
                var basicInformations = new BasicInformations(id, NameTxt.Text, SurnameTxt.Text, BirthDate.SelectedDate?.Date ?? DateTime.MinValue, EmailTxt.Text, PhoneNumberTxt.Text, ProfilePictureTxt.Text, ResidenceTxt.Text);
                DataBase.UpdateBasicInformations(basicInformations, id);

                ProfileWindow profileWindow = new ProfileWindow();
                profileWindow.Show();
                this.Close();
            }
        }
        static bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }

        private void BackToProfilePanelBtn_Click(object sender, RoutedEventArgs e)
        {
            ProfileWindow profileWindow = new ProfileWindow();
            profileWindow.Show();
            this.Close();
        }
    }
}
