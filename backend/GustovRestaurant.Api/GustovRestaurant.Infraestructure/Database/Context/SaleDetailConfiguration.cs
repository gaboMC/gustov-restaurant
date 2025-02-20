using GustovRestaurant.Infraestructure.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GustovRestaurant.Infraestructure.Database.Context;

public class SaleDetailConfiguration : IEntityTypeConfiguration<SaleDetailEntity>
{
    public void Configure(EntityTypeBuilder<SaleDetailEntity> builder)
    {
        builder.ToTable("SaleDetail", "dbo")
            .HasComment("Table Dishes detail");
        
        builder.Property(sd => sd.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();
        builder.Property(sd => sd.SaleId)
            .HasColumnName("saleId")
            .IsRequired();
        builder.Property(sd => sd.DishId)
            .HasColumnName("dishId")
            .IsRequired();
        builder.Property(sd => sd.Quantity)
            .HasColumnName("quantity")
            .IsRequired();
        builder.Property(sd => sd.Price)
            .HasColumnName("price")
            .HasColumnType("decimal(10,2)")
            .IsRequired();
        
        builder.HasOne(sd => sd.Sale)
            .WithMany(s => s.SaleDetails)
            .HasForeignKey(sd => sd.SaleId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(sd => sd.Dish)
            .WithMany(d => d.SaleDetails)
            .HasForeignKey(d => d.DishId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}