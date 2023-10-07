using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty] //Assume on post, this will be gotten
        public Book Book{ get; set; }// to access Book
        public void OnGet()
        {
            //does it automatically, do not have to implement
        }

        public async Task<IActionResult> OnPost() //passing the book object after creating  and save to database
        {
            if (ModelState.IsValid)
            {
                await _db.Book.AddAsync(Book); //Added to the queue
                await _db.SaveChangesAsync(); // Pushed to db
                return RedirectToPage("Index"); //After pushed to db, redirect to Index page
            }
            else 
            {
                return Page();
            }
        }
    }
}
