using Microsoft.EntityFrameworkCore;

namespace Webbapi.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }

        public DbSet<Restaurang> restauranger {get; set;}
    }
}