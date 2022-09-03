using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReverseEnginereeing.Data;
using ReverseEnginereeing.Models;

namespace ReverseEnginereeing.Pages.Neighborhoods
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
        ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityId");
            return Page();
        }

        [BindProperty]
        public Neighborhood Neighborhood { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Neighborhoods == null || Neighborhood == null)
            {
                return Page();
            }

            _context.Neighborhoods.Add(Neighborhood);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
