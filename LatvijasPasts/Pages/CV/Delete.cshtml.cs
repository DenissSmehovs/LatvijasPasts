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
    public class DeleteModel : PageModel
    {
        private readonly LatvijasPasts.Data.LatvijasPastsContext _context;

        public DeleteModel(LatvijasPasts.Data.LatvijasPastsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PersonalInfo PersonalInfo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalinfo = await _context.PersonalInfo.FirstOrDefaultAsync(m => m.Id == id);

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalinfo = await _context.PersonalInfo
                .Include(work => work.WorkExperiences)
                .Include(edu => edu.Educations)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personalinfo != null)
            {
                PersonalInfo = personalinfo;
              
                var educationsToRemove = PersonalInfo.Educations.ToList();
                var workExp = PersonalInfo.WorkExperiences.ToList();

                _context.PersonalInfo.Remove(PersonalInfo);
                _context.Education.RemoveRange(educationsToRemove);
                _context.WorkExperience.RemoveRange(workExp);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
