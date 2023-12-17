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
    /// Logika interakcji dla klasy ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        private static List<BasicInformations> basicInformations = new List<BasicInformations>();
        private static List<WorkExperience> workExperiences = new List<WorkExperience>();
        private static List<Education> educations = new List<Education>();
        private static List<Language> languages = new List<Language>();
        private static List<Courses> courses = new List<Courses>();
        private static List<UserOffers> userOffers = new List<UserOffers>();
        private int ID = App.LoggedUser.Id;
        public ProfileWindow()
        {
            InitializeComponent();
            WelcomeLbl.Content = "Witaj " + App.LoggedUser.Login + "!";

            refreshBasicInformations();
            refreshWorkExperience();
            refreshEducation();
            refreshLanguages();
            refreshCourses();
            refreshUserOffers();
            if (App.LoggedUser.Login == "admin")
            {
                if (AdminPanel.Children.Count == 0)
                {
                    Button AdminButton = new Button();
                    AdminButton.Content = "Admin Panel";
                    AdminButton.Name = "AdminBtn";
                    AdminButton.Height = 50;
                    AdminButton.Width = 200;
                    Color kolor = (Color)ColorConverter.ConvertFromString("#7776BC");
                    AdminButton.Foreground = new SolidColorBrush(kolor);
                    AdminButton.HorizontalAlignment = HorizontalAlignment.Left;
                    AdminButton.VerticalAlignment = VerticalAlignment.Center;
                    AdminButton.Background = Brushes.WhiteSmoke;
                    AdminButton.FontSize = 15;
                    AdminButton.FontWeight = FontWeights.UltraBold;
                    AdminButton.Margin = new Thickness(5);
                    AdminButton.BorderThickness = new Thickness(5);
                    Color kolor2 = (Color)ColorConverter.ConvertFromString("#7776BC");
                    AdminButton.BorderBrush = new SolidColorBrush(kolor2);

                    AdminPanel.Children.Add(AdminButton);
                    AdminButton.Click += AdminPanelBtn_Click;
                }
            }
        }
        public void refreshUserOffers()
        {
            userOffers = DataBase.WriteUserOffers(ID);
            OffersControl.ItemsSource = userOffers;
        }
        public void refreshCourses()
        {
            courses = DataBase.WriteCourse(ID);
            CoursesList.ItemsSource = courses;
        }
        public void refreshLanguages()
        {
            languages = DataBase.WriteLanguage(ID);
            LanguagesList.ItemsSource = languages;
        }
        public void refreshEducation()
        {
            educations = DataBase.WriteEducation(ID);
            EducationList.ItemsSource = educations;
        }
        public void refreshWorkExperience()
        {
            workExperiences = DataBase.WriteWorkExperience(ID);
            WorkExperienceList.ItemsSource = workExperiences;
        }
        public void refreshBasicInformations()
        {
            List<BasicInformations> basicInfoList = DataBase.WriteBasicInformations(ID);

            if (basicInfoList.Count > 0)
            {
                BasicInformations userBasicInfo = basicInfoList[0]; // Zakładam, że dla jednego użytkownika masz tylko jedną informację podstawową

                // Przypisz dane do odpowiednich pól
                Dispatcher.Invoke(() =>
                {
                    NameTxt.Text = userBasicInfo.Name;
                    SurnameTxt.Text = userBasicInfo.Surname;
                    DateTxt.Text = userBasicInfo.BirthDate.ToString("dd/MM/yyyy");
                    EmailTxt.Text = userBasicInfo.Email;
                    PhoneNumberTxt.Text = userBasicInfo.PhoneNumber;
                    ProfilePicture.Source = new BitmapImage(new Uri(userBasicInfo.ProfilePicture, UriKind.RelativeOrAbsolute));
                    ResidenceTxt.Text = userBasicInfo.Residence;
                });

            }
            basicInformations = DataBase.WriteBasicInformations(ID);
            if (!string.IsNullOrWhiteSpace(NameTxt.Text))
            {
                AddBasicInformationBtn.Visibility = Visibility.Collapsed;
                UpdateBasicInformationBtn.Margin = new Thickness(205, 5, 5, 5);
            }
        }
        private void BackToMainPageBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        private void AdminPanelBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
            this.Close();
        }

        private void GoToAdvertisementsBtn_Click(object sender, RoutedEventArgs e)
        {
            OffersWindow offersWindow = new OffersWindow();
            offersWindow.Show();
            this.Close();
        }

        private void UpdateBasicInformationBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditBasicInformation addEditBasicInformation = new AddEditBasicInformation(basicInformations,ID);
            addEditBasicInformation.Show();
            this.Close();
        }

        private void AddBasicInformationBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditBasicInformation addEditBasicInformation = new AddEditBasicInformation(basicInformations);
            addEditBasicInformation.Show();
            this.Close();
        }

        private void AddWorkExperienceBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditWorkExperience addEditWorkExperience = new AddEditWorkExperience(workExperiences);
            addEditWorkExperience.Show();
            this.Close();
        }

        private void EditWorkExperienceBtn_Click(object sender, RoutedEventArgs e)
        {
            if(WorkExperienceList.SelectedItem != null)
            {
                WorkExperience workExperience = WorkExperienceList.SelectedItem as WorkExperience;
                AddEditWorkExperience addEditWorkExperience = new AddEditWorkExperience(workExperience, workExperience.ID);
                addEditWorkExperience.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Musisz wybrać z listy doświadczenie zawodowe, które chcesz edytować ", "Nie wybrano z listy!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void DeleteWorkExperienceBtn_Click(object sender, RoutedEventArgs e)
        {
            if (WorkExperienceList.SelectedItem != null)
            {
                WorkExperience workExperience = WorkExperienceList.SelectedItem as WorkExperience;
                var rezultat = MessageBox.Show("Czy chcesz usunąć stanowisko " + workExperience.Position + "?", "Usuwanie", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (rezultat == MessageBoxResult.Yes)
                {
                    DataBase.DeleteWorkExperience(workExperience.ID);
                    refreshWorkExperience();
                }
            }
            else
            {
                MessageBox.Show("Musisz wybrać z listy doświadczenie zawodowe, które chcesz usunąć ", "Nie wybrano z listy!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void AddEducationBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditEducation addEditEducation = new AddEditEducation(educations);
            addEditEducation.Show();
            this.Close();
        }

        private void EditEducationBtn_Click(object sender, RoutedEventArgs e)
        {
            if (EducationList.SelectedItem != null)
            {
                Education education = EducationList.SelectedItem as Education;
                AddEditEducation addEditEducation = new AddEditEducation(education, education.ID);
                addEditEducation .Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Musisz wybrać z listy wykształcenie które chcesz edytować ", "Nie wybrano z listy!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void DeleteEducationBtn_Click(object sender, RoutedEventArgs e)
        {
            if (EducationList.SelectedItem != null)
            {
                Education education = EducationList.SelectedItem as Education;
                var rezultat = MessageBox.Show("Czy chcesz usunąć szkołe " + education.SchoolName + "?", "Usuwanie", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (rezultat == MessageBoxResult.Yes)
                {
                    DataBase.DeleteEducation(education.ID);
                    refreshEducation();
                }
            }
            else
            {
                MessageBox.Show("Musisz wybrać z listy wykształcenie, które chcesz usunąć ", "Nie wybrano z listy!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void AddLanguageBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditLanguages addEditLanguages = new AddEditLanguages(languages);
            addEditLanguages.Show();
            this.Close();
        }

        private void EditLanguageBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LanguagesList.SelectedItem != null)
            {
                Language language = LanguagesList.SelectedItem as Language;
                AddEditLanguages addEditLanguages = new AddEditLanguages(language, language.ID);
                addEditLanguages.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Musisz wybrać z listy język które chcesz edytować ", "Nie wybrano z listy!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void DeleteLanguageBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LanguagesList.SelectedItem != null)
            {
                Language language = LanguagesList.SelectedItem as Language;
                var rezultat = MessageBox.Show("Czy chcesz usunąć język " + language.Languages + "?", "Usuwanie", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (rezultat == MessageBoxResult.Yes)
                {
                    DataBase.DeleteLanguage(language.ID);
                    refreshLanguages();
                }
            }
            else
            {
                MessageBox.Show("Musisz wybrać z listy język, który chcesz usunąć ", "Nie wybrano z listy!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void AddCoursesBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditCourses addEditCourses = new AddEditCourses(courses);
            addEditCourses.Show();
            this.Close();
        }
        private void EditCoursesBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CoursesList.SelectedItem != null)
            {
                Courses courses = CoursesList.SelectedItem as Courses;
                AddEditCourses addEditCourses = new AddEditCourses(courses, courses.ID);
                addEditCourses.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Musisz wybrać z listy kurs/szkolenie które chcesz edytować ", "Nie wybrano z listy!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void DeleteCoursesBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CoursesList.SelectedItem != null)
            {
                Courses courses = CoursesList.SelectedItem as Courses;
                var rezultat = MessageBox.Show("Czy chcesz usunąć kurs " + courses.TrainingName + "?", "Usuwanie", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (rezultat == MessageBoxResult.Yes)
                {
                    DataBase.DeleteCourse(courses.ID);
                    refreshCourses();
                }
            }
            else
            {
                MessageBox.Show("Musisz wybrać z listy kurs/szkolenie, który chcesz usunąć ", "Nie wybrano z listy!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void GoToOfferDetails(object sender, RoutedEventArgs e)
        {
            var offers = ((Button)sender).CommandParameter as UserOffers;
            OfferDetailsPage offer = new OfferDetailsPage(offers);
            offer.Show();
            this.Close();
        }

        private void StopCandidate_Click(object sender, RoutedEventArgs e)
        {
            var id = (((Button)sender).CommandParameter as UserOffers).ID;
            DataBase.DeleteUserOffers(id);
            refreshUserOffers();
        }
    }
}
