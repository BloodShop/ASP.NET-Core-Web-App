using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReverseEnginereeing.Data;
using ReverseEnginereeing.Models;

namespace ReverseEnginereeing.Pages.Salemen
{
    public class CreateModel : PageModel
    {
        private readonly ReverseEnginereeing.Data.NADLANContext _context;

        public CreateModel(ReverseEnginereeing.Data.NADLANContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyId");
            return Page();
        }

        [BindProperty]
        public SalesMan SalesMan { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.SalesMen == null || SalesMan == null)
            {
                return Page();
            }

            _context.SalesMen.Add(SalesMan);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
