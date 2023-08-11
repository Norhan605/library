
using Job_task.Models.Book;
using Job_task.Models.Borrower;
using Microsoft.EntityFrameworkCore;

namespace Job_task.Models
{
    public class Context:DbContext
    {
        public DbSet<Borrowers> Borrowers { get; set; }
        public DbSet<Books> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new BookConfigration().Configure(modelBuilder.Entity<Books>());
            new BorrowerConfigration().Configure(modelBuilder.Entity<Borrowers>());
            modelBuilder.MapRelations();

          
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source =.; Initial Catalog = JobTask; Integrated Security = True; TrustServerCertificate=True");
        }

    }
}
