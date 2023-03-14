namespace DSRPracticeProject.Services.Settings;

public class OpenApiSettings
{
    public bool Enabled { get; private set; }
    
    public string? OAuthClientId { get; private set; }
    public string? OAuthClientSecret { get; private set; }
    
    public OpenApiSettings()
    {
    }
}
