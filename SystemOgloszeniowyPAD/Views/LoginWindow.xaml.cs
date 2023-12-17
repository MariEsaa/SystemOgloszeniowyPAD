using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    /// Logika interakcji dla klasy LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Close();
        }

        private void BackToMainPageBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();   
            mainWindow.Show();
            this.Close();
        }

        private void LoginPageBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginTxt.Text) || string.IsNullOrWhiteSpace(PasswordTxt.Password))
            {
                MessageBox.Show("Uzupełnij wszystkie pola!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                var login = LoginTxt.Text;
                var users = DataBase.WriteUsers();
                User storedUser = null;
                foreach (var user in users)
                {
                    if (user.Login == login)
                    {
                        storedUser = user;
                        break;
                    }
                }
                if (storedUser != null)
                {
                    var haslo = PasswordTxt.Password;
                    if (storedUser.Password == haslo)
                    { 
                       
                        App.LoggedUser = storedUser;
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Login lub hasło jest niepoprawne!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Login lub hasło jest niepoprawne!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            ProfileWindow profileWindow = new ProfileWindow();
            profileWindow.Show();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Close();
           
        }
        private void LogoutButton(object sender, RoutedEventArgs e)
        {
            App.LoggedUser = null;
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

    }
}
