using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UBC.Students.Domain.Entities;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.Username).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Password).IsRequired();
        builder.Property(e => e.CreatedDate);
        builder.Property(e => e.LastUpdatedDate);
    }
}