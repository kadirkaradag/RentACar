using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>  // BaseDbContext içindeki modelBuilder.ApplyConfigurationsFromAssembly kodu IEntityTypeConfiguration interface ini impelemnte eden classları arayacak ve BrandConfiguration'ı bulup kullanacak.
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.ToTable("Brands").HasKey(b=>b.Id); // hangi tabloya denk gelecek

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.Name).HasColumnName("Name").IsRequired();
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("UpdatedDate");

        //brand ile ilgili sorgulama yapıldıgında her sorguda mutlaka eklemek istedigimiz global filtre ekleyeceğiz. mesela default olarak silinenleri getirme gibi.

        builder.HasQueryFilter(b=>!b.DeletedDate.HasValue); // DeletedDate verisi yoksa bunu uygula dedik.

    }
}
