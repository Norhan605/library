using Job_task.Models.Book;
using Job_task.Models.Borrower;
using Microsoft.EntityFrameworkCore;

namespace Job_task.Models
{
    public static class RelationalMapping
    {
        public static void MapRelations(this ModelBuilder builder)
        {

            builder.Entity<Books>().HasMany<Borrowers>();
            
        }
    }
}
