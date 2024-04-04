using LatvijasPasts.Core.Models;
using LatvijasPasts.Core.Services;
using LatvijasPasts.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace LatvijasPasts.Services
{
    public class CvService : EntityService<PersonalData>, ICvService
    {
        public CvService(ILatvijasPastsDbContext context) : base(context)
        {

        }

        public List<PersonalData> GetAllCvData()
        {
            return _context.PersonalData
                .Include(edu => edu.Educations)
                .Include(work => work.WorkExperiences)
                .ToList();
        }

        public PersonalData GetCompleteCvData(int id)
        {
            return _context.PersonalData
        .Include(edu => edu.Educations)
        .Include(work => work.WorkExperiences)
        .FirstOrDefault(data => data.Id == id);
        }

        public bool UpdateCompleteCvData(int id, PersonalData data)
        {
            _context.PersonalData
                  .Include(edu => edu.Educations)
                  .Include(work => work.WorkExperiences)
                  .Where(personalData => personalData.Id == id)
                  .ExecuteUpdateAsync(b => b
                  .SetProperty(s => s.FirstName, s => data.FirstName)
                  .SetProperty(s => s.LastName, s => data.LastName)
                  .SetProperty(s => s.Email, s => data.Email)
                  .SetProperty(s => s.PhoneNumber, s => data.PhoneNumber)
                  .SetProperty(s => s.Educations.InstitutionName, s => data.Educations.InstitutionName)
                  .SetProperty(s => s.Educations.Faculty, s => data.Educations.Faculty)
                  .SetProperty(s => s.Educations.Degree, s => data.Educations.Degree)
                  .SetProperty(s => s.Educations.Status, s => data.Educations.Status)
                  .SetProperty(s => s.WorkExperiences.CompanyName, s => s.WorkExperiences.CompanyName)
                  .SetProperty(s => s.WorkExperiences.Description, s => s.WorkExperiences.Description)
                  .SetProperty(s => s.WorkExperiences.Position, s => s.WorkExperiences.Position)
                  .SetProperty(s => s.WorkExperiences.YearsOfExperience, s => s.WorkExperiences.YearsOfExperience)
                  );


            return true;
        }
    }
}
