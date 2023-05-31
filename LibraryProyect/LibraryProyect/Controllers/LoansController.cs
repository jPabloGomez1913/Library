using LibraryProyect.DAL;
using LibraryProyect.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryProyect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public LoansController(DataBaseContext context) { 
        
            _context= context;
        
        }
        [HttpGet, ActionName("Get")]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<Student>>> GetLoans()
        {
            var loans = await _context.Loans.ToListAsync();

            if (loans == null)
            {
                return NotFound();
            }


            return Ok(loans);
        }


        [HttpGet, ActionName("Get")]
        [Route("Get/{id}")]
       
        public async Task<ActionResult<Loan>> GetLoanById(Guid? id) { 

            var loan = await _context.Loans.FirstOrDefaultAsync(c => c.IdPrestamo == id);

            if (loan == null) 
            {
                return NotFound();
            
            }
            return Ok(loan);
            
        }


        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult> CreateLoan(Loan loan,Guid idLibro,Guid idPersona) {

            try
            {
                loan.IdPrestamo = Guid.NewGuid();
                loan.idPersona = idPersona;
                loan.idLibro = idLibro;
                loan.fehcaPrestamo= DateTime.Now;

                //ticket.CreatedDate = DateTime.Now;
                _context.Loans.Add(loan);
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

            return Ok(loan);



        }

    }
}
