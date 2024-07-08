using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UBC.Students.Domain.Domain.Entities;
using UBC.Students.Domain.Entities;

public class StudentMap : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Age).IsRequired();
        builder.Property(e => e.Grade).IsRequired();
        builder.Property(e => e.AverageGrade);
        builder.Property(e => e.Address).HasMaxLength(200);
        builder.Property(e => e.FatherName).HasMaxLength(100);
        builder.Property(e => e.MotherName).HasMaxLength(100);
        builder.Property(e => e.BirthDate);
        builder.Property(e => e.CreatedDate);
        builder.Property(e => e.LastUpdatedDate);
    }
}