using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOgloszeniowyPAD.Classes
{
    public class Language
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public string Languages { get; set; }
        public string LanguageLevel { get; set; }

        public Language(int iD, int userId, string languages, string languageLevel)
        {
            ID = iD;
            UserId = userId;
            Languages = languages;
            LanguageLevel = languageLevel;
        }

        public Language(int userId, string languages, string languageLevel)
        {
            UserId = userId;
            Languages = languages;
            LanguageLevel = languageLevel;
        }
    }
}
