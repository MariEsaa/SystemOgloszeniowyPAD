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
    /// Logika interakcji dla klasy RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            bool success = true;
            if (string.IsNullOrWhiteSpace(LoginTxt.Text) || string.IsNullOrWhiteSpace(PasswordTxt.Password) || string.IsNullOrWhiteSpace(RepeatPasswordTxt.Password))
            {
                MessageBox.Show("Uzupełnij wszystkie pola!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Information);
                success = false;
            }
            else
            {
                if (!(LoginTxt.Text.All(char.IsLetterOrDigit)) || LoginTxt.Text.Length < 3 || LoginTxt.Text.Length > 50)
                {
                    MessageBox.Show("Login musi mieć od 3 do 50 znaków i może zawierać tylko litery i liczby", "Niepoprawny login!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
                if (!(PasswordTxt.Password.All(char.IsLetterOrDigit)) || PasswordTxt.Password.Length < 3 || PasswordTxt.Password.Length > 50)
                {
                    MessageBox.Show("Hasło musi mieć od 3 do 50 znaków i może zawierać tylko litery i liczby", "Niepoprawne hasło!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
                if (!(RepeatPasswordTxt.Password.All(char.IsLetterOrDigit)) || RepeatPasswordTxt.Password != PasswordTxt.Password)
                {
                    MessageBox.Show("Podane hasła nie są takie same", "Hasła się nie zgadzają", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
            }

            var login = LoginTxt.Text;
            var users = DataBase.WriteUsers();
            foreach(var user in users )
            {
                if(user.Login == login)
                {
                    success = false;
                    MessageBox.Show("Użytkownik z takim loginem już istnieje!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                }
            }
            if (success)
            {
                var user = new User();
                user.Login = login;
                user.Password = PasswordTxt.Password;
                DataBase.AddUser(user);


                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();
                this.Close();
                
            }
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();   
            loginWindow.Show();
            this.Close();
        }

        private void BackToMainPageBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();  
            mainWindow.Show();
            this.Close();
        }
    }
}
