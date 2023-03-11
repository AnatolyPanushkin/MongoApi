namespace MongoApi.Dto;

public class KitchenApplianceDto
{
    public string Manufacturer { get; set; } = null!;
    
    public string Type { get; set; } = null!;
    
    public decimal Cost { get; set; }
}