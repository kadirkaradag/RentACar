using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.Update;

public class UpdateBrandCommand :IRequest<UpdatedBrandResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, UpdatedBrandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBrandRepository _repository;

        public UpdateBrandCommandHandler(IMapper mapper, IBrandRepository repository)
        {
            this._mapper = mapper;
            this._repository = repository;
        }

        public async Task<UpdatedBrandResponse> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            Brand? brand = await _repository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
            
            brand = _mapper.Map(request,brand);  // request i brand e maple.

            await _repository.UpdateAsync(brand);

            UpdatedBrandResponse response = _mapper.Map<UpdatedBrandResponse>(brand);

            return response;
        }
    }
}
