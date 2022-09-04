using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReverseEnginereeing.Data;
using ReverseEnginereeing.Models;

namespace ReverseEnginereeing.Pages.Houses
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
        ViewData["NeighborhoodId"] = new SelectList(_context.Neighborhoods, "NeighborhoodId", "NeighborhoodId");
        ViewData["OwnerId"] = new SelectList(_context.People, "PersonId", "PersonId");
        ViewData["TypeId"] = new SelectList(_context.HouseTypes, "TypeId", "TypeId");
            return Page();
        }

        [BindProperty]
        public House House { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Houses == null || House == null)
            {
                return Page();
            }

            _context.Houses.Add(House);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
