using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoApi.Models;

public class KitchenAppliance
{
    public string? Id { get; set; }
    
    [BsonElement("Manufacturer")]
    [JsonPropertyName("Manufacturer")]
    public string Manufacturer { get; set; } = null!;
    
    [BsonElement("Type")]
    [JsonPropertyName("Type")]
    public string Type { get; set; } = null!;
    
    [BsonElement("Cost")]
    [JsonPropertyName("Cost")]
    public decimal Cost { get; set; }
    
   
}