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
    public class DetailsModel : PageModel
    {
        private readonly BookStash.Data.ExamContext _context;

        public DetailsModel(BookStash.Data.ExamContext context)
        {
            _context = context;
        }

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
    }
}
