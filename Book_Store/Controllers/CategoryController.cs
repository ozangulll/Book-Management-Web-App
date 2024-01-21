// Controllers/YourController.cs
using Book_Store.Data;
using Book_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

public class CategoryController : Controller
{
    private readonly DataContext _context;

    public CategoryController(DataContext context)
    {
        _context = context;
    }

   public async Task<IActionResult> Index()
        {
            var categories = await _context.Categories.ToListAsync();
            return View(categories);
        }
      public async Task<IActionResult> ShowBooks(int categoryId)
        {
            var category = await _context.Categories.FindAsync(categoryId);

            if (category == null)
            {
                return NotFound();
            }

            var categoryBooks = await _context.Books
                .Where(book => book.CategoryID == categoryId)
                .ToListAsync();

            ViewData["CategoryName"] = category.CategoryName;

            return View(categoryBooks);
        }


}
