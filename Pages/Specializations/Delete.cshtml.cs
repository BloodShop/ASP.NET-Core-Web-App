﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly ReverseEnginereeing.Data.NADLANContext _context;

        public DeleteModel(ReverseEnginereeing.Data.NADLANContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Specialization Specialization { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Specializations == null)
            {
                return NotFound();
            }

            var specialization = await _context.Specializations.FirstOrDefaultAsync(m => m.SalesManId == id);

            if (specialization == null)
            {
                return NotFound();
            }
            else 
            {
                Specialization = specialization;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Specializations == null)
            {
                return NotFound();
            }
            var specialization = await _context.Specializations.FindAsync(id);

            if (specialization != null)
            {
                Specialization = specialization;
                _context.Specializations.Remove(Specialization);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
