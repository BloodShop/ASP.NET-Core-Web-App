using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReverseEnginereeing.Data;
using ReverseEnginereeing.Models;

namespace ReverseEnginereeing.Pages.Salemen
{
    public class IndexModel : PageModel
    {
        private readonly ReverseEnginereeing.Data.NadlanDbContext _context;

        public IndexModel(ReverseEnginereeing.Data.NadlanDbContext context)
        {
            _context = context;
        }

        public IList<SalesMan> SalesMan { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.SalesMen != null)
            {
                SalesMan = await _context.SalesMen
                .Include(s => s.Company).ToListAsync();
            }
        }
    }
}
