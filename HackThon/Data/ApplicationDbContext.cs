using HackThon.Models;
using Microsoft.EntityFrameworkCore;

namespace HackThon.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<House> Houses { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=(localdb)\\Local;Database=HackThon;Trusted_Connection=True;");
        }
    }
}
