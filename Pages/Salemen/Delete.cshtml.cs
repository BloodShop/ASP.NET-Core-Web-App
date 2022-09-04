using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReverseEnginereeing.Data;
using ReverseEnginereeing.Models;

namespace ReverseEnginereeing.Pages.Salemen
{
    public class DeleteModel : PageModel
    {
        private readonly ReverseEnginereeing.Data.NadlanDbContext _context;

        public DeleteModel(ReverseEnginereeing.Data.NadlanDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public SalesMan SalesMan { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SalesMen == null)
            {
                return NotFound();
            }

            var salesman = await _context.SalesMen.FirstOrDefaultAsync(m => m.SalesManId == id);

            if (salesman == null)
            {
                return NotFound();
            }
            else 
            {
                SalesMan = salesman;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.SalesMen == null)
            {
                return NotFound();
            }
            var salesman = await _context.SalesMen.FindAsync(id);

            if (salesman != null)
            {
                SalesMan = salesman;
                _context.SalesMen.Remove(SalesMan);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
