using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReverseEnginereeing.Data;
using ReverseEnginereeing.Models;

namespace ReverseEnginereeing.Pages.ExperienceLevels
{
    public class EditModel : PageModel
    {
        private readonly ReverseEnginereeing.Data.NADLANContext _context;

        public EditModel(ReverseEnginereeing.Data.NADLANContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ExperienceLevel ExperienceLevel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.ExperienceLevels == null)
            {
                return NotFound();
            }

            var experiencelevel =  await _context.ExperienceLevels.FirstOrDefaultAsync(m => m.Level == id);
            if (experiencelevel == null)
            {
                return NotFound();
            }
            ExperienceLevel = experiencelevel;
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

            _context.Attach(ExperienceLevel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExperienceLevelExists(ExperienceLevel.Level))
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

        private bool ExperienceLevelExists(string id)
        {
          return (_context.ExperienceLevels?.Any(e => e.Level == id)).GetValueOrDefault();
        }
    }
}
