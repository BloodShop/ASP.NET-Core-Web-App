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

namespace ReverseEnginereeing.Pages.Countries
{
    public class EditModel : PageModel
    {
        private readonly ReverseEnginereeing.Data.NadlanDbContext _context;

        public EditModel(ReverseEnginereeing.Data.NadlanDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Country Country { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Countries == null)
            {
                return NotFound();
            }

            var country =  await _context.Countries.FirstOrDefaultAsync(m => m.CountryId == id);
            if (country == null)
            {
                return NotFound();
            }
            Country = country;
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

            _context.Attach(Country).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(Country.CountryId))
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

        private bool CountryExists(int id)
        {
          return (_context.Countries?.Any(e => e.CountryId == id)).GetValueOrDefault();
        }
    }
}
