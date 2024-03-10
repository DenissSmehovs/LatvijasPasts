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
    public class DetailsModel : PageModel
    {
        private readonly LatvijasPasts.Data.LatvijasPastsContext _context;

        public DetailsModel(LatvijasPasts.Data.LatvijasPastsContext context)
        {
            _context = context;
        }

        public PersonalInfo PersonalInfo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalinfo = await _context.PersonalInfo
                .Include(edu => edu.Educations)
                .Include(work => work.WorkExperiences)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personalinfo == null)
            {
                return NotFound();
            }
            else
            {
                PersonalInfo = personalinfo;
            }
            return Page();
        }
    }
}
