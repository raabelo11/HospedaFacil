using System.ComponentModel.DataAnnotations;

public class MongoConnection
{
    public required string ConnectionString { get; set; }
    public required string Database { get; set; }
}
