using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.Create;

public class CreateBrandCommand : IRequest<CreatedBrandResponse> // bir request olduğu için IRequest interface inden türeyecek. Apiden bir CreateBrandCommand gelecek, biz bunu brand domainine cevirip db ye kaydedeceğiz.
                                                                 // IRequest interface inde <> içerisine CreateBrandCommand gelince IRequest'in ona geri ne döndüreceğini vermemizi istiyor yani bir response modeli, o da                 CreatedBrandResponse olacak
                                                                 //Mediator ne yapıyor ? , IRequest gördü, aa benimle ilgili bir şey var dedi benim bunu handle etmem lazım dedi bunu da her command'ın handler i var onunla yapıyor.
{
    public string Name { get; set; }

    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandResponse> // yani sana CreateBrandCommand böyle bir command gelirse CreateBrandCommandHandler içini çalıştır demiş oluyoruz..
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<CreatedBrandResponse>? Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            Brand brand = _mapper.Map<Brand>(request);
            brand.Id = Guid.NewGuid();

            await _brandRepository.AddAsync(brand);

            CreatedBrandResponse createdBrandResponse = _mapper.Map<CreatedBrandResponse>(brand);
            return createdBrandResponse;
        }
    }

}
