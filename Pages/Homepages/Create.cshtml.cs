using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookStash.Data;
using BookStash.Models;

namespace BookStash.Pages.Homepages
{
    public class CreateModel : PageModel
    {
        private readonly BookStash.Data.ExamContext _context;

        public CreateModel(BookStash.Data.ExamContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AuthorID"] = new SelectList(_context.Authors, "AuthorID", "AuthorID");
        ViewData["BookID"] = new SelectList(_context.Books, "BookID", "BookID");
            return Page();
        }

        [BindProperty]
        public Homepage Homepage { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Homepages.Add(Homepage);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
