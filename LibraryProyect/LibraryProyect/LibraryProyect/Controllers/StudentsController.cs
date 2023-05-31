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
    public class StudentsController : ControllerBase
    {
        
        private readonly DataBaseContext _context;
        public StudentsController(DataBaseContext context)
        {
            _context = context;
        }
        [HttpGet, ActionName("Get")]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            var students = await _context.Students.ToListAsync();

            if (students == null)
            {
                return NotFound();
            }


            return Ok(students);
        }
        [HttpGet, ActionName("Get")]
        [Route("Get/{id}")]
        public async Task<ActionResult<Book>> GetStudentById(Guid? id)
        {
            var students = await _context.Students.FirstOrDefaultAsync(c => c.id == id); //Select * From Countries Where Id = "..."

            if (students == null)
            {
                return NotFound();
            }


            return Ok(students);
        }
        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult> CreateStudent(Student student)
        {
          
            try
            {
                student.id = Guid.NewGuid();
                
                //ticket.CreatedDate = DateTime.Now;
                _context.Students.Add(student);
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

            return Ok(student);
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit/{id}")]
        public async Task<ActionResult> EditStudent(Guid? id, Student student)
        {
            try
            {
                if (id != student.id) return NotFound("Stuent not found");

              

                _context.Students.Update(student);
                await _context.SaveChangesAsync(); // Aquí es donde se hace el Update...
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", student.StudentCode));
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }

            return Ok(student);
        }


        [HttpDelete, ActionName("Delete")]
        [Route("Delete/{id}")]
        public async Task<ActionResult> DeleteStudent(Guid? id)
        {
            if (_context.Students == null) return Problem("Entity set 'DataBaseContext.Students' is null.");
            var student = await _context.Students.FirstOrDefaultAsync(c => c.id == id);

            if (student == null) return NotFound("student not found");

            _context.Students.Remove(student);
            await _context.SaveChangesAsync(); //Hace las veces del Delete en SQL

            return Ok(String.Format("El estudiante fue eliminado!"));
        }
    }
}
