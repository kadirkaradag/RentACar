﻿
using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class FuelRepository : EfRepositoryBase<Fuel, Guid, BaseDbContext>, IFuelRepository
{
    public FuelRepository(BaseDbContext context) : base(context)  // EfRepositoryBase in bir context e ihtiyacı var, biz de ilgili basedbcontext imizi oraya veriyoruz.
    {

    }
}

