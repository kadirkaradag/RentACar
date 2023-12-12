using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class BaseController : ControllerBase // bütün controller ımı BaseController dan inherit edersem hepsine mediatr injecte etmiş olurum
{
    private IMediator? _mediator; // bu mediator ın IOC ye dahil edilmesi gerekiyor onu da normalde program.cs te injection u halledebilirim ama biz her katmanın kendi ioc configurasyonu icin extension yazmak istiyoruz ki derli toplu olsun o yüzden ApplicationServiceRegistiration oluşturuyoruz.

    // bunu sadece bunu inherit edenler kullanabilsin diyebilmek icin protected yapıyorum
    protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

    // yukarıdaki kısımda şunu diyorum, daha önce mediator inject edilmişse onu döndür ama nullsa git ioc ortamına bak oradan IMediator karşılığını bana ver diyorum.
}
