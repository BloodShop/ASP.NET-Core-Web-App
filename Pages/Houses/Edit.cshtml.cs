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

namespace ReverseEnginereeing.Pages.Houses
{
    public class EditModel : PageModel
    {
        private readonly ReverseEnginereeing.Data.NadlanDbContext _context;

        public EditModel(ReverseEnginereeing.Data.NadlanDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public House House { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Houses == null)
            {
                return NotFound();
            }

            var house =  await _context.Houses.FirstOrDefaultAsync(m => m.HouseId == id);
            if (house == null)
            {
                return NotFound();
            }
            House = house;
           ViewData["NeighborhoodId"] = new SelectList(_context.Neighborhoods, "NeighborhoodId", "NeighborhoodId");
           ViewData["OwnerId"] = new SelectList(_context.People, "PersonId", "PersonId");
           ViewData["TypeId"] = new SelectList(_context.HouseTypes, "TypeId", "TypeId");
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

            _context.Attach(House).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HouseExists(House.HouseId))
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

        private bool HouseExists(int id)
        {
          return (_context.Houses?.Any(e => e.HouseId == id)).GetValueOrDefault();
        }
    }
}
