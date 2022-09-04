using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReverseEnginereeing.Data;
using ReverseEnginereeing.Models;

namespace ReverseEnginereeing.Pages.Comapanies
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly NadlanDbContext _context;

        public IndexModel(NadlanDbContext context)
        {
            _context = context;
        }

        public IList<Company> Company { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Companies != null)
            {
                Company = await _context.Companies
                    .AsNoTracking() // Disable change tracking, EF Core will skip the snap shot when loaded
                    .ToListAsync();
            }
        }
    }
}
