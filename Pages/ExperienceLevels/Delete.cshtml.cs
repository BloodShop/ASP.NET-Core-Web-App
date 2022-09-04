using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReverseEnginereeing.Data;
using ReverseEnginereeing.Models;

namespace ReverseEnginereeing.Pages.ExperienceLevels
{
    public class DeleteModel : PageModel
    {
        private readonly ReverseEnginereeing.Data.NadlanDbContext _context;

        public DeleteModel(ReverseEnginereeing.Data.NadlanDbContext context)
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

            var experiencelevel = await _context.ExperienceLevels.FirstOrDefaultAsync(m => m.Level == id);

            if (experiencelevel == null)
            {
                return NotFound();
            }
            else 
            {
                ExperienceLevel = experiencelevel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.ExperienceLevels == null)
            {
                return NotFound();
            }
            var experiencelevel = await _context.ExperienceLevels.FindAsync(id);

            if (experiencelevel != null)
            {
                ExperienceLevel = experiencelevel;
                _context.ExperienceLevels.Remove(ExperienceLevel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
