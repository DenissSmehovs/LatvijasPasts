using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LatvijasPasts.Data;
using LatvijasPasts.Models;
using System.Net;

namespace LatvijasPasts.Pages.CV
{
    public class EditModel : PageModel
    {
        private readonly LatvijasPasts.Data.LatvijasPastsContext _context;

        public EditModel(LatvijasPasts.Data.LatvijasPastsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PersonalInfo PersonalInfo { get; set; } = default!;

        [BindProperty]
        public List<WorkExperience> NewWorkExperiences { get; set; } = new List<WorkExperience>();

        [BindProperty]
        public List<Education> NewEducation { get; set; } = new List<Education>();

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
            PersonalInfo = personalinfo;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PersonalInfo).State = EntityState.Modified;

            foreach (var workExperience in PersonalInfo.WorkExperiences)
            {
                _context.Entry(workExperience).State = EntityState.Modified;
            }

            foreach (var edu in PersonalInfo.Educations)
            {
                _context.Entry(edu).State = EntityState.Modified;
            }

            if (NewEducation != null)
            {
                foreach (var edu in NewEducation)
                {
                    if (!string.IsNullOrEmpty(edu.InstitutionName))
                    {
                        PersonalInfo.Educations.Add(edu);
                    }
                }
            }

            if (NewWorkExperiences != null)
            {
                foreach (var newWorkExperience in NewWorkExperiences)
                {
                    if (!string.IsNullOrEmpty(newWorkExperience.CompanyName))
                    {
                        PersonalInfo.WorkExperiences.Add(newWorkExperience);
                    }
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalInfoExists(PersonalInfo.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PersonalInfoExists(int id)
        {
            return _context.PersonalInfo.Any(e => e.Id == id);
        }
    }
}
