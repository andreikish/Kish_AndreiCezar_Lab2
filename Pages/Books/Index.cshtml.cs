using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Kish_AndreiCezar_Lab2.Data;
using Kish_AndreiCezar_Lab2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kish_AndreiCezar_Lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Kish_AndreiCezar_Lab2Context _context;

        public IndexModel(Kish_AndreiCezar_Lab2Context context)
        {
            _context = context;
        }


        public IList<Book> Book { get; set; } = default!;


        public SelectList Authors { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? AuthorID { get; set; }


        public async Task OnGetAsync()
        {
            var authorsQuery = from a in _context.Authors
                               orderby a.LastName
                               select a;
            Authors = new SelectList(await authorsQuery.ToListAsync(), "ID", "FullName");

            IQueryable<Book> booksQuery = _context.Book.Include(b => b.Author);

            if (AuthorID.HasValue)
            {
                booksQuery = booksQuery.Where(b => b.AuthorID == AuthorID);
            }

            Book = await booksQuery.ToListAsync();
        }
    }
}
