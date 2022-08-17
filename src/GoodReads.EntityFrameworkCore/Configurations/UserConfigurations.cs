using GoodReads.Core.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodReads.EntityFrameworkCore.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.ToTable("Users");

            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .IsUnicode(false)
                .IsRequired();

        }
    }

    internal class UserBookConfiguration : IEntityTypeConfiguration<UserBook>
    {
        public void Configure(EntityTypeBuilder<UserBook> entity)
        {
            entity.ToTable("Users_Books");

            entity.HasKey(e => new { e.UserId, e.BookId });
        }
    }
}
