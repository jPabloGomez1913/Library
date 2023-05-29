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

        protected override void OnModelCreating(ModelBuilder modelBuilder) { 

            base.OnModelCreating(modelBuilder);
            //Creacion del indice del estudiante
            modelBuilder.Entity<Student>().HasIndex(s =>s.StudentCode).IsUnique();
            //Creacion del indice del empleado
            modelBuilder.Entity<Employee>().HasIndex(s =>s.EmployeeCode).IsUnique();
            //Creacion del indice del docente
            modelBuilder.Entity<Teacher>().HasIndex(s =>s.TeacherCode).IsUnique();
        }




    }
}
