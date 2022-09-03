using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReverseEnginereeing.Data;
using ReverseEnginereeing.Models;

namespace ReverseEnginereeing.Pages.Neighborhoods
{
    public class IndexModel : PageModel
    {
        private readonly ReverseEnginereeing.Data.NADLANContext _context;

        public IndexModel(ReverseEnginereeing.Data.NADLANContext context)
        {
            _context = context;
        }

        public IList<Neighborhood> Neighborhood { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Neighborhoods != null)
            {
                Neighborhood = await _context.Neighborhoods
                .Include(n => n.City).ToListAsync();
            }
        }
    }
}
