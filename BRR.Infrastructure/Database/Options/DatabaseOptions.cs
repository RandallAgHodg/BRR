namespace BRRR.Infrastructure.Database.Options;

public class DatabaseOptions
{    
    public string ConnectionString { get; set; }
    public int MaxRetryCount { get; init; }
    public int CommandTimeout { get; init; }
    public bool EnabledDetailedErrors { get; init; }
    public bool EnableSensitiveDataLogging { get; init; }
}
