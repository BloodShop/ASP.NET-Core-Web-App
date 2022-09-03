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
        private readonly ReverseEnginereeing.Data.NADLANContext _context;

        public IndexModel(ReverseEnginereeing.Data.NADLANContext context)
        {
            _context = context;
        }

        public IList<HouseType> HouseType { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.HouseTypes != null)
            {
                HouseType = await _context.HouseTypes.ToListAsync();
            }
        }
    }
}
