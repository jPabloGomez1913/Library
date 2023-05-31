using System.ComponentModel.DataAnnotations;

namespace LibraryProyect.DAL.Entities
{
    public class Loan
    {
        [Key]
        public Guid IdPrestamo { get; set; }
        //Foreing key
        public Guid idPersona { get; set; }
        //Foreing key
        public Guid idLibro { get; set; }
        public DateTime fehcaPrestamo { get; set; }
        public DateTime fehcaLimite { get; set; }
        public Person Person { get; set; }
        public Book Book { get; set; }  



    }
}
