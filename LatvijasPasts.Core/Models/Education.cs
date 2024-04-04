using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatvijasPasts.Core.Models
{
    public class Education : Entity
    {
        public string InstitutionName { get; set; }
        public string Faculty { get; set; }
        public string Degree { get; set; }
        public string Status { get; set; }
    }
}
