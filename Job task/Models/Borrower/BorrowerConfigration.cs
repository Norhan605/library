using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Job_task.Models.Borrower
{
    public class BorrowerConfigration : IEntityTypeConfiguration<Borrowers>
    {
        public void Configure(EntityTypeBuilder<Borrowers> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasMaxLength(100);
        }
    }
}
