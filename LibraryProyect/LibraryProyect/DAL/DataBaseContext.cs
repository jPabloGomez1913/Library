using LibraryProyect.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryProyect.DAL
{
    public class DataBaseContext : DbContext
    {

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {


        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {



            base.OnModelCreating(modelBuilder);
            //Creacion del indice del estudiante
            modelBuilder.Entity<Student>().HasIndex(s => s.StudentCode).IsUnique();
            //Creacion del indice del empleado
            modelBuilder.Entity<Employee>().HasIndex(s => s.EmployeeCode).IsUnique();
            //Creacion del indice del docente
            modelBuilder.Entity<Teacher>().HasIndex(s => s.TeacherCode).IsUnique();

            //Creacion de relacion muchos a muchos entre Person-Book

            modelBuilder.Entity<Loan>()
                .HasOne(b => b.Book) //Tiene un libro con muchos prestamos
                .WithMany(l => l.Loans)
                .HasForeignKey(bi => bi.idLibro);

            modelBuilder.Entity<Loan>()
               .HasOne(p => p.Person) //Tiene una persona con muchos prestamos
               .WithMany(l => l.Loans)
               .HasForeignKey(pi => pi.idPersona);

        }


        
        



        }
}
