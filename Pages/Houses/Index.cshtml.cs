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
    public class IndexModel : PageModel
    {
        private readonly ReverseEnginereeing.Data.NADLANContext _context;

        public IndexModel(ReverseEnginereeing.Data.NADLANContext context)
        {
            _context = context;
        }

        public IList<House> House { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Houses != null)
            {
                House = await _context.Houses
                .Include(h => h.Neighborhood)
                .Include(h => h.Owner)
                .Include(h => h.Type).ToListAsync();
            }
        }
    }
}
