using Microsoft.EntityFrameworkCore;
using Web_api.Models;

namespace Web_api.Data
{
    public class Datacontext : DbContext
    {
        public Datacontext(DbContextOptions<Datacontext> options) : base(options)
            {

            }
        public DbSet<Character> Characters { get; set; }
        
    }
}
