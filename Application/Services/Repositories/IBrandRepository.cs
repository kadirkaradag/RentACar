using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IBrandRepository:IAsyncRepository<Brand,Guid>
{

}  // brand,model vs de ortak operasyonlar olacak bunun için hem senkron hem asenkron repository desteği getireceğiz.Yine Core.Packages projesinde yapıyoruz.

