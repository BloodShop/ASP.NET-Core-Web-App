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

namespace ReverseEnginereeing.Pages.Neighborhoods
{
    public class EditModel : PageModel
    {
        private readonly ReverseEnginereeing.Data.NADLANContext _context;

        public EditModel(ReverseEnginereeing.Data.NADLANContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Neighborhood Neighborhood { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Neighborhoods == null)
            {
                return NotFound();
            }

            var neighborhood =  await _context.Neighborhoods.FirstOrDefaultAsync(m => m.NeighborhoodId == id);
            if (neighborhood == null)
            {
                return NotFound();
            }
            Neighborhood = neighborhood;
           ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityId");
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

            _context.Attach(Neighborhood).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NeighborhoodExists(Neighborhood.NeighborhoodId))
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

        private bool NeighborhoodExists(int id)
        {
          return (_context.Neighborhoods?.Any(e => e.NeighborhoodId == id)).GetValueOrDefault();
        }
    }
}
