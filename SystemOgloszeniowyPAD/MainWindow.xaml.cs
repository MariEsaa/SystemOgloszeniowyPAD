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
using SystemOgloszeniowyPAD.Classes;
using SystemOgloszeniowyPAD.Views;

namespace SystemOgloszeniowyPAD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static List<Offers> offers = new List<Offers>();
        public MainWindow()
        {
            InitializeComponent();
            if (App.LoggedUser != null)
            {
                LoginBtn.Content = "Wyloguj się";
                LoginBtn.Click += LogoutBtn_Click;
                LoginBtn.Click -= LoginBtn_Click;

                if (ProfilePanel.Children.Count == 0)
                {
                    Button ProfileButton = new Button();
                    ProfileButton.Content = "Mój Profil";
                    ProfileButton.Name = "ProfileButton";
                    ProfileButton.Height = 60;
                    ProfileButton.Width = 200;
                    Color color = (Color)ColorConverter.ConvertFromString("#7776BC");
                    ProfileButton.Foreground = new SolidColorBrush(color);
                    ProfileButton.HorizontalAlignment = HorizontalAlignment.Right;
                    ProfileButton.VerticalAlignment = VerticalAlignment.Center;
                    ProfileButton.Background = Brushes.WhiteSmoke;
                    ProfileButton.FontSize = 30;
                    ProfileButton.FontWeight = FontWeights.UltraBold;
                    ProfileButton.Margin = new Thickness(45,5,5,5);
                    ProfileButton.BorderThickness = new Thickness(5);
                    Color color2 = (Color)ColorConverter.ConvertFromString("#7776BC");
                    ProfileButton.BorderBrush = new SolidColorBrush(color2);

                    ProfilePanel.Children.Add(ProfileButton);
                    ProfileButton.Click += ProfileButton_Click;
                }
            }
            else
            {
                LoginBtn.Content = "Zaloguj się";
                LoginBtn.Click += LoginBtn_Click;
                LoginBtn.Click -= LogoutBtn_Click;
            }
            WriteNumberOfOffers();
            refreshOffers();
        }
        public void refreshOffers()
        {
            offers = DataBase.WriteNewOffers();
            OffersControl.ItemsSource = offers;
        }
        private void WriteNumberOfOffers()
        {
            DataBase database = new DataBase();
            int numberOfOffers = database.GetNumberOfOffers();
            if (numberOfOffers < 10) 
            {
                esa.Content = $"Przygotowaliśmy dla ciebie {numberOfOffers} atrakcyjne oferty pracy!!!";
            }
            else
            {
                esa.Content = $"Przygotowaliśmy dla ciebie {numberOfOffers} atrakcyjnych ofert pracy!!!";
            }
            
        }

        public void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            App.LoggedUser = null;
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            ProfileWindow profileWindow = new ProfileWindow();
            profileWindow.Show();
            this.Close();

        }

        private void GoToOffersBtn_Click(object sender, RoutedEventArgs e)
        {
            if(App.LoggedUser == null)
            {
                MessageBox.Show("Przepraszamy ale musisz być zalogowany aby przejść do ofert", "Musisz być zalogowany!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                OffersWindow offersWindow = new OffersWindow();
                offersWindow.Show();
                this.Close();
            }
        }

        private void GoToOfferDetails(object sender, RoutedEventArgs e)
        {
            if(App.LoggedUser == null)
            {
                MessageBox.Show("Przepraszamy ale musisz być zalogowany aby zobaczyć detale oferty", "Musisz być zalogowany!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                var offers = ((Button)sender).CommandParameter as Offers;
                OfferDetailsPage offer = new OfferDetailsPage(offers, offers.ID);
                offer.Show();
                this.Close();
            }
            
        }
    }
}
