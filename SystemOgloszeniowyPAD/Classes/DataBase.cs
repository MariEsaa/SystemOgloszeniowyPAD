using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace SystemOgloszeniowyPAD.Classes
{
    public class DataBase
    {
        public async static void Connection()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AdvertisementSystemDataBase.db");
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("CREATE TABLE IF NOT EXISTS Users(ID INTEGER PRIMARY KEY AUTOINCREMENT, Login VARCHAR(50), Password VARCHAR(50))", connection);
            query.ExecuteReader();
            var query2 = new SqliteCommand("CREATE TABLE IF NOT EXISTS BasicInformations(ID INTEGER PRIMARY KEY AUTOINCREMENT,UserID INT, Name VARCHAR(40), Surname VARCHAR(40),BirthDate DATE,Email VARCHAR(50),PhoneNumber VARCHAR(9), ProfilePicture VARCHAR(1000), Residence VARCHAR(50))", connection);
            query2.ExecuteReader();
            var query3 = new SqliteCommand("CREATE TABLE IF NOT EXISTS WorkExperience(ID INTEGER PRIMARY KEY AUTOINCREMENT,UserID INT, Position VARCHAR(40), CompanyName VARCHAR(40),Location VARCHAR(50),PeriodOfEmploymentFrom DATE,PeriodOfEmploymentTo DATE, Responsibilities VARCHAR(50))", connection);
            query3.ExecuteReader();
            var query4 = new SqliteCommand("CREATE TABLE IF NOT EXISTS Education(ID INTEGER PRIMARY KEY AUTOINCREMENT,UserID INT, SchoolName VARCHAR(40), Location VARCHAR(40),EducationLevel VARCHAR(50), Direction VARCHAR(50),PeriodFrom DATE,PeriodTo DATE)", connection);
            query4.ExecuteReader(); 
            var query5 = new SqliteCommand("CREATE TABLE IF NOT EXISTS Languages(ID INTEGER PRIMARY KEY AUTOINCREMENT,UserID INT, Languages VARCHAR(40), LanguageLevel VARCHAR(40))", connection);
            query5.ExecuteReader();
            var query6 = new SqliteCommand("CREATE TABLE IF NOT EXISTS Courses(ID INTEGER PRIMARY KEY AUTOINCREMENT,UserID INT, TrainingName VARCHAR(40), Organiser VARCHAR(40),PeriodFrom DATE,PeriodTo DATE)", connection);
            query6.ExecuteReader();
            var query7 = new SqliteCommand("CREATE TABLE IF NOT EXISTS Offers(ID INTEGER PRIMARY KEY AUTOINCREMENT, PositionName VARCHAR(40), CompanyPhoto VARCHAR(1000),Company VARCHAR(40),Location VARCHAR(40),PositionLevel VARCHAR(40),ContractType VARCHAR(40),Workdays VARCHAR(40),WorkHours VARCHAR(40),ExpirationDate DATE,Category VARCHAR(40),Responsibilities VARCHAR(100),Requirements VARCHAR(100),Benefits VARCHAR(100),AboutCompany VARCHAR(100),Tenure VARCHAR(40),WorkMode VARCHAR(40),Salary VARCHAR(40))", connection);
            query7.ExecuteReader();
            var query8 = new SqliteCommand("CREATE TABLE IF NOT EXISTS UserOffers(ID INTEGER PRIMARY KEY AUTOINCREMENT, UserID INT, OfferID INT, PositionName VARCHAR(40), CompanyPhoto VARCHAR(1000),Company VARCHAR(40),Location VARCHAR(40),PositionLevel VARCHAR(40),ContractType VARCHAR(40),Workdays VARCHAR(40),WorkHours VARCHAR(40),ExpirationDate DATE,Category VARCHAR(40),Responsibilities VARCHAR(100),Requirements VARCHAR(100),Benefits VARCHAR(100),AboutCompany VARCHAR(100),Tenure VARCHAR(40),WorkMode VARCHAR(40),Salary VARCHAR(40))", connection);
            query8.ExecuteReader();
        }
        public static void AddUser(User user)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AdvertisementSystemDataBase.db");
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("INSERT INTO Users(Login,Password) VALUES(@Login, @Password)", connection);
            query.Parameters.AddWithValue("@Login", user.Login);
            query.Parameters.AddWithValue("@Password", user.Password);
            query.ExecuteReader();
        }
        public static List<User> WriteUsers()
        {
            List<User> list = new List<User>();
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AdvertisementSystemDataBase.db");
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("SELECT * FROM Users", connection);
            SqliteDataReader read = query.ExecuteReader();
            while (read.Read())
            {
                User user = new User(read.GetInt32(0), read.GetString(1), read.GetString(2));
                list.Add(user);
            }
            return list;
        }
        public static void AddBasicInformations(BasicInformations basicInformations)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AdvertisementSystemDataBase.db");
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("INSERT INTO BasicInformations(UserID,Name,Surname,BirthDate,Email,PhoneNumber,ProfilePicture,Residence) VALUES(@UserID, @Name, @Surname, @BirthDate, @Email,@PhoneNumber,@ProfilePicture,@Residence)", connection);
            query.Parameters.AddWithValue("@UserID",basicInformations.UserId);
            query.Parameters.AddWithValue("@Name", basicInformations.Name);
            query.Parameters.AddWithValue("@Surname", basicInformations.Surname);
            query.Parameters.AddWithValue("@BirthDate", basicInformations.BirthDate);
            query.Parameters.AddWithValue("@Email", basicInformations.Email);
            query.Parameters.AddWithValue("@PhoneNumber", basicInformations.PhoneNumber);
            query.Parameters.AddWithValue("@ProfilePicture", basicInformations.ProfilePicture);
            query.Parameters.AddWithValue("@Residence", basicInformations.Residence);
            query.ExecuteReader();
        }
        public static void UpdateBasicInformations(BasicInformations basicInformations, int id)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AdvertisementSystemDataBase.db");
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("UPDATE BasicInformations SET UserID = @UserID, Name = @Name, Surname = @Surname, BirthDate = @BirthDate, Email = @Email, PhoneNumber = @PhoneNumber, ProfilePicture = @ProfilePicture, Residence = @Residence  WHERE UserID = @ID", connection);
            query.Parameters.AddWithValue("@UserID", basicInformations.UserId);
            query.Parameters.AddWithValue("@Name", basicInformations.Name);
            query.Parameters.AddWithValue("@Surname", basicInformations.Surname);
            query.Parameters.AddWithValue("@BirthDate", basicInformations.BirthDate);
            query.Parameters.AddWithValue("@Email", basicInformations.Email);
            query.Parameters.AddWithValue("@PhoneNumber", basicInformations.PhoneNumber);
            query.Parameters.AddWithValue("@ProfilePicture", basicInformations.ProfilePicture);
            query.Parameters.AddWithValue("@Residence", basicInformations.Residence);
            query.Parameters.AddWithValue("@ID", id);
            query.ExecuteReader();
        }
        public static List<BasicInformations> WriteBasicInformations(int id)
        {
            List<BasicInformations> list = new List<BasicInformations>();
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AdvertisementSystemDataBase.db");
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("SELECT * FROM BasicInformations WHERE UserID=@ID", connection);
            query.Parameters.AddWithValue("@ID", id);
            SqliteDataReader read = query.ExecuteReader();
            while (read.Read())
            {
                BasicInformations basicInformations = new BasicInformations(read.GetInt32(1),read.GetString(2),read.GetString(3),read.GetDateTime(4),read.GetString(5),read.GetString(6),read.GetString(7),read.GetString(8));
                list.Add(basicInformations);
            }
            return list;
        }
        public static void AddWorkExperience(WorkExperience workExperience)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AdvertisementSystemDataBase.db");
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("INSERT INTO WorkExperience(UserID,Position,CompanyName,Location,PeriodOfEmploymentFrom,PeriodOfEmploymentTo,Responsibilities) VALUES(@UserID, @Position, @CompanynName, @Location, @PeriodOfEmploymentFrom,@PeriodOfEmploymentTo,@Responsibilities)", connection);
            query.Parameters.AddWithValue("@UserID", workExperience.UserId);
            query.Parameters.AddWithValue("@Position", workExperience.Position);
            query.Parameters.AddWithValue("@CompanynName", workExperience.CompanyName);
            query.Parameters.AddWithValue("@Location", workExperience.Location);
            query.Parameters.AddWithValue("@PeriodOfEmploymentFrom", workExperience.PeriodOfEmploymentFrom);
            query.Parameters.AddWithValue("@PeriodOfEmploymentTo", workExperience.PeriodOfEmploymentTo);
            query.Parameters.AddWithValue("@Responsibilities", workExperience.Responsibilities);
            query.ExecuteReader();
        }
        public static void UpdateWorkExperience(WorkExperience workExperience, int id)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AdvertisementSystemDataBase.db");
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("UPDATE WorkExperience SET UserID = @UserID, Position = @Position, CompanyName = @CompanynName, Location = @Location, PeriodOfEmploymentFrom = @PeriodOfEmploymentFrom, PeriodOfEmploymentTo = @PeriodOfEmploymentTo, Responsibilities = @Responsibilities WHERE ID = @ID", connection);
            query.Parameters.AddWithValue("@UserID", workExperience.UserId);
            query.Parameters.AddWithValue("@Position", workExperience.Position);
            query.Parameters.AddWithValue("@CompanynName", workExperience.CompanyName);
            query.Parameters.AddWithValue("@Location", workExperience.Location);
            query.Parameters.AddWithValue("@PeriodOfEmploymentFrom", workExperience.PeriodOfEmploymentFrom);
            query.Parameters.AddWithValue("@PeriodOfEmploymentTo", workExperience.PeriodOfEmploymentTo);
            query.Parameters.AddWithValue("@Responsibilities", workExperience.Responsibilities);
            query.Parameters.AddWithValue("@ID", id);
            query.ExecuteReader();
        }
        public static void DeleteWorkExperience(int id)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AdvertisementSystemDataBase.db");
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("DELETE FROM WorkExperience WHERE ID=@ID", connection);
            query.Parameters.AddWithValue("@ID", id);
            query.ExecuteReader();
        }
        public static List<WorkExperience> WriteWorkExperience(int id)
        {
            List<WorkExperience> list = new List<WorkExperience>();
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AdvertisementSystemDataBase.db");
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("SELECT * FROM WorkExperience WHERE UserID=@ID", connection);
            query.Parameters.AddWithValue("@ID", id);
            SqliteDataReader read = query.ExecuteReader();
            while (read.Read())
            {
                WorkExperience workExperience = new WorkExperience(read.GetInt32(0), read.GetInt32(1), read.GetString(2), read.GetString(3), read.GetString(4), read.GetDateTime(5), read.GetDateTime(6), read.GetString(7));
                list.Add(workExperience);
            }
            return list;
        }
        public static void AddEducation(Education education)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AdvertisementSystemDataBase.db");
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("INSERT INTO Education(UserID,SchoolName,Location,EducationLevel,Direction,PeriodFrom,PeriodTo) VALUES(@UserID, @SchoolName, @Location, @EducationLevel, @Direction,@PeriodFrom,@PeriodTo)", connection);
            query.Parameters.AddWithValue("@UserID", education.UserId);
            query.Parameters.AddWithValue("@SchoolName", education.SchoolName);
            query.Parameters.AddWithValue("@Location", education.Location);
            query.Parameters.AddWithValue("@EducationLevel", education.EducationLevel);
            query.Parameters.AddWithValue("@Direction", education.Direction);
            query.Parameters.AddWithValue("@PeriodFrom", education.PeriodFrom);
            query.Parameters.AddWithValue("@PeriodTo", education.PeriodTo);
            query.ExecuteReader();
        }
        public static void UpdateEducation(Education education, int id)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AdvertisementSystemDataBase.db");
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("UPDATE Education SET UserID = @UserID, SchoolName = @SchoolName, Location = @Location, EducationLevel = @EducationLevel, Direction = @Direction, PeriodFrom = @PeriodFrom, PeriodTo = @PeriodTo WHERE ID = @ID", connection);
            query.Parameters.AddWithValue("@UserID", education.UserId);
            query.Parameters.AddWithValue("@SchoolName", education.SchoolName);
            query.Parameters.AddWithValue("@Location", education.Location);
            query.Parameters.AddWithValue("@EducationLevel", education.EducationLevel);
            query.Parameters.AddWithValue("@Direction", education.Direction);
            query.Parameters.AddWithValue("@PeriodFrom", education.PeriodFrom);
            query.Parameters.AddWithValue("@PeriodTo", education.PeriodTo);
            query.Parameters.AddWithValue("@ID", id);
            query.ExecuteReader();
        }
        public static void DeleteEducation(int id)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AdvertisementSystemDataBase.db");
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("DELETE FROM Education WHERE ID=@ID", connection);
            query.Parameters.AddWithValue("@ID", id);
            query.ExecuteReader();
        }
        public static List<Education> WriteEducation(int id)
        {
            List<Education> list = new List<Education>();
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AdvertisementSystemDataBase.db");
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("SELECT * FROM Education WHERE UserID=@ID", connection);
            query.Parameters.AddWithValue("@ID", id);
            SqliteDataReader read = query.ExecuteReader();
            while (read.Read())
            {
                Education education = new Education(read.GetInt32(0),read.GetInt32(1),read.GetString(2),read.GetString(3),read.GetString(4),read.GetString(5),read.GetDateTime(6),read.GetDateTime(7));
                list.Add(education);
            }
            return list;
        }
        public static void AddLanguage(Language language)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AdvertisementSystemDataBase.db");
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("INSERT INTO Languages(UserID,Languages,LanguageLevel) VALUES(@UserID, @Languages, @LanguageLevel)", connection);
            query.Parameters.AddWithValue("@UserID", language.UserId);
            query.Parameters.AddWithValue("@Languages", language.Languages);
            query.Parameters.AddWithValue("@LanguageLevel", language.LanguageLevel);
            query.ExecuteReader();
        }
        public static void UpdateLanguage(Language language, int id)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AdvertisementSystemDataBase.db");
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("UPDATE Languages SET UserID = @UserID, Languages = @Languages, LanguageLevel = @LanguageLevel WHERE ID = @ID", connection);
            query.Parameters.AddWithValue("@UserID", language.UserId);
            query.Parameters.AddWithValue("@Languages", language.Languages);
            query.Parameters.AddWithValue("@LanguageLevel", language.LanguageLevel);
            query.Parameters.AddWithValue("@ID", id);
            query.ExecuteReader();
        }
        public static void DeleteLanguage(int id)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AdvertisementSystemDataBase.db");
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("DELETE FROM Languages WHERE ID=@ID", connection);
            query.Parameters.AddWithValue("@ID", id);
            query.ExecuteReader();
        }
        public static List<Language> WriteLanguage(int id)
        {
            List<Language> list = new List<Language>();
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AdvertisementSystemDataBase.db");
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("SELECT * FROM Languages WHERE UserID=@ID", connection);
            query.Parameters.AddWithValue("@ID", id);
            SqliteDataReader read = query.ExecuteReader();
            while (read.Read())
            {
                Language language = new Language(read.GetInt32(0),read.GetInt32(1),read.GetString(2),read.GetString(3));
                list.Add(language);
            }
            return list;
        }
        public static void AddCourse(Courses courses)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AdvertisementSystemDataBase.db");
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("INSERT INTO Courses(UserID,TrainingName,Organiser,PeriodFrom,PeriodTo) VALUES(@UserID, @TrainingName, @Organiser, @PeriodFrom, @PeriodTo)", connection);
            query.Parameters.AddWithValue("@UserID", courses.UserId);
            query.Parameters.AddWithValue("@TrainingName", courses.TrainingName);
            query.Parameters.AddWithValue("@Organiser", courses.Organiser);
            query.Parameters.AddWithValue("@PeriodFrom", courses.PeriodFrom);
            query.Parameters.AddWithValue("@PeriodTo", courses.PeriodTo);
            query.ExecuteReader();
        }
        public static void UpdateCourse(Courses courses, int id)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AdvertisementSystemDataBase.db");
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("UPDATE Courses SET UserID = @UserID, TrainingName = @TrainingName, Organiser = @Organiser, PeriodFrom = @PeriodFrom, PeriodTo = @PeriodTo WHERE ID = @ID", connection);
            query.Parameters.AddWithValue("@UserID", courses.UserId);
            query.Parameters.AddWithValue("@TrainingName", courses.TrainingName);
            query.Parameters.AddWithValue("@Organiser", courses.Organiser);
            query.Parameters.AddWithValue("@PeriodFrom", courses.PeriodFrom);
            query.Parameters.AddWithValue("@PeriodTo", courses.PeriodTo);
            query.Parameters.AddWithValue("@ID", id);
            query.ExecuteReader();
        }
        public static void DeleteCourse(int id)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AdvertisementSystemDataBase.db");
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("DELETE FROM Courses WHERE ID=@ID", connection);
            query.Parameters.AddWithValue("@ID", id);
            query.ExecuteReader();
        }
        public static List<Courses> WriteCourse(int id)
        {
            List<Courses> list = new List<Courses>();
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AdvertisementSystemDataBase.db");
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("SELECT * FROM Courses WHERE UserID=@ID", connection);
            query.Parameters.AddWithValue("@ID", id);
            SqliteDataReader read = query.ExecuteReader();
            while (read.Read())
            {
                Courses courses = new Courses(read.GetInt32(0),read.GetInt32(1),read.GetString(2),read.GetString(3),read.GetDateTime(4),read.GetDateTime(5));
                list.Add(courses);
            }
            return list;
        }
        public static void AddOffers(Offers offers)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AdvertisementSystemDataBase.db");
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("INSERT INTO Offers(PositionName,CompanyPhoto,Company,Location,PositionLevel,ContractType,Workdays,WorkHours,ExpirationDate,Category,Responsibilities,Requirements,Benefits,AboutCompany,Tenure,WorkMode,Salary) VALUES(@PositionName, @CompanyPhoto, @Company, @Location, @PositionLevel, @ContractType, @Workdays, @WorkHours, @ExpirationDate, @Category, @Responsibilities, @Requirements, @Benefits, @AboutCompany, @Tenure, @WorkMode, @Salary)", connection);
            query.Parameters.AddWithValue("@PositionName", offers.PositionName);
            query.Parameters.AddWithValue("@CompanyPhoto", offers.CompanyPhoto);
            query.Parameters.AddWithValue("@Company", offers.Company);
            query.Parameters.AddWithValue("@Location", offers.Location);
            query.Parameters.AddWithValue("@PositionLevel", offers.PositionLevel);
            query.Parameters.AddWithValue("@ContractType", offers.ContractType);
            query.Parameters.AddWithValue("@Workdays", offers.Workdays);
            query.Parameters.AddWithValue("@WorkHours", offers.WorkHours);
            query.Parameters.AddWithValue("@ExpirationDate", offers.ExpirationDate);
            query.Parameters.AddWithValue("@Category", offers.Category);
            query.Parameters.AddWithValue("@Responsibilities", offers.Responsibilities);
            query.Parameters.AddWithValue("@Requirements", offers.Requirements);
            query.Parameters.AddWithValue("@Benefits", offers.Benefits);
            query.Parameters.AddWithValue("@AboutCompany", offers.AboutCompany);
            query.Parameters.AddWithValue("@Tenure", offers.Tenure);
            query.Parameters.AddWithValue("@WorkMode", offers.WorkMode);
            query.Parameters.AddWithValue("@Salary", offers.Salary);
            query.ExecuteReader();
        }
        public static void UpdateOffers(Offers offers, int id)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AdvertisementSystemDataBase.db");
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("UPDATE Offers SET PositionName = @PositionName, CompanyPhoto = @CompanyPhoto, Company = @Company, Location = @Location, PositionLevel = @PositionLevel, ContractType = @ContractType, Workdays = @Workdays, WorkHours = @WorkHours, ExpirationDate = @ExpirationDate, Category = @Category, Responsibilities = @Responsibilities, Requirements = @Requirements, Benefits = @Benefits, AboutCompany = @AboutCompany, Tenure = @Tenure, WorkMode = @WorkMode, Salary = @Salary WHERE ID = @ID", connection);
            query.Parameters.AddWithValue("@PositionName", offers.PositionName);
            query.Parameters.AddWithValue("@CompanyPhoto", offers.CompanyPhoto);
            query.Parameters.AddWithValue("@Company", offers.Company);
            query.Parameters.AddWithValue("@Location", offers.Location);
            query.Parameters.AddWithValue("@PositionLevel", offers.PositionLevel);
            query.Parameters.AddWithValue("@ContractType", offers.ContractType);
            query.Parameters.AddWithValue("@Workdays", offers.Workdays);
            query.Parameters.AddWithValue("@WorkHours", offers.WorkHours);
            query.Parameters.AddWithValue("@ExpirationDate", offers.ExpirationDate);
            query.Parameters.AddWithValue("@Category", offers.Category);
            query.Parameters.AddWithValue("@Responsibilities", offers.Responsibilities);
            query.Parameters.AddWithValue("@Requirements", offers.Requirements);
            query.Parameters.AddWithValue("@Benefits", offers.Benefits  );
            query.Parameters.AddWithValue("@AboutCompany", offers.AboutCompany);
            query.Parameters.AddWithValue("@Tenure", offers.Tenure);
            query.Parameters.AddWithValue("@WorkMode", offers.WorkMode);
            query.Parameters.AddWithValue("@Salary", offers.Salary);
            query.Parameters.AddWithValue("@ID", id);
            query.ExecuteReader();
        }
        public static void DeleteOffers(int id)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AdvertisementSystemDataBase.db");
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("DELETE FROM Offers WHERE ID=@ID", connection);
            query.Parameters.AddWithValue("@ID", id);
            query.ExecuteReader();
        }
        public static List<Offers> WriteOffers()
        {
            List<Offers> list = new List<Offers>();
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AdvertisementSystemDataBase.db");
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("SELECT * FROM Offers", connection);
            SqliteDataReader read = query.ExecuteReader();
            while (read.Read())
            {
                Offers offers = new Offers(read.GetInt32(0),read.GetString(1),read.GetString(2),read.GetString(3),read.GetString(4),read.GetString(5),read.GetString(6),read.GetString(7),read.GetString(8),read.GetDateTime(9),read.GetString(10),read.GetString(11),read.GetString(12),read.GetString(13),read.GetString(14),read.GetString(15),read.GetString(16),read.GetString(17));
                list.Add(offers);
            }
            return list;
        }
        public static List<Offers> WriteNewOffers()
        {
            List<Offers> list = new List<Offers>();
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AdvertisementSystemDataBase.db");
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("SELECT* FROM Offers ORDER BY ID DESC LIMIT 5", connection);
            SqliteDataReader read = query.ExecuteReader();
            while (read.Read())
            {
                Offers offers = new Offers(read.GetInt32(0), read.GetString(1), read.GetString(2), read.GetString(3), read.GetString(4), read.GetString(5), read.GetString(6), read.GetString(7), read.GetString(8), read.GetDateTime(9), read.GetString(10), read.GetString(11), read.GetString(12), read.GetString(13), read.GetString(14), read.GetString(15), read.GetString(16), read.GetString(17));
                list.Add(offers);
            }
            return list;
        }
        public int GetNumberOfOffers()
        {
            int result = 0;
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AdvertisementSystemDataBase.db");

            using (var connection = new SqliteConnection($"Filename={dbPath}"))
            {
                connection.Open();
                var query = new SqliteCommand("SELECT COUNT(*) AS liczba_ofert FROM Offers", connection);

                using (var read = query.ExecuteReader())
                {
                    if (read.Read())
                    {
                        result = read.GetInt32(0);
                    }
                }
            }

            return result;
        }
        public static List<string> GetPositionName()
        {
            List<string> PositionName = new List<string>();
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AdvertisementSystemDataBase.db");
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("SELECT DISTINCT PositionName FROM Offers", connection);
            SqliteDataReader read = query.ExecuteReader();
            while (read.Read())
            {
                string positionName = read["PositionName"].ToString();
                PositionName.Add(positionName);
            }
            return PositionName;
        }
        public static List<string> GetCompany()
        {
            List<string> Company = new List<string>();
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AdvertisementSystemDataBase.db");
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("SELECT DISTINCT Company FROM Offers", connection);
            SqliteDataReader read = query.ExecuteReader();
            while (read.Read())
            {
                string company = read["Company"].ToString();
                Company.Add(company);
            }
            return Company;
        }
        public static List<string> GetLocation()
        {
            List<string> Location = new List<string>();
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AdvertisementSystemDataBase.db");
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("SELECT DISTINCT Location FROM Offers", connection);
            SqliteDataReader read = query.ExecuteReader();
            while (read.Read())
            {
                string location = read["Location"].ToString();
                Location.Add(location);
            }
            return Location;
        }
        public static List<Offers> SearchOffers(string PositionName, string Company, string Category, string Location, string PositionLevel, string ContractType, string Tenure, string WorkMode)
        {
            List<Offers> list = new List<Offers>();
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AdvertisementSystemDataBase.db");
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            string query = "SELECT * FROM Offers WHERE 1=1";
            if (!string.IsNullOrEmpty(PositionName))
                query += " AND PositionName = @PositionName";
            if (!string.IsNullOrEmpty(Company))
                query += " AND Company = @Company";
            if (!string.IsNullOrEmpty(Category))
                query += " AND Category = @Category";
            if (!string.IsNullOrEmpty(Location))
                query += " AND Location = @Location";
            if (!string.IsNullOrEmpty(PositionLevel))
                query += " AND Umowa = @PositionLevel";
            if (!string.IsNullOrEmpty(ContractType))
                query += " AND ContractType = @ContractType";
            if (!string.IsNullOrEmpty(WorkMode))
                query += " AND WorkMode = @WorkMode";

            SqliteCommand command = new SqliteCommand(query, connection);
            if (!string.IsNullOrEmpty(PositionName))
                command.Parameters.AddWithValue("@PositionName", PositionName);
            if (!string.IsNullOrEmpty(Company))
                command.Parameters.AddWithValue("@Company", Company);
            if (!string.IsNullOrEmpty(Category))
                command.Parameters.AddWithValue("@Category", Category);
            if (!string.IsNullOrEmpty(Location))
                command.Parameters.AddWithValue("@Location", Location);
            if (!string.IsNullOrEmpty(PositionLevel))
                command.Parameters.AddWithValue("@PositionLevel", PositionLevel);
            if (!string.IsNullOrEmpty(ContractType))
                command.Parameters.AddWithValue("@ContractType", ContractType);
            if (!string.IsNullOrEmpty(Tenure))
                command.Parameters.AddWithValue("@Tenure", Tenure);
            if (!string.IsNullOrEmpty(WorkMode))
                command.Parameters.AddWithValue("@WorkMode", WorkMode);
            SqliteDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                Offers offers = new Offers(read.GetInt32(0), read.GetString(1), read.GetString(2), read.GetString(3), read.GetString(4), read.GetString(5), read.GetString(6), read.GetString(7), read.GetString(8), read.GetDateTime(9), read.GetString(10), read.GetString(11), read.GetString(12), read.GetString(13), read.GetString(14), read.GetString(15), read.GetString(16), read.GetString(17));
                list.Add(offers);
            }
            return list;
        }
        public static void AddUserOffers(UserOffers userOffers)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AdvertisementSystemDataBase.db");
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("INSERT INTO UserOffers(UserID,OfferID,PositionName,CompanyPhoto,Company,Location,PositionLevel,ContractType,Workdays,WorkHours,ExpirationDate,Category,Responsibilities,Requirements,Benefits,AboutCompany,Tenure,WorkMode,Salary) VALUES(@UserID, @OfferID, @PositionName, @CompanyPhoto, @Company, @Location, @PositionLevel, @ContractType, @Workdays, @WorkHours, @ExpirationDate, @Category, @Responsibilities, @Requirements, @Benefits, @AboutCompany, @Tenure, @WorkMode, @Salary)", connection);
            query.Parameters.AddWithValue("@UserID", userOffers.UserID);
            query.Parameters.AddWithValue("@OfferID", userOffers.OfferID);
            query.Parameters.AddWithValue("@PositionName", userOffers.PositionName);
            query.Parameters.AddWithValue("@CompanyPhoto", userOffers.CompanyPhoto);
            query.Parameters.AddWithValue("@Company", userOffers.Company);
            query.Parameters.AddWithValue("@Location", userOffers.Location);
            query.Parameters.AddWithValue("@PositionLevel", userOffers.PositionLevel);
            query.Parameters.AddWithValue("@ContractType", userOffers.ContractType);
            query.Parameters.AddWithValue("@Workdays", userOffers.Workdays);
            query.Parameters.AddWithValue("@WorkHours", userOffers.WorkHours);
            query.Parameters.AddWithValue("@ExpirationDate", userOffers.ExpirationDate);
            query.Parameters.AddWithValue("@Category", userOffers.Category);
            query.Parameters.AddWithValue("@Responsibilities", userOffers.Responsibilities);
            query.Parameters.AddWithValue("@Requirements", userOffers.Requirements);
            query.Parameters.AddWithValue("@Benefits", userOffers.Benefits);
            query.Parameters.AddWithValue("@AboutCompany", userOffers.AboutCompany);
            query.Parameters.AddWithValue("@Tenure", userOffers.Tenure);
            query.Parameters.AddWithValue("@WorkMode", userOffers.WorkMode);
            query.Parameters.AddWithValue("@Salary", userOffers.Salary);
            query.ExecuteReader();
        }
        public static void DeleteUserOffers(int id)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AdvertisementSystemDataBase.db");
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("DELETE FROM UserOffers WHERE ID=@ID", connection);
            query.Parameters.AddWithValue("@ID", id);
            query.ExecuteReader();
        }
        public static List<UserOffers> WriteUserOffers(int id)
        {
            List<UserOffers> list = new List<UserOffers>();
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AdvertisementSystemDataBase.db");
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("SELECT * FROM UserOffers WHERE UserID=@ID", connection);
            query.Parameters.AddWithValue("@ID", id);
            SqliteDataReader read = query.ExecuteReader();
            while (read.Read())
            {
                UserOffers userOffers = new UserOffers(read.GetInt32(0),read.GetInt32(1), read.GetInt32(2), read.GetString(3), read.GetString(4), read.GetString(5), read.GetString(6), read.GetString(7), read.GetString(8), read.GetString(9), read.GetString(10), read.GetDateTime(11), read.GetString(12), read.GetString(13), read.GetString(14), read.GetString(15), read.GetString(16), read.GetString(17), read.GetString(18), read.GetString(19));
                list.Add(userOffers);
            }
            return list;
        }
    }
}
