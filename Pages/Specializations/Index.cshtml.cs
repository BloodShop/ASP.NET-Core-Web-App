using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReverseEnginereeing.Data;
using ReverseEnginereeing.Models;

namespace ReverseEnginereeing.Pages.Specializations
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ReverseEnginereeing.Data.NadlanDbContext _context;

        public IndexModel(ReverseEnginereeing.Data.NadlanDbContext context)
        {
            _context = context;
        }

        public IList<Specialization> Specialization { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Specializations != null)
            {
                Specialization = await _context.Specializations
                .Include(s => s.LevelNavigation)
                .Include(s => s.SalesMan)
                .Include(s => s.Type).ToListAsync();
            }
        }
    }
}
