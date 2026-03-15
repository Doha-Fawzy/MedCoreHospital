using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MedCoreHospital.Models;

public class SpecialtyConfiguration : IEntityTypeConfiguration<Specialty>
{
    public void Configure(EntityTypeBuilder<Specialty> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(s => s.Description)
               .HasMaxLength(500);

        builder.Property<DateTime>("CreatedAt")
            .HasDefaultValueSql("GETUTCDATE()");
        //Concrete Property
        builder.Property(s => s.LastModified)
               .HasDefaultValueSql("GETUTCDATE()")
               .ValueGeneratedOnAddOrUpdate();
        builder.HasData(
        new Specialty { Id = 1, Name = "Cardiology", Description = "Heart specialist" },
        new Specialty { Id = 2, Name = "Neurology", Description = "Brain and nerves" }
    );
    }
}
