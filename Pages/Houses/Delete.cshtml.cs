using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReverseEnginereeing.Data;
using ReverseEnginereeing.Models;

namespace ReverseEnginereeing.Pages.Houses
{
    public class DeleteModel : PageModel
    {
        private readonly ReverseEnginereeing.Data.NadlanDbContext _context;

        public DeleteModel(ReverseEnginereeing.Data.NadlanDbContext context)
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

            var house = await _context.Houses.FirstOrDefaultAsync(m => m.HouseId == id);

            if (house == null)
            {
                return NotFound();
            }
            else 
            {
                House = house;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Houses == null)
            {
                return NotFound();
            }
            var house = await _context.Houses.FindAsync(id);

            if (house != null)
            {
                House = house;
                _context.Houses.Remove(House);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
