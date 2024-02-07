namespace Poc.MongoDB.Api.Interfaces;

public interface IDbSchoolDatabaseSettings
{
    string StudentCollectionName { get; set; }
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
}
