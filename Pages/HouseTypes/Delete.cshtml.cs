using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReverseEnginereeing.Data;
using ReverseEnginereeing.Models;

namespace ReverseEnginereeing.Pages.HouseTypes
{
    public class DeleteModel : PageModel
    {
        private readonly ReverseEnginereeing.Data.NADLANContext _context;

        public DeleteModel(ReverseEnginereeing.Data.NADLANContext context)
        {
            _context = context;
        }

        [BindProperty]
      public HouseType HouseType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.HouseTypes == null)
            {
                return NotFound();
            }

            var housetype = await _context.HouseTypes.FirstOrDefaultAsync(m => m.TypeId == id);

            if (housetype == null)
            {
                return NotFound();
            }
            else 
            {
                HouseType = housetype;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.HouseTypes == null)
            {
                return NotFound();
            }
            var housetype = await _context.HouseTypes.FindAsync(id);

            if (housetype != null)
            {
                HouseType = housetype;
                _context.HouseTypes.Remove(HouseType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
