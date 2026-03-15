using Microsoft.EntityFrameworkCore;
using MedCoreHospital.Models;
namespace MedCoreHospital.Data;

public class HospitalDbContext : DbContext
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Specialty> Specialties { get; set; }
    public DbSet<DoctorSchedule> Schedules { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Medication> Medications { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=.;Database=MedCoreHospital;Trusted_Connection=True;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HospitalDbContext).Assembly);
        //Shadow Property "CreatedAt"

        //foreach (var entity in modelBuilder.Model.GetEntityTypes())
        //{
        //    modelBuilder.Entity(entity.ClrType)
        //                .Property<DateTime>("CreatedAt");
        //}
    }
}

