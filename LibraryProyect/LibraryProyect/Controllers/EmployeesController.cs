using LibraryProyect.DAL;
using LibraryProyect.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryProyect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public EmployeesController(DataBaseContext context)
        {
            _context = context;
        }
        [HttpGet, ActionName("Get")]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetStudents()
        {
            var employees = await _context.Employees.ToListAsync();

            if (employees == null)
            {
                return NotFound();
            }


            return Ok(employees);
        }
        [HttpGet, ActionName("Get")]
        [Route("Get/{id}")]
        public async Task<ActionResult<Book>> GetEmployeeById(Guid? id)
        {
            var employess = await _context.Employees.FirstOrDefaultAsync(c => c.id == id); //Select * From Countries Where Id = "..."

            if (employess == null)
            {
                return NotFound();
            }


            return Ok(employess);
        }


        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult> CreateEmployee(Employee employee)
        {

            try
            {
                employee.id = Guid.NewGuid();

                //ticket.CreatedDate = DateTime.Now;
                _context.Employees.Add(employee);
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

            return Ok(employee);
        }


        [HttpPut, ActionName("Edit")]
        [Route("Edit/{id}")]
        public async Task<ActionResult> EditEmployee(Guid? id, Employee employee)
        {
            try
            {
                if (id != employee.id) return NotFound("employee not found");



                _context.Employees.Update(employee);
                await _context.SaveChangesAsync(); // Aquí es donde se hace el Update...
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", employee.EmployeeCode));
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }

            return Ok(employee);
        }




        [HttpDelete, ActionName("Delete")]
        [Route("Delete/{id}")]
        public async Task<ActionResult> DeleteEmployee(Guid? id)
        {
            if (_context.Employees == null) return Problem("Entity set 'DataBaseContext.Employees' is null.");
            var employee = await _context.Employees.FirstOrDefaultAsync(c => c.id == id);

            if (employee == null) return NotFound("employee not found");

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync(); //Hace las veces del Delete en SQL

            return Ok(String.Format("El empleado fue eliminado!"));
        }
    }
}
