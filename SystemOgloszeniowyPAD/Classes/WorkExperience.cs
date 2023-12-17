using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOgloszeniowyPAD.Classes
{
    public class WorkExperience
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public string Position { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public DateTime PeriodOfEmploymentFrom { get; set; }
        public DateTime PeriodOfEmploymentTo { get; set; }
        public string Responsibilities { get; set; }

        public WorkExperience(int userId, string position, string companyName, string location, DateTime periodOfEmploymentFrom, DateTime periodOfEmploymentTo, string responsibilities)
        {
            UserId = userId;
            Position = position;
            CompanyName = companyName;
            Location = location;
            PeriodOfEmploymentFrom = periodOfEmploymentFrom;
            PeriodOfEmploymentTo = periodOfEmploymentTo;
            Responsibilities = responsibilities;
        }

        public WorkExperience(int iD, int userId, string position, string companyName, string location, DateTime periodOfEmploymentFrom, DateTime periodOfEmploymentTo, string responsibilities)
        {
            ID = iD;
            UserId = userId;
            Position = position;
            CompanyName = companyName;
            Location = location;
            PeriodOfEmploymentFrom = periodOfEmploymentFrom;
            PeriodOfEmploymentTo = periodOfEmploymentTo;
            Responsibilities = responsibilities;
        }
    }
}
