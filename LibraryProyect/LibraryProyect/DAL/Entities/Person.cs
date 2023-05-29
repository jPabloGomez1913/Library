using System.ComponentModel.DataAnnotations;

namespace LibraryProyect.DAL.Entities
{
    public class Person
    {
        [Key]
        public Guid id { get; set; }

        [MaxLength(30, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Nombre { get; set; }

        [MaxLength(30, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Apellido { get; set; }

        public List<Loan>? Loans { get; set; }




    }
}
