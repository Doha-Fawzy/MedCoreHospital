using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MedCoreHospital.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

public class MedicationConfiguration : IEntityTypeConfiguration<Medication>
{
    public void Configure(EntityTypeBuilder<Medication> builder)
    {
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.HasQueryFilter(m => !m.IsDeleted);
        //Shadow property t
        builder.Property<DateTime>("CreatedAt")
            .HasDefaultValueSql("GETUTCDATE()");
        //Concrete Property
        builder.Property(m => m.LastModified)
               .HasDefaultValueSql("GETUTCDATE()")  
               .ValueGeneratedOnAddOrUpdate();

        builder.Property(m => m.GenericName)
               .HasMaxLength(100);

        builder.HasData(
        new Medication { Id = 1, Name = "Aspirin", GenericName = "Acetylsalicylic Acid" },
        new Medication { Id = 2, Name = "Paracetamol", GenericName = "Acetaminophen" }
    );

    }
}
