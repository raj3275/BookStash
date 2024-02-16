using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStash.Data;
using BookStash.Models;

namespace BookStash.Pages.Homepages
{
    public class EditModel : PageModel
    {
        private readonly BookStash.Data.ExamContext _context;

        public EditModel(BookStash.Data.ExamContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Homepage Homepage { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Homepages == null)
            {
                return NotFound();
            }

            var homepage =  await _context.Homepages.FirstOrDefaultAsync(m => m.HomepageID == id);
            if (homepage == null)
            {
                return NotFound();
            }
            Homepage = homepage;
           ViewData["AuthorID"] = new SelectList(_context.Authors, "AuthorID", "AuthorID");
           ViewData["BookID"] = new SelectList(_context.Books, "BookID", "BookID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Homepage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HomepageExists(Homepage.HomepageID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool HomepageExists(int id)
        {
          return _context.Homepages.Any(e => e.HomepageID == id);
        }
    }
}
