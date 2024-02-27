using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.Create;

public class CreateBrandCommand : IRequest<CreatedBrandResponse> , ITransactionalRequest, ICacheRemoverRequest
// ITransactionalRequest, bir yapıda 2 tablo değişiyorsa biri patlarsa diğeri de geri alınsın diye yaptıgımız bir yapı
// bir request olduğu için IRequest interface inden türeyecek. Apiden bir CreateBrandCommand gelecek, biz bunu brand domainine cevirip db ye kaydedeceğiz.
// IRequest interface inde <> içerisine CreateBrandCommand gelince IRequest'in ona geri ne döndüreceğini vermemizi istiyor yani bir response modeli, o da CreatedBrandResponse olacak
//Mediator ne yapıyor ? , IRequest gördü, aa benimle ilgili bir şey var dedi benim bunu handle etmem lazım dedi bunu da her command'ın handler i var onunla yapıyor.
{
    public string Name { get; set; }

    public string CacheKey => "";

    public bool BypassCache => false;

    public string? CacheGroupKey => "GetBrands";

    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandResponse> // yani sana CreateBrandCommand böyle bir command gelirse CreateBrandCommandHandler içini çalıştır demiş oluyoruz..
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        private readonly BrandBusinessRules _brandBusinessRules;

        public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandBusinessRules)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
            _brandBusinessRules = brandBusinessRules;
        }

        public async Task<CreatedBrandResponse>? Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            await _brandBusinessRules.BrandNameCannotBeDuplicatedWhenInserted(request.Name);

            Brand brand = _mapper.Map<Brand>(request);
            brand.Id = Guid.NewGuid();

            await _brandRepository.AddAsync(brand);
            //await _brandRepository.AddAsync(brand); bunu açarsam ITransactionalRequest devreye giriyor ve dbde yapılan değişiklikleri geri alıyor

            CreatedBrandResponse createdBrandResponse = _mapper.Map<CreatedBrandResponse>(brand);
            return createdBrandResponse;
        }
    }

}
