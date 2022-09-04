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
    public class DetailsModel : PageModel
    {
        private readonly ReverseEnginereeing.Data.NadlanDbContext _context;

        public DetailsModel(ReverseEnginereeing.Data.NadlanDbContext context)
        {
            _context = context;
        }

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
    }
}
