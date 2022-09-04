using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReverseEnginereeing.Data;
using ReverseEnginereeing.Models;

namespace ReverseEnginereeing.Pages.Cities
{
    public class IndexModel : PageModel
    {
        private readonly ReverseEnginereeing.Data.NadlanDbContext _context;

        public IndexModel(ReverseEnginereeing.Data.NadlanDbContext context)
        {
            _context = context;
        }

        public IList<City> City { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Cities != null)
            {
                City = await _context.Cities.ToListAsync();
            }
        }
    }
}
