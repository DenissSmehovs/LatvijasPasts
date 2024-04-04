using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatvijasPasts.Core.Models
{
    public class WorkExperience : Entity
    {
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public int YearsOfExperience { get; set; }
        public string Description { get; set; }
    }
}
