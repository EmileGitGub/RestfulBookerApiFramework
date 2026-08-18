using Microsoft.Extensions.Configuration;

namespace RestfulBookerApiFramework.Config;

public static class SettingsManager
{
    public static Settings Settings { get; }

    static SettingsManager()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        Settings = configuration.Get<Settings>()!;
    }

}