namespace MongoApi.Models;

public class KitchenAppliancesDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string KitchenAppliancesCollectionName { get; set; } = null!;
}