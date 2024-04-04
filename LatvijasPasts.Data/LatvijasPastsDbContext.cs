using LatvijasPasts.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace LatvijasPasts.Data
{
    public class LatvijasPastsDbContext : DbContext, ILatvijasPastsDbContext
    {
        public LatvijasPastsDbContext(DbContextOptions<LatvijasPastsDbContext> options) : 
            base(options)
        {
            
        }

        public DbSet<PersonalData> PersonalData { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<WorkExperience> WorkExperience { get; set; }
    }
}
