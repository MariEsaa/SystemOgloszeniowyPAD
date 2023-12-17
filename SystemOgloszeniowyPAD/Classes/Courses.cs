using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOgloszeniowyPAD.Classes
{
    public class Courses
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public string TrainingName { get; set; }
        public string Organiser { get; set; }
        public DateTime PeriodFrom { get; set; }
        public DateTime PeriodTo { get; set; }

        public Courses(int iD, int userId, string trainingName, string organiser, DateTime periodFrom, DateTime periodTo)
        {
            ID = iD;
            UserId = userId;
            TrainingName = trainingName;
            Organiser = organiser;
            PeriodFrom = periodFrom;
            PeriodTo = periodTo;
        }

        public Courses(int userId, string trainingName, string organiser, DateTime periodFrom, DateTime periodTo)
        {
            UserId = userId;
            TrainingName = trainingName;
            Organiser = organiser;
            PeriodFrom = periodFrom;
            PeriodTo = periodTo;
        }
    }
}
