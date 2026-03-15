using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MedCoreHospital.Models;

public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
{
    public void Configure(EntityTypeBuilder<Prescription> builder)
    {
        builder.HasKey(p => new { p.AppointmentId, p.MedicationId });

        builder.Property(p => p.Dosage)
               .IsRequired();

        builder.Property(p => p.Frequency)
               .IsRequired();

        builder.HasOne(p => p.Appointment)
               .WithMany(a => a.Prescriptions)
               .HasForeignKey(p => p.AppointmentId);

        builder.HasOne(p => p.Medication)
               .WithMany(m => m.Prescriptions)
               .HasForeignKey(p => p.MedicationId);

        builder.Property<DateTime>("CreatedAt")
            .HasDefaultValueSql("GETUTCDATE()");
        //Concrete Property
        builder.Property(p => p.LastModified)
               .HasDefaultValueSql("GETUTCDATE()")
               .ValueGeneratedOnAddOrUpdate();

        builder.HasData(
        new Prescription
        {
            AppointmentId = 1,
            MedicationId = 1,
            Dosage = "100mg",
            Frequency = "Once a day"
        }
    );
    }
}
