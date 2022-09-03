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
    public class IndexModel : PageModel
    {
        private readonly ReverseEnginereeing.Data.NADLANContext _context;

        public IndexModel(ReverseEnginereeing.Data.NADLANContext context)
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
