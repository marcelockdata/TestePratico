using MHP.API.Models;
using Microsoft.EntityFrameworkCore;


namespace MHP.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Predio> Predio { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Ignore<Client>();
            base.OnModelCreating(builder);
        }

    }
}
