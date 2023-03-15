using Microsoft.AspNetCore.Mvc;
using MongoApi.Dto;
using MongoApi.Models;
using MongoApi.Services;
using MongoDB.Bson;

namespace MongoApi.Controllers;

[ApiController]
[Route("api/kitchenAppliances")]
public class KitchenAppliancesController:ControllerBase
{
    private readonly KitchenAppliancesService _service;

    public KitchenAppliancesController(KitchenAppliancesService service)
    {
        _service = service;
    }

    [HttpPost("addNewKitchenAppliance")]
    public async Task<ActionResult> AddNewKitchenAppliance(KitchenApplianceDto kitchenApplianceDto)
    {
        var kitchenAppliance = new KitchenAppliance()
        {
            Id = ObjectId.GenerateNewId().ToString(),
            Manufacturer = kitchenApplianceDto.Manufacturer,
            Type = kitchenApplianceDto.Type,
            Cost = kitchenApplianceDto.Cost
        };
        await _service.CreateNewKitchenApplianceAsync(kitchenAppliance);
        
        return Ok(kitchenAppliance);
    }

    [HttpGet("getKitchenApplianceById{id:length(24)}")]
    public async Task<ActionResult> GetKitchenApplianceById(string id)
    {
        var result = await _service.GetKitchenApplianceByIdAsync(id);

        if (result!=null)
        {
            return Ok(result);
        }

        return BadRequest("not found");
    }

    [HttpGet("getKitchenAppliances")]
    public async Task<ActionResult> GetKitchenAppliances()
    {
        var result = await _service.GetKitchenAppliancesAsync();
        
        return Ok(result);
    }

    [HttpPut("updateKitchenAppliance")]
    public async Task<ActionResult> UpdateKitchenAppliance(KitchenAppliance kitchenAppliance)
    { 
        await _service.UpdateKitchenApplianceAsync(kitchenAppliance);

        return Ok(kitchenAppliance);
    }

    [HttpDelete("deleteKitchenAppliance{id:length(24)}")]
    public async Task<ActionResult> DeleteKitchenAppliance(string id)
    {
        var result = await _service.GetKitchenApplianceByIdAsync(id);
        await _service.DeleteKitchenApplianceAsync(id);

        return Ok(result);
    }
}