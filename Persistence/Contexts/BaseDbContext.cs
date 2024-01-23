using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Persistence.Contexts;

public class BaseDbContext :DbContext
{
    protected IConfiguration Configuration { get; set; } //inherit eden sınıflar kullanabilsin diye protected. IConfiguration bize örneği db yolunu okuyabilmek için vs lazım up settings i okuyabilmek icin
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<Fuel> Fuels { get; set; }
    public DbSet<Transmission> Transmissions { get; set; }

    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    {
        Configuration = configuration;
        //Database.EnsureCreated(); // db oluşturuldu mu emin ol
    }

    //brand i oldugu gibi kullanmak istemiyoruz kendi configurasyonlarımız yapmak istiyoruz. bunun icin onModelCreating override ediyoruz. mesela brand hangi alanı neye karsılık gelecek vs.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // mevcut assembly deki configurasyonları bul onları uygula. EntityConfigurations klasörü altında olacaklar.
    }
}
