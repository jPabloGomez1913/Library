using Microsoft.EntityFrameworkCore;

namespace LibraryProyect.DAL
{
    public class DataBaseContext : DbContext 
    {
        
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
    }
}
