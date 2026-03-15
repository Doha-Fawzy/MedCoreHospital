using MedCoreHospital.Enums;
using MedCoreHospital.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.Property(d => d.LicenseNumber)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(d => d.HourRate)
               .HasColumnType("decimal(10,2)");
//==============================================
        builder.Property(d => d.Schedules)
            .IsRequired();
//==============================================
        builder.HasOne(d => d.Specialty)
               .WithMany(s => s.Doctors)
               .HasForeignKey(d => d.SpecialtyId)
               .OnDelete(DeleteBehavior.Restrict);
        builder.Property<DateTime>("CreatedAt")
            .HasDefaultValueSql("GETUTCDATE()");
        //Concrete Property
        builder.Property(d => d.LastModified)
               .HasDefaultValueSql("GETUTCDATE()")
               .ValueGeneratedOnAddOrUpdate();
        builder.HasData(
        new Doctor
        {
            Id = 1,
            FullName = "Dr Ahmed",
            NationalId = "123456789",
            DateOfBirth = new DateTime(1980, 5, 10),
            Gender = Gender.Male,
            SpecialtyId = 1,
            HourRate = 500,
            LicenseNumber = "DOC123"
        }
    );

    }
}
