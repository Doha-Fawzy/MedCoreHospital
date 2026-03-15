using MedCoreHospital.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DoctorScheduleConfiguration : IEntityTypeConfiguration<DoctorSchedule>
{
    public void Configure(EntityTypeBuilder<DoctorSchedule> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.IsBooked)
               .HasDefaultValue(false);

        builder.Property(s => s.Version)
               .IsRowVersion();

        builder.HasOne(s => s.Doctor)
               .WithMany(d => d.Schedules)
               .HasForeignKey(s => s.DoctorId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(s => s.Appointment)
               .WithOne(a => a.Schedule)
               .HasForeignKey<Appointment>(a => a.ScheduleId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasQueryFilter(s => !s.IsDeleted);
        //Shadow Property
        builder.Property<DateTime>("CreatedAt")
            .HasDefaultValueSql("GETUTCDATE()");
        //Concrete Property
        builder.Property(s => s.LastModified)
               .HasDefaultValueSql("GETUTCDATE()")
               .ValueGeneratedOnAddOrUpdate();

        builder.ToTable(t =>
        {
            t.HasCheckConstraint(
                "CK_DoctorSchedule_Time",
                "EndTime > StartTime"
            );
        });

        builder.HasData(
        new DoctorSchedule
        {
            Id = 1,
            DoctorId = 1,
            StartTime = new DateTime(2025, 1, 1, 10, 0, 0),
            EndTime = new DateTime(2025, 1, 1, 11, 0, 0),
            IsBooked = false
        }
    );
    }
}
