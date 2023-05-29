using LibraryProyect.DAL;
using LibraryProyect.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace LibraryProyect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly DataBaseContext _context;
        public BooksController(DataBaseContext context)
        {
            _context = context;
        }

        [HttpGet,ActionName("Get")]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks() 
        { 
            var books = await _context.Books.ToListAsync();

            if (books == null)
            {
                return NotFound();
            }


            return Ok(books);
        }

        [HttpGet, ActionName("Get")]
        [Route("Get/{id}")]
        public async Task<ActionResult<Book>> GetBooktById(Guid? id)
        {
            var books = await _context.Books.FirstOrDefaultAsync(c => c.id == id); //Select * From Countries Where Id = "..."

            if (books == null)
            {
                return NotFound();
            }
          

            return Ok(books);
        }
        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult> CreateBook(Book book)
        {
            try
            {
                book.id = Guid.NewGuid();
                //ticket.CreatedDate = DateTime.Now;
                _context.Books.Add(book);
                await _context.SaveChangesAsync(); // Aquí es donde se hace el Insert Into...
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    return Conflict(String.Format("  ya existe"));
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }

            return Ok(book);
        }
    }
}
