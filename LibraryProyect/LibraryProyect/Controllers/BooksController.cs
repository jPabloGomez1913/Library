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



        [HttpPut, ActionName("Edit")]
        [Route("Edit/{id}")]
        public async Task<ActionResult> EditBook(Guid? id, Book book)
        {
            try
            {
                if (id != book.id) return NotFound("book not found");



                _context.Books.Update(book);
                await _context.SaveChangesAsync(); // Aquí es donde se hace el Update...
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", book.id));
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }

            return Ok(book);
        }


        [HttpDelete, ActionName("Delete")]
        [Route("Delete/{id}")]
        public async Task<ActionResult> DeleteBook(Guid? id)
        {
            if (_context.Books == null) return Problem("Entity set 'DataBaseContext.Books' is null.");
            var book = await _context.Books.FirstOrDefaultAsync(c => c.id == id);

            if (book == null) return NotFound("student not found");

            _context.Books.Remove(book);
            await _context.SaveChangesAsync(); //Hace las veces del Delete en SQL

            return Ok(String.Format("El libro fue eliminado!"));
        }

    }
}
