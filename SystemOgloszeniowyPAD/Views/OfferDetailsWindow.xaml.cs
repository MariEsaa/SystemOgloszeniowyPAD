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
    /// Logika interakcji dla klasy OfferDetailsPage.xaml
    /// </summary>
    public partial class OfferDetailsPage : Window
    {
        int ID;
        public OfferDetailsPage(Offers offers,int id)
        {
            InitializeComponent();
            ID = id;
            CompanyPhoto.Source = new BitmapImage(new Uri(offers.CompanyPhoto, UriKind.RelativeOrAbsolute));
            PositionNameTxt.Text = offers.PositionName;
            CompanyTxt.Text = offers.Company;
            SalaryTxt.Text = offers.Salary + " PLN";
            CategoryTxt.Text = offers.Category;
            LocationTxt.Text = offers.Location;
            ExpirationDateTxt.Text = offers.ExpirationDate.ToString("d.MM.yyyy");
            PositionLevelTxt.Text = offers.PositionLevel;
            ContractTypeTxt.Text = offers.ContractType; 
            WorkdaysTxt.Text = offers.Workdays;
            WorkHoursTxt.Text = offers.WorkHours;   
            TenureTxt.Text = offers.Tenure;
            WorkModeTxt.Text = offers.WorkMode;
            ResponsibilitiesTxt.Text = offers.Responsibilities;
            RequirementsTxt.Text = offers.Requirements;
            BenefitsTxt.Text = offers.Benefits;
            AboutCompanyTxt.Text = offers.AboutCompany;
            CandidateBtn.Content = "Kandyduj na Ofertę";
            CandidateBtn.Click += CandidateBtn_Click;
        }

        public OfferDetailsPage(UserOffers userOffers)
        {
            InitializeComponent();
            CompanyPhoto.Source = new BitmapImage(new Uri(userOffers.CompanyPhoto, UriKind.RelativeOrAbsolute));
            PositionNameTxt.Text = userOffers.PositionName;
            CompanyTxt.Text = userOffers.Company;
            SalaryTxt.Text = userOffers.Salary + " PLN";
            CategoryTxt.Text = userOffers.Category;
            LocationTxt.Text = userOffers.Location;
            ExpirationDateTxt.Text = userOffers.ExpirationDate.ToString("d.MM.yyyy");
            PositionLevelTxt.Text = userOffers.PositionLevel;
            ContractTypeTxt.Text = userOffers.ContractType;
            WorkdaysTxt.Text = userOffers.Workdays;
            WorkHoursTxt.Text = userOffers.WorkHours;
            TenureTxt.Text = userOffers.Tenure;
            WorkModeTxt.Text = userOffers.WorkMode;
            ResponsibilitiesTxt.Text = userOffers.Responsibilities;
            RequirementsTxt.Text = userOffers.Requirements;
            BenefitsTxt.Text = userOffers.Benefits;
            AboutCompanyTxt.Text = userOffers.AboutCompany;
            CandidateBtn.Content = "Wróc do Profilu";
            CandidateBtn.Click += GoToProfileBtn_Click;
           
        }

        private void BackToOfferBtn_Click(object sender, RoutedEventArgs e)
        {
            OffersWindow offersWindow = new OffersWindow();
            offersWindow.Show();
            this.Close();
        }

        private void CandidateBtn_Click(object sender, RoutedEventArgs e)
        {
            var UserID = App.LoggedUser.Id;
            string expirationDateText = ExpirationDateTxt.Text;
            if (!CandidacyForTheOffer(ID))
            {
                if (DateTime.TryParse(expirationDateText, out DateTime expirationDate))
                {
                    var userOffer = new UserOffers(UserID, ID, PositionNameTxt.Text, CompanyPhoto.Source.ToString(), CompanyTxt.Text, LocationTxt.Text, PositionLevelTxt.Text, ContractTypeTxt.Text, WorkdaysTxt.Text, WorkHoursTxt.Text, expirationDate, CategoryTxt.Text, ResponsibilitiesTxt.Text, RequirementsTxt.Text, BenefitsTxt.Text, AboutCompanyTxt.Text, TenureTxt.Text, WorkModeTxt.Text, SalaryTxt.Text);
                    DataBase.AddUserOffers(userOffer);
                    OffersWindow offersWindow = new OffersWindow();
                    offersWindow.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Już kandydujesz na tą ofertę!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
        private bool CandidacyForTheOffer(int OfferID)
        {
            ProfileWindow profileWindow = new ProfileWindow();
            foreach (var item in profileWindow.OffersControl.Items)
            {
                if (item is UserOffers offer && offer.OfferID == OfferID)
                {
                    return true;
                }
            }
            return false;
        }
        private void GoToProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            ProfileWindow profileWindow = new ProfileWindow();
            profileWindow.Show();
            this.Close();
        }
    }
}
