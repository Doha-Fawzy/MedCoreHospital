using MedCoreHospital.Enums;
using MedCoreHospital.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.Property(p => p.BloodType)
               .IsRequired();

        builder.OwnsOne(p => p.Allergies, a =>
        {
            a.Property(x => x.Food).HasMaxLength(500);
            a.Property(x => x.Medicine).HasMaxLength(500);
        });
        builder.OwnsOne(p => p.ChronicConditions, c =>
        {
            c.Property(x => x.Diseases).HasMaxLength(500);
        });

            builder.Property<DateTime>("CreatedAt")
            .HasDefaultValueSql("GETUTCDATE()");
        //Concrete Property
        builder.Property(p => p.LastModified)
               .HasDefaultValueSql("GETUTCDATE()")
               .ValueGeneratedOnAddOrUpdate();

        builder.HasData(
            new Patient
            {
                Id = 1,
                FullName = "Ali Hassan",
                NationalId = "987654321",
                DateOfBirth = new DateTime(1995, 3, 1),
                Gender = Gender.Male,
                BloodType = BloodType.A
            }
        );
       builder.OwnsOne(p => p.Allergies).HasData(
            new { PatientId = 1, Food = (string?)null, Medicine = (string?)null }
        );

       builder.OwnsOne(p => p.ChronicConditions).HasData(
            new { PatientId = 1, Diseases = (string?)null }
        );
    }
}
