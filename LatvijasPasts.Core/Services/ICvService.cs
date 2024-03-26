using LatvijasPasts.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatvijasPasts.Core.Services
{
    public interface ICvService : IEntityService<PersonalData>
    {
        List<PersonalData> GetAllCvData();
        PersonalData GetCompleteCvData(int id);
        bool UpdateCompleteCvData(int id, PersonalData data);
    }
}
