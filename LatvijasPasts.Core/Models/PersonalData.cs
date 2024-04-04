using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatvijasPasts.Core.Models
{
    public class PersonalData : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public WorkExperience WorkExperiences { get; set; }
        public Education Educations { get; set; }
    }
}
