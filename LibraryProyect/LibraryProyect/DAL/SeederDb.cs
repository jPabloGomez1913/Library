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
            await PopulateStudentsAsync();
            await PopulateTeachersAsync();
            await PopulateEmployeesAsync();
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
                // _context.Books.Add(new Book { AutorLibro = "", CantidadLibros = 0, Genero = "", NombreLibro = "" });
                _context.Books.Add(new Book { AutorLibro = "Oscar Wilde", CantidadLibros = 2, Genero = "Drama", NombreLibro = "El retrato de Dorian Gray" });
                _context.Books.Add(new Book { AutorLibro = "Oscar Wilde", CantidadLibros = 1, Genero = "Comedia", NombreLibro = "El hombre que contaba historias" });
                _context.Books.Add(new Book { AutorLibro = "Oscar Wilde", CantidadLibros = 3, Genero = "Drama", NombreLibro = "El princi" });
                _context.Books.Add(new Book { AutorLibro = "Jorge Luis Borges", CantidadLibros = 2, Genero = "Ficción", NombreLibro = "Ficciones" });
                _context.Books.Add(new Book { AutorLibro = "Franz Kafka", CantidadLibros = 2, Genero = "Ficcion", NombreLibro = "La metamorfosis" });
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
                _context.Books.Add(new Book { AutorLibro = "J.R.R. Tolkien", CantidadLibros = 3, Genero = "Fantasía épica", NombreLibro = "El Señor de los Anillos" });
                _context.Books.Add(new Book { AutorLibro = "Virginia Woolf", CantidadLibros = 2, Genero = "Feminismo", NombreLibro = "La señora Dalloway" });
                _context.Books.Add(new Book { AutorLibro = "Julio Verne", CantidadLibros = 3, Genero = "Ciencia ficción", NombreLibro = "Veinte mil leguas de viaje submarino" });
                _context.Books.Add(new Book { AutorLibro = "Emily Brontë", CantidadLibros = 2, Genero = "Romance gótico", NombreLibro = "Cumbres borrascosas" });
                _context.Books.Add(new Book { AutorLibro = "Albert Camus", CantidadLibros = 2, Genero = "Filosofía", NombreLibro = "La peste" });
                _context.Books.Add(new Book { AutorLibro = "Leo Tolstoy", CantidadLibros = 4, Genero = "Novela histórica", NombreLibro = "Guerra y paz" });
                _context.Books.Add(new Book { AutorLibro = "Miguel de Cervantes", CantidadLibros = 3, Genero = "Novela de caballerías", NombreLibro = "Don Quijote de la Mancha" });
                _context.Books.Add(new Book { AutorLibro = "Harper Lee", CantidadLibros = 2, Genero = "Novela clásica", NombreLibro = "Matar a un ruiseñor" });

            }
        }

        //    b.Property<string>("StudentCode")
        //    b.HasIndex("StudentCode")

        private async Task PopulateStudentsAsync()
        {
            if (!_context.Students.Any())
            {
                _context.Students.Add(new Student { Nombre = "John", Apellido = "Doe", StudentCode = "AB1D23" });
                _context.Students.Add(new Student { Nombre = "Jane", Apellido = "Smith", StudentCode = "CD4D56" });
                _context.Students.Add(new Student { Nombre = "Michael", Apellido = "Johnson", StudentCode = "EF78D9" });
                _context.Students.Add(new Student { Nombre = "Aarav", Apellido = "Patel", StudentCode = "ABCD3DEF" });
                _context.Students.Add(new Student { Nombre = "Aanya", Apellido = "Sharma", StudentCode = "GHID6JKL" });
                _context.Students.Add(new Student { Nombre = "Advait", Apellido = "Verma", StudentCode = "MNO79PQR" });
                _context.Students.Add(new Student { Nombre = "Ahana", Apellido = "Gupta", StudentCode = "STUD12VWX" });
                _context.Students.Add(new Student { Nombre = "Akshay", Apellido = "Mukherjee", StudentCode = "DEG7HIJ" });
                _context.Students.Add(new Student { Nombre = "Amaya", Apellido = "Banerjee", StudentCode = "KLM901OP" });
                _context.Students.Add(new Student { Nombre = "Anaya", Apellido = "Dutta", StudentCode = "QRS24TDUV" });
                _context.Students.Add(new Student { Nombre = "Emily", Apellido = "Williams", StudentCode = "GH012D" });
                _context.Students.Add(new Student { Nombre = "David", Apellido = "Brown", StudentCode = "IJ3D45" });
                _context.Students.Add(new Student { Nombre = "Olivia", Apellido = "Miller", StudentCode = "KLD678" });
                _context.Students.Add(new Student { Nombre = "Daniel", Apellido = "Davis", StudentCode = "MN90D1" });
                _context.Students.Add(new Student { Nombre = "Sophia", Apellido = "Moore", StudentCode = "OP234D" });
                _context.Students.Add(new Student { Nombre = "James", Apellido = "Wilson", StudentCode = "QR5D67" });
                _context.Students.Add(new Student { Nombre = "Isabella", Apellido = "Taylor", StudentCode = "SDT890" });
                _context.Students.Add(new Student { Nombre = "William", Apellido = "Anderson", StudentCode = "UVD123" });
                _context.Students.Add(new Student { Nombre = "Mia", Apellido = "Thomas", StudentCode = "WX4D56" });
                _context.Students.Add(new Student { Nombre = "Benjamin", Apellido = "Jackson", StudentCode = "YFZ789" });
                _context.Students.Add(new Student { Nombre = "Ava", Apellido = "White", StudentCode = "12ABG3" });
                _context.Students.Add(new Student { Nombre = "Noah", Apellido = "Smith", StudentCode = "GI4G56Jy" });
                _context.Students.Add(new Student { Nombre = "Olivia", Apellido = "Williams", StudentCode = "SO7FGPQR" });
                _context.Students.Add(new Student { Nombre = "Ava", Apellido = "Miller", StudentCode = "YZA35BFCD" });
                _context.Students.Add(new Student { Nombre = "Ethan", Apellido = "Harris", StudentCode = "34CDH6" });
                _context.Students.Add(new Student { Nombre = "Charlotte", Apellido = "Martin", StudentCode = "5R6EF7" });
                _context.Students.Add(new Student { Nombre = "Alexander", Apellido = "Thompson", StudentCode = "7D8GH0" });
                _context.Students.Add(new Student { Nombre = "Harper", Apellido = "Garcia", StudentCode = "91IJ3S" });
                _context.Students.Add(new Student { Nombre = "Henry", Apellido = "Martinez", StudentCode = "45KLV6" });
                _context.Students.Add(new Student { Nombre = "Amelia", Apellido = "Robinson", StudentCode = "78MNJ9" });
                _context.Students.Add(new Student { Nombre = "Daniel", Apellido = "Clark", StudentCode = "01OPR2" });
                _context.Students.Add(new Student { Nombre = "Abigail", Apellido = "Rodriguez", StudentCode = "3E4QR5" });
                _context.Students.Add(new Student { Nombre = "Matthew", Apellido = "Lee", StudentCode = "67STE8" });
                _context.Students.Add(new Student { Nombre = "Elizabeth", Apellido = "Walker", StudentCode = "9G0UV1" });
                _context.Students.Add(new Student { Nombre = "Sofia", Apellido = "Hall", StudentCode = "23WXG4" });
                _context.Students.Add(new Student { Nombre = "Joseph", Apellido = "Lopez", StudentCode = "56YFZ7" });

            }

        }

        //b.Property<string>("TeacherCode")
        //b.HasIndex("TeacherCode")

        private async Task PopulateTeachersAsync()
        {
            if (!_context.Teachers.Any())
            {
                
                _context.Teachers.Add(new Teacher { Nombre = "Juan", Apellido = "García", TeacherCode = "AB123GCD" });
                _context.Teachers.Add(new Teacher { Nombre = "María", Apellido = "López", TeacherCode = "EF456GDH" });
                _context.Teachers.Add(new Teacher { Nombre = "José", Apellido = "Martínez", TeacherCode = "IJ78A9KL" });
                _context.Teachers.Add(new Teacher { Nombre = "Carmen", Apellido = "Rodríguez", TeacherCode = "MNF012OP" });
                _context.Teachers.Add(new Teacher { Nombre = "Manuel", Apellido = "González", TeacherCode = "QR345SST" });
                _context.Teachers.Add(new Teacher { Nombre = "Ana", Apellido = "Fernández", TeacherCode = "UV678WSX" });
                _context.Teachers.Add(new Teacher { Nombre = "Francisco", Apellido = "Hernández", TeacherCode = "YSZ901AB" });
                _context.Teachers.Add(new Teacher { Nombre = "Isabel", Apellido = "Gómez", TeacherCode = "CD234EFD" });
                _context.Teachers.Add(new Teacher { Nombre = "Antonio", Apellido = "Sánchez", TeacherCode = "GH567DIJ" });
                _context.Teachers.Add(new Teacher { Nombre = "Marta", Apellido = "Moreno", TeacherCode = "KL890MEN" });
                _context.Teachers.Add(new Teacher { Nombre = "David", Apellido = "Flores", TeacherCode = "OP123QFR" });
                _context.Teachers.Add(new Teacher { Nombre = "Laura", Apellido = "Castillo", TeacherCode = "ST45F6UV" });
                _context.Teachers.Add(new Teacher { Nombre = "Pedro", Apellido = "Jiménez", TeacherCode = "WX789EYZ" });
                _context.Teachers.Add(new Teacher { Nombre = "Sara", Apellido = "Ortega", TeacherCode = "12AB34HC" });
                _context.Teachers.Add(new Teacher { Nombre = "Javier", Apellido = "Navarro", TeacherCode = "56DETF7G" });
                _context.Teachers.Add(new Teacher { Nombre = "Elena", Apellido = "Vargas", TeacherCode = "89HI01RJ" });
                _context.Teachers.Add(new Teacher { Nombre = "Carlos", Apellido = "Molina", TeacherCode = "23KL4H5M" });
                _context.Teachers.Add(new Teacher { Nombre = "Luisa", Apellido = "Soto", TeacherCode = "67NO8R9P" });
                _context.Teachers.Add(new Teacher { Nombre = "Andrés", Apellido = "Cortés", TeacherCode = "QR1H23ST" });
                _context.Teachers.Add(new Teacher { Nombre = "Lucía", Apellido = "Ruiz", TeacherCode = "UV456WHX" });
                _context.Teachers.Add(new Teacher { Nombre = "Fernando", Apellido = "Rojas", TeacherCode = "YZ7H89AB" });
                _context.Teachers.Add(new Teacher { Nombre = "Marina", Apellido = "Giménez", TeacherCode = "CD01H2EF" });
                _context.Teachers.Add(new Teacher { Nombre = "Pablo", Apellido = "Silva", TeacherCode = "GH345IJ" });
                _context.Teachers.Add(new Teacher { Nombre = "Rosa", Apellido = "Pérez", TeacherCode = "KL678MJN" });
                _context.Teachers.Add(new Teacher { Nombre = "Roberto", Apellido = "Herrera", TeacherCode = "OPJ901QR" });
                _context.Teachers.Add(new Teacher { Nombre = "Patricia", Apellido = "Flores", TeacherCode = "ST2J34UV" });
                _context.Teachers.Add(new Teacher { Nombre = "Diego", Apellido = "Morales", TeacherCode = "WX567TYZ" });
                _context.Teachers.Add(new Teacher { Nombre = "María José", Apellido = "Sánchez", TeacherCode = "1RR2AB3CD" });
                _context.Teachers.Add(new Teacher { Nombre = "Sergio", Apellido = "Ramírez", TeacherCode = "45EF6GRH" });
                _context.Teachers.Add(new Teacher { Nombre = "Beatriz", Apellido = "Delgado", TeacherCode = "78IJ9KYL" });


            }
        }

        //b.Property<string>("EmployeeCode")
        private async Task PopulateEmployeesAsync()
        {
            if (!_context.Employees.Any())
            {
                
                _context.Employees.Add(new Employee { Nombre = "Juan", Apellido = "Smith", EmployeeCode = "ABC12345" });
                _context.Employees.Add(new Employee { Nombre = "Maria", Apellido = "Johnson", EmployeeCode = "EYF67890" });
                _context.Employees.Add(new Employee { Nombre = "Carlos", Apellido = "Williams", EmployeeCode = "UHI23456" });
                _context.Employees.Add(new Employee { Nombre = "Laura", Apellido = "Brown", EmployeeCode = "JKL89I01" });
                _context.Employees.Add(new Employee { Nombre = "Luis", Apellido = "Miller", EmployeeCode = "MN234G56" });
                _context.Employees.Add(new Employee { Nombre = "Ana", Apellido = "Taylor", EmployeeCode = "PQ7890S1" });
                _context.Employees.Add(new Employee { Nombre = "Andres", Apellido = "Anderson", EmployeeCode = "STUD2456" });
                _context.Employees.Add(new Employee { Nombre = "Sofia", Apellido = "Davis", EmployeeCode = "VWX7890D" });
                _context.Employees.Add(new Employee { Nombre = "David", Apellido = "Wilson", EmployeeCode = "YZA23D56" });
                _context.Employees.Add(new Employee { Nombre = "Isabella", Apellido = "Thomas", EmployeeCode = "BCD78901" });
                _context.Employees.Add(new Employee { Nombre = "Felipe", Apellido = "Jackson", EmployeeCode = "EF23D456" });
                _context.Employees.Add(new Employee { Nombre = "Valentina", Apellido = "Harris", EmployeeCode = "IJ7D8901" });
                _context.Employees.Add(new Employee { Nombre = "Javier", Apellido = "Clark", EmployeeCode = "KLM34Y56" });
                _context.Employees.Add(new Employee { Nombre = "Camila", Apellido = "Lewis", EmployeeCode = "NO7890Y1" });
                _context.Employees.Add(new Employee { Nombre = "Gabriel", Apellido = "Young", EmployeeCode = "RS23Y456" });
                _context.Employees.Add(new Employee { Nombre = "Mariana", Apellido = "Allen", EmployeeCode = "TUV78901" });
                _context.Employees.Add(new Employee { Nombre = "Alejandro", Apellido = "Lee", EmployeeCode = "WXY2456" });
                _context.Employees.Add(new Employee { Nombre = "Juliana", Apellido = "Martin", EmployeeCode = "ZA78I901" });
                _context.Employees.Add(new Employee { Nombre = "Sebastian", Apellido = "Walker", EmployeeCode = "CDE2I456" });
                _context.Employees.Add(new Employee { Nombre = "Natalia", Apellido = "Roberts", EmployeeCode = "FGH78901" });
                _context.Employees.Add(new Employee { Nombre = "Diego", Apellido = "Thompson", EmployeeCode = "IJK235W6" });
                _context.Employees.Add(new Employee { Nombre = "Carolina", Apellido = "Hill", EmployeeCode = "LMN78901" });
                _context.Employees.Add(new Employee { Nombre = "Daniel", Apellido = "Adams", EmployeeCode = "OPQ235K6" });
                _context.Employees.Add(new Employee { Nombre = "Valeria", Apellido = "Mitchell", EmployeeCode = "ST7G8901" });
                _context.Employees.Add(new Employee { Nombre = "Nicolas", Apellido = "Cook", EmployeeCode = "UVW34Y56" });
                _context.Employees.Add(new Employee { Nombre = "Antonella", Apellido = "Campbell", EmployeeCode = "XRY78901" });
                _context.Employees.Add(new Employee { Nombre = "Mateo", Apellido = "Parker", EmployeeCode = "1232345E" });
                _context.Employees.Add(new Employee { Nombre = "Daniela", Apellido = "Evans", EmployeeCode = "456789W1" });
                _context.Employees.Add(new Employee { Nombre = "Elias", Apellido = "Stewart", EmployeeCode = "7892356W" });
                _context.Employees.Add(new Employee { Nombre = "Catalina", Apellido = "Morris", EmployeeCode = "017890Q1" });
                _context.Employees.Add(new Employee { Nombre = "Simon", Apellido = "Sanders", EmployeeCode = "345345P6" });
            }   
        }
    }
}
