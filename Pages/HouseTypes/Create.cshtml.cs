using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReverseEnginereeing.Data;
using ReverseEnginereeing.Models;

namespace ReverseEnginereeing.Pages.HouseTypes
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
            return Page();
        }

        [BindProperty]
        public HouseType HouseType { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.HouseTypes == null || HouseType == null)
            {
                return Page();
            }

            _context.HouseTypes.Add(HouseType);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
