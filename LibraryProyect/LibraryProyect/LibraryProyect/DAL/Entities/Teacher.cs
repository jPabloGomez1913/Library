using System.ComponentModel.DataAnnotations;

namespace LibraryProyect.DAL.Entities
{
    public class Teacher : Person
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(10, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres")]
        public string TeacherCode { get; set; }
    }
}
