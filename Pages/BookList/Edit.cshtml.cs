using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        
        [BindProperty] 
        public Book Book{ get; set; }
        
        public async Task OnGet(int id) //Get the data of the item to edit to the Edit page
        {
            Book = await _db.Book.FindAsync(id);
        }

        public async Task<IActionResult> OnPost() //On post after Edit is pressed
        {
            if(ModelState.IsValid) 
            {
                var BookFromDb = await _db.Book.FindAsync(Book.Id); //retrive the book from Db via its Id
                BookFromDb.Name = Book.Name; //reference back to the Book Object from the OnGet
                BookFromDb.Author = Book.Author;
                BookFromDb.ISBN = Book.ISBN;

                await _db.SaveChangesAsync(); // Save the changes, and update the Book object in the database

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
