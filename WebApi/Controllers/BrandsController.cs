using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Queries.GetById;
using Application.Features.Brands.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
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

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBrandQuery getListBrandQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListBrandListItemDto> response = await Mediator.Send(getListBrandQuery);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdBrandQuery getByIdBrandQuery = new() { Id = id };
        GetByIdBrandResponse response = await Mediator.Send(getByIdBrandQuery);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBrandCommand updateBrandCommand)
    {
        UpdatedBrandResponse response = await Mediator.Send(updateBrandCommand); 
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedBrandResponse response = await Mediator.Send(new DeleteBrandCommand { Id = id});
        return Ok(response);
    }
}
