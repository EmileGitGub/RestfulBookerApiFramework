namespace RestfulBookerApiFramework.Config;

public class Settings
{
    public ApplicationSettings Application { get; set; } = new();
    public AuthenticationSettings Authentication { get; set; } = new();
}

public class ApplicationSettings
{
    public string BaseUrl { get; set; } = string.Empty;
}

public class AuthenticationSettings
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}