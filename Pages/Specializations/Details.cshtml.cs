using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReverseEnginereeing.Data;
using ReverseEnginereeing.Models;

namespace ReverseEnginereeing.Pages.Specializations
{
    public class DetailsModel : PageModel
    {
        private readonly ReverseEnginereeing.Data.NadlanDbContext _context;

        public DetailsModel(ReverseEnginereeing.Data.NadlanDbContext context)
        {
            _context = context;
        }

      public Specialization Specialization { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Specializations == null)
            {
                return NotFound();
            }

            var specialization = await _context.Specializations.FirstOrDefaultAsync(m => m.SalesManId == id);
            if (specialization == null)
            {
                return NotFound();
            }
            else 
            {
                Specialization = specialization;
            }
            return Page();
        }
    }
}
