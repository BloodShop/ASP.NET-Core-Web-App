using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReverseEnginereeing.Data;
using ReverseEnginereeing.Models;

namespace ReverseEnginereeing.Pages.Sales
{
    public class IndexModel : PageModel
    {
        private readonly ReverseEnginereeing.Data.NADLANContext _context;

        public IndexModel(ReverseEnginereeing.Data.NADLANContext context)
        {
            _context = context;
        }

        public IList<Sale> Sale { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Sales != null)
            {
                Sale = await _context.Sales
                .Include(s => s.Buyer)
                .Include(s => s.House)
                .Include(s => s.SalesMan)
                .Include(s => s.Seller).ToListAsync();
            }
        }
    }
}
