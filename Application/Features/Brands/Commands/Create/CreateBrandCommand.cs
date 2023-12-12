using MediatR;

namespace Application.Features.Brands.Commands.Create;

public class CreateBrandCommand : IRequest<CreatedBrandResponse> // bir request olduğu için IRequest interface inden türeyecek. Apiden bir CreateBrandCommand gelecek, biz bunu brand domainine cevirip db ye kaydedeceğiz.
                                                                 // IRequest interface inde <> içerisine CreateBrandCommand gelince IRequest'in ona geri ne döndüreceğini vermemizi istiyor yani bir response modeli, o da                 CreatedBrandResponse olacak
                                                                 //Mediator ne yapıyor ? , IRequest gördü, aa benimle ilgili bir şey var dedi benim bunu handle etmem lazım dedi bunu da her command'ın handler i var onunla yapıyor.
{
    public string Name { get; set; }

    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandResponse> // yani sana CreateBrandCommand böyle bir command gelirse CreateBrandCommandHandler içini çalıştır demiş oluyoruz..
    {
        public Task<CreatedBrandResponse>? Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            CreatedBrandResponse createdBrandResponse = new CreatedBrandResponse();
            createdBrandResponse.Name = request.Name;
            createdBrandResponse.Id = new Guid();
            //return createdBrandResponse; async olması gerekiyor
            return null;
        }
    }

}
