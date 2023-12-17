using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SystemOgloszeniowyPAD.Classes
{
    public class BasicInformations
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ProfilePicture { get; set; }
        public string Residence { get; set; }
        public BasicInformations() 
        { 

        }

        public BasicInformations(int userId, string name, string surname, DateTime birthDate, string email, string phoneNumber, string profilePicture, string residence)
        {
            UserId = userId;
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
            Email = email;
            PhoneNumber = phoneNumber;
            ProfilePicture = profilePicture;
            Residence = residence;
        }
    }
}
