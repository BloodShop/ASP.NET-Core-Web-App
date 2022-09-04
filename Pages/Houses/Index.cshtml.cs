using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReverseEnginereeing.Models;

namespace ReverseEnginereeing.Pages.Houses
{
    public class IndexModel : PageModel
    {
        private readonly ReverseEnginereeing.Data.NadlanDbContext _context;

        public IndexModel(ReverseEnginereeing.Data.NadlanDbContext context)
        {
            _context = context;
        }

        public IList<House> House { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Houses != null)
            {
                House = await _context.Houses
                .Include(h => h.Neighborhood)
                .Include(h => h.Owner)
                .Include(h => h.Type)
                .ToListAsync();
            }
        }
    }
}
