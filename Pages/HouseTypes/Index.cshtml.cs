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
    public class IndexModel : PageModel
    {
        private readonly ReverseEnginereeing.Data.NadlanDbContext _context;

        public IndexModel(ReverseEnginereeing.Data.NadlanDbContext context)
        {
            _context = context;
        }

        public IList<HouseType> HouseType { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.HouseTypes != null)
            {
                HouseType = await _context.HouseTypes
                    .AsNoTracking() // Disable change tracking, EF Core will skip the snap shot when loaded
                    .ToListAsync();
            }
        }
    }
}
