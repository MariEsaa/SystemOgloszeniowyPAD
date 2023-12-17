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
    /// Logika interakcji dla klasy AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private static List<Offers> offers = new List<Offers>();
        public AdminWindow()
        {
            InitializeComponent();
            refreshOffers();
        }

        public void refreshOffers()
        {
            offers = DataBase.WriteOffers();
            OffersList.ItemsSource = offers;
        }
        private void GoToAdvertisementsBtn_Click(object sender, RoutedEventArgs e)
        {
            OffersWindow offersWindow = new OffersWindow(); 
            offersWindow.Show();
            this.Close();
        }

        private void BackToMainPageBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void GoToProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            ProfileWindow profileWindow = new ProfileWindow();
            profileWindow.Show();
            this.Close();
        }

        private void AddOffersBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditOffers addEditOffers = new AddEditOffers(offers);
            addEditOffers.Show();
            this.Close();
        }

        private void EditOffersBtn_Click(object sender, RoutedEventArgs e)
        {
            if (OffersList.SelectedItem != null)
            {
                Offers offers = OffersList.SelectedItem as Offers;
                AddEditOffers addEditOffers = new AddEditOffers(offers, offers.ID);
                addEditOffers.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("Musisz wybrać z listy ofertę które chcesz edytować ", "Nie wybrano z listy!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void DeleteOffersBtn_Click(object sender, RoutedEventArgs e)
        {
            if (OffersList.SelectedItem != null)
            {
                Offers offers = OffersList.SelectedItem as Offers;
                var rezultat = MessageBox.Show("Czy chcesz usunąć oferte " + offers.PositionName + "?", "Usuwanie", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (rezultat == MessageBoxResult.Yes)
                {
                    DataBase.DeleteOffers(offers.ID);
                    refreshOffers();
                }
            }
            else
            {
                MessageBox.Show("Musisz wybrać z listy ofertę, który chcesz usunąć ", "Nie wybrano z listy!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
