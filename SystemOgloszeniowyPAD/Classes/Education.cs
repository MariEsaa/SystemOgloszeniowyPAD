using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOgloszeniowyPAD.Classes
{
    public class Education
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public string SchoolName { get; set; }
        public string Location { get; set; }
        public string EducationLevel{ get; set; }  
        public string Direction { get; set; }   
        public DateTime PeriodFrom { get; set; }
        public DateTime PeriodTo { get; set; }

        public Education(int userId, string schoolName, string location, string educationLevel, string direction, DateTime periodFrom, DateTime periodTo)
        {
            UserId = userId;
            SchoolName = schoolName;
            Location = location;
            EducationLevel = educationLevel;
            Direction = direction;
            PeriodFrom = periodFrom;
            PeriodTo = periodTo;
        }

        public Education(int iD, int userId, string schoolName, string location, string educationLevel, string direction, DateTime periodFrom, DateTime periodTo)
        {
            ID = iD;
            UserId = userId;
            SchoolName = schoolName;
            Location = location;
            EducationLevel = educationLevel;
            Direction = direction;
            PeriodFrom = periodFrom;
            PeriodTo = periodTo;
        }
    }
}
