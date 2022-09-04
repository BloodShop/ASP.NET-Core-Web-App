using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReverseEnginereeing.Data;
using ReverseEnginereeing.Models;

namespace ReverseEnginereeing.Pages.Sales
{
    public class CreateModel : PageModel
    {
        private readonly ReverseEnginereeing.Data.NadlanDbContext _context;

        public CreateModel(ReverseEnginereeing.Data.NadlanDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BuyerId"] = new SelectList(_context.People, "PersonId", "PersonId");
        ViewData["HouseId"] = new SelectList(_context.Houses, "HouseId", "HouseId");
        ViewData["SalesManId"] = new SelectList(_context.SalesMen, "SalesManId", "SalesManId");
        ViewData["SellerId"] = new SelectList(_context.People, "PersonId", "PersonId");
            return Page();
        }

        [BindProperty]
        public Sale Sale { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Sales == null || Sale == null)
            {
                return Page(); // Razer view
            }

            _context.Sales.Add(Sale);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
