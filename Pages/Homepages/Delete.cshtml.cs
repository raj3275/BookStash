using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookStash.Data;
using BookStash.Models;

namespace BookStash.Pages.Homepages
{
    public class DeleteModel : PageModel
    {
        private readonly BookStash.Data.ExamContext _context;

        public DeleteModel(BookStash.Data.ExamContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Homepage Homepage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Homepages == null)
            {
                return NotFound();
            }

            var homepage = await _context.Homepages.FirstOrDefaultAsync(m => m.HomepageID == id);

            if (homepage == null)
            {
                return NotFound();
            }
            else 
            {
                Homepage = homepage;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Homepages == null)
            {
                return NotFound();
            }
            var homepage = await _context.Homepages.FindAsync(id);

            if (homepage != null)
            {
                Homepage = homepage;
                _context.Homepages.Remove(Homepage);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
