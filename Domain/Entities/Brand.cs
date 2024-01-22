using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Brand : Entity<Guid>
{
    public string Name { get; set; }

    public virtual ICollection<Model> Models { get; set; }  //virtual kullanmanın entity framework icin bir esprisi yok aslında Nhibernate falan vaktinde virtual istiyormus
    public Brand()
    {
        Models = new HashSet<Model>();
    }

    public Brand(Guid id, string name):this()
    {
        Id = id;
        Name = name;
    }
}
