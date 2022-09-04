using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReverseEnginereeing.Data;
using ReverseEnginereeing.Models;

namespace ReverseEnginereeing.Pages.Specializations
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ReverseEnginereeing.Data.NadlanDbContext _context;

        public CreateModel(ReverseEnginereeing.Data.NadlanDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Level"] = new SelectList(_context.ExperienceLevels, "Level", "Level");
        ViewData["SalesManId"] = new SelectList(_context.SalesMen, "SalesManId", "SalesManId");
        ViewData["TypeId"] = new SelectList(_context.HouseTypes, "TypeId", "TypeId");
            return Page();
        }

        [BindProperty]
        public Specialization Specialization { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Specializations == null || Specialization == null)
            {
                return Page();
            }

            _context.Specializations.Add(Specialization);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
