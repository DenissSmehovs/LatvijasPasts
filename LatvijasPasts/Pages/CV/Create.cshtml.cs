using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LatvijasPasts.Data;
using LatvijasPasts.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Net;

namespace LatvijasPasts.Pages.CV
{
    public class CreateModel : PageModel
    {
        private readonly LatvijasPasts.Data.LatvijasPastsContext _context;

        public CreateModel(LatvijasPasts.Data.LatvijasPastsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PersonalInfo PersonalInfo { get; set; } = new PersonalInfo();

        [BindProperty]
        public Education Education { get; set; }

        [BindProperty]
        public WorkExperience WorkExperience { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
           
            _context.PersonalInfo.Add(PersonalInfo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
