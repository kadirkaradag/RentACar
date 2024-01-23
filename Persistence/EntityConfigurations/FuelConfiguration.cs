using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class FuelConfiguration : IEntityTypeConfiguration<Fuel>  // BaseDbContext içindeki modelBuilder.ApplyConfigurationsFromAssembly kodu IEntityTypeConfiguration interface ini impelemnte eden classları arayacak ve BrandConfiguration'ı bulup kullanacak.
{
    public void Configure(EntityTypeBuilder<Fuel> builder)
    {
        builder.ToTable("Fuels").HasKey(b => b.Id); // hangi tabloya denk gelecek

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.Name).HasColumnName("Name").IsRequired();
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(b => b.Name, name: "UK_Fuels_Name").IsUnique();  //fuel adı unique.

        builder.HasMany(b => b.Models); //bu yakıt tipinde bir sürü model olabilir

        builder.HasQueryFilter(b => !b.DeletedDate.HasValue); 
    }
}
