using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LatvijasPasts.Data;
using LatvijasPasts.Models;

namespace LatvijasPasts.Pages.CV
{
    public class IndexModel : PageModel
    {
        private readonly LatvijasPasts.Data.LatvijasPastsContext _context;

        public IndexModel(LatvijasPasts.Data.LatvijasPastsContext context)
        {
            _context = context;
        }

        public IList<PersonalInfo> PersonalInfo { get;set; } = default!;

        public IList<Education> Education { get; set; }

        public IList<WorkExperience> WorkExperience { get; set; }

        public async Task OnGetAsync()
        {
            PersonalInfo = await _context.PersonalInfo.ToListAsync();
        }
    }
}
