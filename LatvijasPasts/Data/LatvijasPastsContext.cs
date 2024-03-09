using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LatvijasPasts.Models;

namespace LatvijasPasts.Data
{
    public class LatvijasPastsContext : DbContext
    {
        public LatvijasPastsContext (DbContextOptions<LatvijasPastsContext> options)
            : base(options)
        {
        }

        public DbSet<LatvijasPasts.Models.PersonalInfo> PersonalInfo { get; set; } = default!;
        public DbSet<LatvijasPasts.Models.Education> Education { get; set; }
        public DbSet<LatvijasPasts.Models.WorkExperience> WorkExperience { get; set; }
    }
}
