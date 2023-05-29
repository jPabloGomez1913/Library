using LibraryProyect.DAL;
using LibraryProyect.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryProyect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public TeachersController(DataBaseContext context)
        {
            _context = context;
        }
        [HttpGet, ActionName("Get")]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers()
        {
            var teachers = await _context.Teachers.ToListAsync();

            if (teachers == null)
            {
                return NotFound();
            }


            return Ok(teachers);
        }
        [HttpGet, ActionName("Get")]
        [Route("Get/{id}")]
        public async Task<ActionResult<Book>> GetTeacherById(Guid? id)
        {
            var teachers = await _context.Teachers.FirstOrDefaultAsync(c => c.id == id); //Select * From Countries Where Id = "..."

            if (teachers == null)
            {
                return NotFound();
            }


            return Ok(teachers);
        }


        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult> CreateTeacher(Teacher teacher)
        {

            try
            {
                teacher.id = Guid.NewGuid();

                //ticket.CreatedDate = DateTime.Now;
                _context.Teachers.Add(teacher);
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

            return Ok(teacher);
        }


        [HttpPut, ActionName("Edit")]
        [Route("Edit/{id}")]
        public async Task<ActionResult> EditEmployee(Guid? id, Teacher teacher)
        {
            try
            {
                if (id != teacher.id) return NotFound("teacher not found");



                _context.Teachers.Update(teacher);
                await _context.SaveChangesAsync(); // Aquí es donde se hace el Update...
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", teacher.TeacherCode));
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }

            return Ok(teacher);
        }




        [HttpDelete, ActionName("Delete")]
        [Route("Delete/{id}")]
        public async Task<ActionResult> DeleteTeacher(Guid? id)
        {
            if (_context.Teachers == null) return Problem("Entity set 'DataBaseContext.Teachers' is null.");
            var teacher = await _context.Teachers.FirstOrDefaultAsync(c => c.id == id);

            if (teacher == null) return NotFound("teacher not found");

            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync(); //Hace las veces del Delete en SQL

            return Ok(String.Format("El profesor fue eliminado!"));
        }
    }
}
