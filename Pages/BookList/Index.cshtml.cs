using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db; //using dependency injection onto this page

        public IndexModel(ApplicationDbContext db) //using dependency injection
        {
            _db = db;
        }

        public IEnumerable<Book> Books { get; set; } //to return the list of books
        public async Task OnGet() //going to database and retrieving all of the books 
        {
            Books = await _db.Book.ToListAsync();
        }
    }
}
