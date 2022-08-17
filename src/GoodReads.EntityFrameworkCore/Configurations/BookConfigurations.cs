using GoodReads.Core.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodReads.EntityFrameworkCore.Configurations
{
    internal class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> entity)
        {
            entity.ToTable("Books");

            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .IsUnicode(false)
                .IsRequired();

        }
    }
}
