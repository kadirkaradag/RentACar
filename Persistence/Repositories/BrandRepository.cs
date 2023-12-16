
using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BrandRepository : EfRepositoryBase<Brand, Guid, BaseDbContext>, IBrandRepository
{
    public BrandRepository(BaseDbContext context): base(context)  // EfRepositoryBase in bir context e ihtiyacı var, biz de ilgili basedbcontext imizi oraya veriyoruz.
    {
        
    }
}
