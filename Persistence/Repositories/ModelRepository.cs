
using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ModelRepository : EfRepositoryBase<Model, Guid, BaseDbContext>, IModelRepository
{
    public ModelRepository(BaseDbContext context) : base(context)  // EfRepositoryBase in bir context e ihtiyacı var, biz de ilgili basedbcontext imizi oraya veriyoruz.
    {

    }
}

