using MedCoreHospital.Enums;
using MedCoreHospital.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Status)
               .IsRequired();

        builder.Property(a => a.Version)
               .IsRowVersion();

        builder.HasOne(a => a.Patient)
               .WithMany(p => p.Appointments)
               .HasForeignKey(a => a.PatientId);

        builder.HasMany(a => a.Prescriptions)
               .WithOne(p => p.Appointment)
               .HasForeignKey(p => p.AppointmentId);
        //soft delete
        builder.HasQueryFilter(a => a.IsDeleted == false);
        //Shadow Property 
        builder.Property<DateTime>("CreatedAt")
            .HasDefaultValueSql("GETUTCDATE()");

        //Concrete Property
        builder.Property(a => a.LastModified)
               .HasDefaultValueSql("GETUTCDATE()") 
               .ValueGeneratedOnAddOrUpdate();
        builder.HasData(
        new Appointment
        {
            Id = 1,
            PatientId = 2,
            ScheduleId = 1,
            Status = AppointmentStatus.Pending,
            IsDeleted = false
        }
    );
    }
}
