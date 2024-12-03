using System.ComponentModel.DataAnnotations;

public class Settings
{
    public required string ConnectionString { get; set; }
    public required string Database { get; set; }
}
