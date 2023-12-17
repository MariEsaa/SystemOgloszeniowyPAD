using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOgloszeniowyPAD.Classes
{
    public class Offers
    {
        public int ID { get; set; }
        public string PositionName { get; set; }
        public string CompanyPhoto { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }        
        public string PositionLevel { get; set; }
        public string ContractType { get; set; }
        public string Workdays { get; set; }
        public string WorkHours { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Category { get; set; }
        public string Responsibilities { get; set; }
        public string Requirements { get; set; }
        public string Benefits{ get; set; }
        public string AboutCompany { get; set; }
        public string Tenure { get; set; }
        public string WorkMode { get; set; }
        public string Salary { get; set; }

        public Offers(int iD, string positionName, string companyPhoto, string company, string location, string positionLevel, string contractType, string workdays, string workHours, DateTime expirationDate, string category, string responsibilities, string requirements, string benefits, string aboutCompany, string tenure, string workMode, string salary)
        {
            ID = iD;
            PositionName = positionName;
            CompanyPhoto = companyPhoto;
            Company = company;
            Location = location;
            PositionLevel = positionLevel;
            ContractType = contractType;
            Workdays = workdays;
            WorkHours = workHours;
            ExpirationDate = expirationDate;
            Category = category;
            Responsibilities = responsibilities;
            Requirements = requirements;
            Benefits = benefits;
            AboutCompany = aboutCompany;
            Tenure = tenure;
            WorkMode = workMode;
            Salary = salary;
        }

        public Offers(string positionName, string companyPhoto, string company, string location, string positionLevel, string contractType, string workdays, string workHours, DateTime expirationDate, string category, string responsibilities, string requirements, string benefits, string aboutCompany, string tenure, string workMode, string salary)
        {
            PositionName = positionName;
            CompanyPhoto = companyPhoto;
            Company = company;
            Location = location;
            PositionLevel = positionLevel;
            ContractType = contractType;
            Workdays = workdays;
            WorkHours = workHours;
            ExpirationDate = expirationDate;
            Category = category;
            Responsibilities = responsibilities;
            Requirements = requirements;
            Benefits = benefits;
            AboutCompany = aboutCompany;
            Tenure = tenure;
            WorkMode = workMode;
            Salary = salary;
        }
    }
}
