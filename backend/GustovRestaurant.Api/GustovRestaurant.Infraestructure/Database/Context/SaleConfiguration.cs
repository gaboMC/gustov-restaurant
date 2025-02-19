using GustovRestaurant.Infraestructure.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GustovRestaurant.Infraestructure.Database.Context;

public class SaleConfiguration : IEntityTypeConfiguration<SaleEntity>
{
    public void Configure(EntityTypeBuilder<SaleEntity> builder)
    {
        builder.ToTable("Sale", "dbo")
            .HasComment("Table Dishes");
        
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();
        builder.Property(d => d.Date)
            .HasColumnName("date")
            .HasColumnType("datetime2(3)")
            .IsRequired();
        builder.Property(d => d.Total)
            .HasColumnName("total")
            .HasColumnType("decimal(10,2)")
            .IsRequired();
        builder.Property(d => d.UserId)
            .HasColumnName("userId")
            .IsRequired();

        builder.HasOne(s => s.User)
            .WithMany(u => u.Sales)
            .HasForeignKey(s => s.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}