using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReverseEnginereeing.Data;
using ReverseEnginereeing.Models;

namespace ReverseEnginereeing.Pages.Specializations
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly ReverseEnginereeing.Data.NadlanDbContext _context;

        public EditModel(ReverseEnginereeing.Data.NadlanDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Specialization Specialization { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Specializations == null)
            {
                return NotFound();
            }

            var specialization =  await _context.Specializations.FirstOrDefaultAsync(m => m.SalesManId == id);
            if (specialization == null)
            {
                return NotFound();
            }
            Specialization = specialization;
           ViewData["Level"] = new SelectList(_context.ExperienceLevels, "Level", "Level");
           ViewData["SalesManId"] = new SelectList(_context.SalesMen, "SalesManId", "SalesManId");
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

            _context.Attach(Specialization).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecializationExists(Specialization.SalesManId))
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

        private bool SpecializationExists(int id)
        {
          return (_context.Specializations?.Any(e => e.SalesManId == id)).GetValueOrDefault();
        }
    }
}
