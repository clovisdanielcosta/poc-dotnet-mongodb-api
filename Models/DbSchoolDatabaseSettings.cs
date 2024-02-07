using Poc.MongoDB.Api.Interfaces;

namespace Poc.MongoDB.Api.Models;

public class DbSchoolDatabaseSettings : IDbSchoolDatabaseSettings
{
    public string StudentCollectionName { get; set; } = string.Empty;
    public string ConnectionString { get; set; } = string.Empty;
    public string DatabaseName { get; set; } = string.Empty;
}
