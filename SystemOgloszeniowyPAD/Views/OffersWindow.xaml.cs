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
    /// Logika interakcji dla klasy OffersWindow.xaml
    /// </summary>
    public partial class OffersWindow : Window
    {
        public OffersWindow()
        {
            InitializeComponent();
            OffersControl.ItemsSource = DataBase.WriteOffers();
            GetPositionName();
            GetCompany();
            GetLocation();
        }
        public void GetPositionName()
        {
            List<string> PositionName = DataBase.GetPositionName();
            PostionNameCmb.ItemsSource = PositionName;
        }
        public void GetCompany()
        {
            List<string> Company = DataBase.GetCompany();
            CompanyCmb.ItemsSource = Company;
        }
        public void GetLocation()
        {
            List<string> Location = DataBase.GetLocation();
            LocationCmb.ItemsSource = Location;
        }
        private void BackToMainPageBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void GoToProfilePageBtn_Click(object sender, RoutedEventArgs e)
        {
            ProfileWindow profileWindow = new ProfileWindow();
            profileWindow.Show();
            this.Close();
        }

        private void GoToOfferDetails(object sender, RoutedEventArgs e)
        {
            var offers = ((Button)sender).CommandParameter as Offers;
            OfferDetailsPage offer = new OfferDetailsPage(offers,offers.ID);
            offer.Show();
            this.Close();
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            string PostionName = PostionNameCmb.Text;
            string Company = CompanyCmb.Text;
            string Category = CategoryCmb.Text;
            string Location = LocationCmb.Text;
            string PositionLevel = PositionLevelCmb.Text;
            string ContractType = ContractTypeCmb.Text;
            string Tenure = TenureCmb.Text;
            string WorkMode = WorkModeCmb.Text;
            OffersControl.ItemsSource = DataBase.SearchOffers(PostionName,Company,Category,Location,PositionLevel,ContractType, Tenure, WorkMode);
        }

        private void CleanBtn_Click(object sender, RoutedEventArgs e)
        {
            PostionNameCmb.Text = null;
            CompanyCmb.Text = null;
            CategoryCmb.Text = null;
            LocationCmb.Text = null;
            PositionLevelCmb.Text = null;
            ContractTypeCmb.Text = null;
            TenureCmb.Text = null;
            WorkModeCmb.Text = null;
            OffersControl.ItemsSource = DataBase.WriteOffers();
        }
    }
}
