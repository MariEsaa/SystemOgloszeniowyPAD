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
    /// Logika interakcji dla klasy AddEditOffers.xaml
    /// </summary>
    public partial class AddEditOffers : Window
    {
        public List<Offers> Offers { get; set; }
        int ID = 0;
        public AddEditOffers(List<Offers> offers)
        {

            InitializeComponent();
            Offers = offers;
            Title = "Dodaj ofertę";
            PositionLevelCmb.SelectedIndex = 0;
            ContractTypeCmb.SelectedIndex = 0;
            TenureCmb.SelectedIndex = 0;
            WorkModeCmb.SelectedIndex = 0;
            CategoryCmb.SelectedIndex = 0;
            TitleTxt.Content = "Dodaj Ofertę";
            AddEditBtn.Content = "Dodaj Ofertę";
            AddEditBtn.Click += AddOffer_Click;
        }
        public AddEditOffers(Offers offers, int id)
        {

            InitializeComponent();
            ID = id;
            Title = "Edytuj ofertę";
            PositionNameTxt.Text = offers.PositionName;
            CompanyPhotoTxt.Text = offers.CompanyPhoto;
            CompanyTxt.Text = offers.Company;
            LocationTxt.Text = offers.Location;
            PositionLevelCmb.Text = offers.PositionLevel;
            ContractTypeCmb.Text = offers.ContractType;
            WorkdaysTxt.Text = offers.Workdays;
            WorkHoursTxt.Text = offers.WorkHours;
            ExpirationDate.SelectedDate = offers.ExpirationDate;
            CategoryCmb.Text = offers.Category;
            ResponsibilitiesTxt.Text = offers.Responsibilities;
            RequirementsTxt.Text = offers.Requirements;
            BenefitsTxt.Text = offers.Benefits;
            AboutCompanyTxt.Text = offers.AboutCompany;
            TenureCmb.Text = offers.Tenure;
            WorkModeCmb.Text = offers.WorkMode;
            SalaryTxt.Text = offers.Salary;
            TitleTxt.Content = "Edytuj Ofertę";
            AddEditBtn.Content = "Edytuj Ofertę";
            AddEditBtn.Click += EditOffer_Click;
        }
        private void AddOffer_Click(object sender, RoutedEventArgs e)
        {
            bool success = true;
            if (string.IsNullOrWhiteSpace(PositionNameTxt.Text) || string.IsNullOrWhiteSpace(CompanyPhotoTxt.Text) || string.IsNullOrWhiteSpace(CompanyTxt.Text)
               || string.IsNullOrWhiteSpace(LocationTxt.Text) || string.IsNullOrWhiteSpace(WorkdaysTxt.Text) || string.IsNullOrWhiteSpace(WorkHoursTxt.Text)
               || string.IsNullOrWhiteSpace(ResponsibilitiesTxt.Text) || string.IsNullOrWhiteSpace(RequirementsTxt.Text)|| string.IsNullOrWhiteSpace(BenefitsTxt.Text) 
               || string.IsNullOrWhiteSpace(AboutCompanyTxt.Text) || string.IsNullOrWhiteSpace(SalaryTxt.Text))
            {
                MessageBox.Show("Uzupełnij wszystkie pola!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Information);
                success = false;
            }
            else
            {
                if (PositionNameTxt.Text.Length < 3 || PositionNameTxt.Text.Length > 40)
                {
                    MessageBox.Show("Stanowisko musi mieć od 3 do 40 znaków", "Niepoprawne stanowisko!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
                if (CompanyPhotoTxt.Text.Length < 3 || CompanyPhotoTxt.Text.Length > 1000)
                {
                    MessageBox.Show("Zdjęcie firmy musi mieć od 3 do 1000 znaków", "Niepoprawne zdjęcie firmy!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
                if (CompanyTxt.Text.Length < 3 || CompanyTxt.Text.Length > 40)
                {
                    MessageBox.Show("Firma musi mieć od 3 do 40 znaków", "Niepoprawna firma!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
                if (LocationTxt.Text.Length < 3 || LocationTxt.Text.Length > 40)
                {
                    MessageBox.Show("Lokalizacja muszą mieć od 3 do 40 znaków", "Niepoprawna lokalizacja!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
                if (WorkdaysTxt.Text.Length < 3 || WorkdaysTxt.Text.Length > 40)
                {
                    MessageBox.Show("Dni pracy muszą mieć od 3 do 40 znaków", "Niepoprawne dni pracy!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
                if (WorkHoursTxt.Text.Length < 0 || WorkHoursTxt.Text.Length > 40)
                {
                    MessageBox.Show("Godziny pracy muszą mieć od 1 do 40 znaków", "Niepoprawne godziny pracy !", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
                if (ResponsibilitiesTxt.Text.Length < 3 || ResponsibilitiesTxt.Text.Length > 100)
                {
                    MessageBox.Show("Zakres obowiązków muszą mieć od 3 do 100 znaków", "Niepoprawny zakres obowiązków!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
                if (BenefitsTxt.Text.Length < 3 || BenefitsTxt.Text.Length > 100)
                {
                    MessageBox.Show("Benefity muszą mieć od 3 do 100 znaków", "Niepoprawne benefity!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
                if (AboutCompanyTxt.Text.Length < 3 || AboutCompanyTxt.Text.Length > 100)
                {
                    MessageBox.Show("O firmie musi mieć od 3 do 100 znaków", "Niepoprawne o firmie!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
                if (!(SalaryTxt.Text.All(char.IsDigit)) ||SalaryTxt.Text.Length < 3 || SalaryTxt.Text.Length > 40)
                {
                    MessageBox.Show("Płaca musi mieć od 3 do 40 znaków i może zawierać tylko liczby", "Niepoprawna płaca!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
            }
            if (success)
            {
                var offers = new Offers(PositionNameTxt.Text, CompanyPhotoTxt.Text, CompanyTxt.Text, LocationTxt.Text, PositionLevelCmb.Text, ContractTypeCmb.Text, WorkdaysTxt.Text, WorkHoursTxt.Text, ExpirationDate.SelectedDate?.Date ?? DateTime.MinValue, CategoryCmb.Text, ResponsibilitiesTxt.Text, RequirementsTxt.Text, BenefitsTxt.Text, AboutCompanyTxt.Text, TenureCmb.Text, WorkModeCmb.Text, SalaryTxt.Text);
                DataBase.AddOffers(offers);

                AdminWindow adminWindow = new AdminWindow();
                adminWindow.Show();
                this.Close();
            }
        }
        private void EditOffer_Click(object sender, RoutedEventArgs e)
        {
            bool success = true;
            if (string.IsNullOrWhiteSpace(PositionNameTxt.Text) || string.IsNullOrWhiteSpace(CompanyPhotoTxt.Text) || string.IsNullOrWhiteSpace(CompanyTxt.Text)
               || string.IsNullOrWhiteSpace(LocationTxt.Text) || string.IsNullOrWhiteSpace(WorkdaysTxt.Text) || string.IsNullOrWhiteSpace(WorkHoursTxt.Text)
               || string.IsNullOrWhiteSpace(ResponsibilitiesTxt.Text) || string.IsNullOrWhiteSpace(RequirementsTxt.Text) || string.IsNullOrWhiteSpace(BenefitsTxt.Text)
               || string.IsNullOrWhiteSpace(AboutCompanyTxt.Text) || string.IsNullOrWhiteSpace(SalaryTxt.Text))
            {
                MessageBox.Show("Uzupełnij wszystkie pola!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Information);
                success = false;
            }
            else
            {
                if (PositionNameTxt.Text.Length < 3 || PositionNameTxt.Text.Length > 40)
                {
                    MessageBox.Show("Stanowisko musi mieć od 3 do 40 znaków", "Niepoprawne stanowisko!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
                if (CompanyPhotoTxt.Text.Length < 3 || CompanyPhotoTxt.Text.Length > 1000)
                {
                    MessageBox.Show("Zdjęcie firmy musi mieć od 3 do 1000 znaków", "Niepoprawne zdjęcie firmy!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
                if (CompanyTxt.Text.Length < 3 || CompanyTxt.Text.Length > 40)
                {
                    MessageBox.Show("Firma musi mieć od 3 do 40 znaków", "Niepoprawna firma!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
                if (LocationTxt.Text.Length < 3 || LocationTxt.Text.Length > 40)
                {
                    MessageBox.Show("Lokalizacja muszą mieć od 3 do 40 znaków", "Niepoprawna lokalizacja!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
                if (WorkdaysTxt.Text.Length < 3 || WorkdaysTxt.Text.Length > 40)
                {
                    MessageBox.Show("Dni pracy muszą mieć od 3 do 40 znaków", "Niepoprawne dni pracy!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
                if (WorkHoursTxt.Text.Length < 0 || WorkHoursTxt.Text.Length > 40)
                {
                    MessageBox.Show("Godziny pracy muszą mieć od 1 do 40 znaków", "Niepoprawne godziny pracy !", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
                if (ResponsibilitiesTxt.Text.Length < 3 || ResponsibilitiesTxt.Text.Length > 100)
                {
                    MessageBox.Show("Zakres obowiązków muszą mieć od 3 do 100 znaków", "Niepoprawny zakres obowiązków!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
                if (BenefitsTxt.Text.Length < 3 || BenefitsTxt.Text.Length > 100)
                {
                    MessageBox.Show("Benefity muszą mieć od 3 do 100 znaków", "Niepoprawne benefity!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
                if (AboutCompanyTxt.Text.Length < 3 || AboutCompanyTxt.Text.Length > 100)
                {
                    MessageBox.Show("O firmie musi mieć od 3 do 100 znaków", "Niepoprawne o firmie!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
                if (!(SalaryTxt.Text.All(char.IsDigit)) || SalaryTxt.Text.Length < 3 || SalaryTxt.Text.Length > 40)
                {
                    MessageBox.Show("Płaca musi mieć od 3 do 40 znaków i może zawierać tylko liczby", "Niepoprawna płaca!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
            }
            if (success)
            {
                var offers = new Offers(PositionNameTxt.Text, CompanyPhotoTxt.Text, CompanyTxt.Text, LocationTxt.Text, PositionLevelCmb.Text, ContractTypeCmb.Text, WorkdaysTxt.Text, WorkHoursTxt.Text, ExpirationDate.SelectedDate?.Date ?? DateTime.MinValue, CategoryCmb.Text, ResponsibilitiesTxt.Text, RequirementsTxt.Text, BenefitsTxt.Text, AboutCompanyTxt.Text, TenureCmb.Text, WorkModeCmb.Text, SalaryTxt.Text);
                DataBase.UpdateOffers(offers, ID);

                AdminWindow adminWindow = new AdminWindow();
                adminWindow.Show();
                this.Close();
            }
        }

        private void BackToAdminPanelBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
            this.Close();
        }
    }
}
