using LibraryProyect.DAL.Entities;

namespace LibraryProyect.DAL
{
    public class SeederDb
    {

        private readonly DataBaseContext _context;
        public SeederDb(DataBaseContext context)
        {
            _context = context;
        }

        public async Task SeederAsync()
        {
            await _context.Database.EnsureCreatedAsync(); // BD de forma automática

            await PopulateBooksAsync();
            await _context.SaveChangesAsync();
        }

        //b.Property<string>("AutorLibro")
        //b.Property<int>("CantidadLibros")     
        //b.Property<string>("Genero")      
        //b.Property<string>("NombreLibro")      
        private async Task PopulateBooksAsync()
        {
            if (!_context.Books.Any())
            {
                _context.Books.Add(new Entities.Book { AutorLibro = "", CantidadLibros = 0, Genero = "", NombreLibro = "" });
                _context.Books.Add(new Book { AutorLibro = "Antoine de Saint-Exupéry", CantidadLibros = 5, Genero = "Infantil", NombreLibro = "El principito" });
                _context.Books.Add(new Book { AutorLibro = "Antoine de Saint-Exupéry", CantidadLibros = 3, Genero = "Biografia", NombreLibro = "Tierra de hombres" });
                _context.Books.Add(new Book { AutorLibro = "Antoine de Saint-Exupéry", CantidadLibros = 4, Genero = "Ficcion", NombreLibro = "vuelo nocturno" });
                _context.Books.Add(new Book { AutorLibro = "Jane Austen", CantidadLibros = 6, Genero = "Novela clásica", NombreLibro = "Orgullo y prejuicio" });
                _context.Books.Add(new Book { AutorLibro = "Jane Austen", CantidadLibros = 5, Genero = "Novela clásica", NombreLibro = "Sentido y sensibilidad" });
                _context.Books.Add(new Book { AutorLibro = "Jane Austen", CantidadLibros = 1, Genero = "Novela clásica", NombreLibro = "Emma" });
                _context.Books.Add(new Book { AutorLibro = "Gabriel García Márquez", CantidadLibros = 2, Genero = " Realismo mágico", NombreLibro = "Cien años de soledad" });
                _context.Books.Add(new Book { AutorLibro = "Gabriel García Márquez", CantidadLibros = 1, Genero = " Realismo mágico", NombreLibro = "El amor en los tiempos del cólera" });
                _context.Books.Add(new Book { AutorLibro = "Gabriel García Márquez", CantidadLibros = 3, Genero = " Realismo mágico", NombreLibro = "Crónica de una muerte anunciada" });
                _context.Books.Add(new Book { AutorLibro = "Gabriel García Márquez", CantidadLibros = 2, Genero = " Realismo mágico", NombreLibro = "El otoño del patriarca" });
                _context.Books.Add(new Book { AutorLibro = "George Orwell", CantidadLibros = 2, Genero = "Distopía", NombreLibro = "Rebelión en la granja" });
                _context.Books.Add(new Book { AutorLibro = "George Orwell", CantidadLibros = 3, Genero = "Distopía", NombreLibro = "1984" });
                _context.Books.Add(new Book { AutorLibro = "J.R.R. Tolkien", CantidadLibros = 1, Genero = "Fantasía épica", NombreLibro = "El Señor de los Anillos 1" });
                _context.Books.Add(new Book { AutorLibro = "Harper Lee", CantidadLibros = 2, Genero = "Novela", NombreLibro = "Matar a un ruiseñor" });
                _context.Books.Add(new Book { AutorLibro = "William Shakespeare", CantidadLibros = 3, Genero = "Teatro", NombreLibro = "Romeo y Julieta" });
                _context.Books.Add(new Book { AutorLibro = "William Shakespeare", CantidadLibros = 2, Genero = "Teatro", NombreLibro = "Hamlet" });
                _context.Books.Add(new Book { AutorLibro = "William Shakespeare", CantidadLibros = 1, Genero = "Teatro", NombreLibro = "El sueño de una noche de verano" });


            }
        }

    }
}
