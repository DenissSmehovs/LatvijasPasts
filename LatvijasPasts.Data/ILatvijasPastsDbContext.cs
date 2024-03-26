using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using LatvijasPasts.Core.Models;

namespace LatvijasPasts.Data
{
    public interface ILatvijasPastsDbContext
    {
        DbSet<T> Set<T>() where T : class;
        EntityEntry<T> Entry<T>(T entity) where T : class;

        DbSet<PersonalData> PersonalData { get; set; }
        DbSet<Education> Education { get; set; }
        DbSet<WorkExperience> WorkExperience { get; set; }

        int SaveChanges();
    }
}
