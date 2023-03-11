using MongoApi.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace MongoApi.Services;

public class KitchenAppliancesService
{
    private readonly IMongoCollection<KitchenAppliance> _collection;

    public KitchenAppliancesService(IOptions<KitchenAppliancesDatabaseSettings> kitchenAppliancesDatabaseSettings)
    {
        var mongoClient = new MongoClient(
           kitchenAppliancesDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            kitchenAppliancesDatabaseSettings.Value.DatabaseName);

        _collection = mongoDatabase.GetCollection<KitchenAppliance>(
            kitchenAppliancesDatabaseSettings.Value.KitchenAppliancesCollectionName);
    }
    
    public async Task<List<KitchenAppliance>> GetKitchenAppliancesAsync() =>
        await _collection.Find(_ => true).ToListAsync();

    public async Task<KitchenAppliance?> GetKitchenApplianceByIdAsync(string id) =>
        await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateNewKitchenApplianceAsync(KitchenAppliance kitchenAppliance) =>
        await _collection.InsertOneAsync(kitchenAppliance);

    public async Task UpdateKitchenApplianceAsync(KitchenAppliance kitchenAppliance) =>
        await _collection.ReplaceOneAsync(x => x.Id == kitchenAppliance.Id, kitchenAppliance);

    public async Task DeleteKitchenApplianceAsync(string id) =>
        await _collection.DeleteOneAsync(x => x.Id == id);
}