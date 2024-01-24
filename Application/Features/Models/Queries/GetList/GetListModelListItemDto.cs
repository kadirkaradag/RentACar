namespace Application.Features.Models.Queries.GetList;

public class GetListModelListItemDto
{
    public Guid Id { get; set; }
    public string BrandName { get; set; }  //bu bilginin joinlenerek diğer tablodan gelmesini bekliyorum
    public string FuelName { get; set; }  //bu bilginin joinlenerek diğer tablodan gelmesini bekliyorum
    public string TransmissionName { get; set; }  //bu bilginin joinlenerek diğer tablodan gelmesini bekliyorum
    public string Name { get; set; }
    public decimal DailyPrice { get; set; }
    public string ImageUrl { get; set; }
}
