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
    public class IndexModel : PageModel
    {
        private readonly BookStash.Data.ExamContext _context;

        public IndexModel(BookStash.Data.ExamContext context)
        {
            _context = context;
        }

        public IList<Homepage> Homepage { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Homepages != null)
            {
                Homepage = await _context.Homepages
                .Include(h => h.Author)
                .Include(h => h.Book).ToListAsync();
            }
        }
    }
}
