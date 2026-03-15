using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MedCoreHospital.Models;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Primary Key
        builder.HasKey(u => u.Id);

        // Unique National ID
        builder.HasIndex(u => u.NationalId)
               .IsUnique();

        // Check Constraint
        builder.ToTable(t =>
        {
            t.HasCheckConstraint(
                "CK_User_DOB",
                "DateOfBirth < GETDATE()"
            );
        });

        // Concurrency Token (RowVersion)
        builder.Property(u => u.Version)
               .IsRowVersion();

        // Soft Delete Global Filter
        builder.HasQueryFilter(u => !u.IsDeleted);

        builder.Property<DateTime>("CreatedAt")
            .HasDefaultValueSql("GETUTCDATE()");
        //Concrete Property
        builder.Property(u => u.LastModified)
               .HasDefaultValueSql("GETUTCDATE()")
               .ValueGeneratedOnAddOrUpdate();
    }
}