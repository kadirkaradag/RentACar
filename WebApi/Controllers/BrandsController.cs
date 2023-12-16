using Application.Features.Brands.Commands.Create;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandsController : BaseController // mediator inject i icin olusturdugumuz BaseController' ı veriyoruz o da zaten bir ControllerBase.
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand)
    {
        //CreateBrandCommand gelen komutu mediator a yollamam lazım , mediatr inject ederek bunu bütün controller larda yapmamız gerek ve bununla tek tek ugrasmak istemiyoruz. bunun icin bir BaseController class'ı olusturuyoruz
         CreatedBrandResponse response = await Mediator.Send(createBrandCommand); //normalde uygulama yayına alındığında mediator tüm assembly yi tarıyor ve commandleri ve handlerlarını bir mapmiş gibi ekliyor listesine. yani basit bir şekilde createBrandCommand geldiğinde gidiyor bakıyor handler ına onu calıstırıyor.

        return Ok(response);
    }
}
