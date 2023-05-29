using System.ComponentModel.DataAnnotations;

namespace LibraryProyect.DAL.Entities
{
    public class Book
    {
        [Key]
        public Guid id { get; set; }

        [Display (Name="Nombre del libro:")]
        [MaxLength(30, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string NombreLibro { get; set; }
        [Display(Name = "Autor del libro:")]
        [MaxLength(30, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string AutorLibro { get; set; }
        [Display(Name = "Genero del libro:")]
        [MaxLength(30, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Genero { get; set; } 
    }
}
