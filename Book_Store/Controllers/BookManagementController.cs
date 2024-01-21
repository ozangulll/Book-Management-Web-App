using Book_Store.Data;
using Book_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Book_Store.Controllers
{
    public class BookManagementController:Controller
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment HostingEnvironment;
        public BookManagementController(DataContext context,IWebHostEnvironment hc){
            _context=context;
            HostingEnvironment=hc;
        }
        public async Task<IActionResult> Index(){
            return View(await _context.Books.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id){
            if(id==null){
                return NotFound();
            }
            var book= await _context.Books.SingleOrDefaultAsync(bk=>bk.Id==id);
            if(book==null){
                return NotFound();
            }
            return View(book);
        }
        [HttpGet]
           public IActionResult Create(){
            return View();
        }
        [HttpPost]   
              public async Task<IActionResult> Create(Book newBook){
                if(ModelState.IsValid){
                string filename="";
                if(newBook.File!=null){
                    string uploadFolder=Path.Combine(HostingEnvironment.WebRootPath, "images");
                    filename=Guid.NewGuid().ToString()+"_"+ newBook.File.FileName;
                    string filepath=Path.Combine(uploadFolder,filename);
                    newBook.File.CopyTo(new FileStream(filepath,FileMode.Create));

                }
                newBook.Image=filename;
            _context.Books.Add(newBook);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
                }
            return View(newBook);
        }

        public async Task<IActionResult> Edit(int? id){
            if(id==null)
            return NotFound(); 

            var bk=await _context.Books.FindAsync(id);

            if(bk==null)
            return NotFound();
            ViewBag.Name=bk.BookName;
            ViewBag.Description=bk.Description;
            ViewBag.Author=bk.Author;
            ViewData["Length"]=bk.Length;
            ViewData["Publisher"]=bk.Publisher;
            ViewData["Price"]=bk.Price;
            return View();
        }
         [HttpPost]
public async Task<IActionResult> Edit(int? id, Book newBook)
{
    if (id == null)
        return NotFound();

    var existingBook = await _context.Books.FindAsync(id);

    if (existingBook == null)
        return NotFound();

    if (ModelState.IsValid)
    {
        try
        {
            // Sadece dosya yüklenmediyse kitap özelliklerini güncelle
            existingBook.BookName = newBook.BookName;
            existingBook.Description = newBook.Description;
            existingBook.Author = newBook.Author;
            existingBook.Length = newBook.Length;
            existingBook.Publisher = newBook.Publisher;
            existingBook.Price = newBook.Price;
            existingBook.Language = newBook.Language;
            existingBook.CategoryID = newBook.CategoryID;

            // Yeni bir dosya seçildiyse, bu durumu ele al
            if (newBook.File != null)
            {
                string uploadFolder = Path.Combine(HostingEnvironment.WebRootPath, "images");
                string filename = Guid.NewGuid().ToString() + "_" + newBook.File.FileName;
                string filepath = Path.Combine(uploadFolder, filename);
                newBook.File.CopyTo(new FileStream(filepath, FileMode.Create));

                // Resim özelliğini güncelle
                existingBook.Image = filename;
            }

            _context.Update(existingBook);
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
        return RedirectToAction("Index");
    }

    // Eğer ModelState geçerli değilse, Edit görünümüne mevcut kitap modeli ile dön
    return View(existingBook);
}

   [HttpGet]
        public async Task<IActionResult> Delete(int? id){
            var bk=await _context.Books.FindAsync(id);
            return View(bk);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] int id){
           var bk=await _context.Books.FindAsync(id);
           _context.Books.Remove(bk);
           await _context.SaveChangesAsync();
           return RedirectToAction("Index");
        }
      
 }
}