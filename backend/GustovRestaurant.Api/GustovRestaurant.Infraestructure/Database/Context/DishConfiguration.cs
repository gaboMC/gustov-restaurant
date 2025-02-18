using GustovRestaurant.Infraestructure.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GustovRestaurant.Infraestructure.Database.Context;

public class DishConfiguration : IEntityTypeConfiguration<DishEntity>
{
    public void Configure(EntityTypeBuilder<DishEntity> builder)
    {
        builder.ToTable("Dish", "dbo")
            .HasComment("Table Dishes");
        
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();
        builder.Property(d => d.Name)
            .HasColumnName("name")
            .HasColumnType("varchar(200)")
            .IsRequired();
        builder.Property(d => d.Description)
            .HasColumnName("description")
            .HasColumnType("varchar(300)")
            .IsRequired();
        builder.Property(d => d.Price)
            .HasColumnName("price")
            .HasColumnType("decimal(10,2)")
            .IsRequired();
        builder.Property(d => d.IsActive)
            .HasColumnName("isActive")
            .HasColumnType("bit")
            .IsRequired();

    }
}