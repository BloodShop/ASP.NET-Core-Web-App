using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReverseEnginereeing.Data;
using ReverseEnginereeing.Models;

namespace ReverseEnginereeing.Pages.Neighborhoods
{
    public class DetailsModel : PageModel
    {
        private readonly ReverseEnginereeing.Data.NadlanDbContext _context;

        public DetailsModel(ReverseEnginereeing.Data.NadlanDbContext context)
        {
            _context = context;
        }

      public Neighborhood Neighborhood { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Neighborhoods == null)
            {
                return NotFound();
            }

            var neighborhood = await _context.Neighborhoods.FirstOrDefaultAsync(m => m.NeighborhoodId == id);
            if (neighborhood == null)
            {
                return NotFound();
            }
            else 
            {
                Neighborhood = neighborhood;
            }
            return Page();
        }
    }
}
