using GustovRestaurant.Infraestructure.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GustovRestaurant.Infraestructure.Database.Context;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("User", "dbo")
            .HasComment("Table Users");
        
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();
        builder.Property(u => u.Name)
            .HasColumnName("name")
            .IsRequired();
        builder.Property(u => u.Role)
            .HasColumnName("role")
            .IsRequired();
        builder.Property(u => u.RegistrationDate)
            .HasColumnName("registrationDate")
            .IsRequired();
        
    }
}