using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Galaxy.Settings.Extensions
{
    public static class ConfigurationManagerExtensions
    {
        public static ConfigurationManager AddConfigurationFiles(this ConfigurationManager configurationManager, IHostEnvironment env)
        {
            configurationManager
                .AddJsonFile("config.json")
                .AddJsonFile($"config.{env.EnvironmentName}.json");

            return configurationManager;
        }

        public static AppSettingsBase LoadGalaxyConfigurations(this ConfigurationManager configurationManager) 
        {
            return configurationManager.GetSection("galaxy").Get<AppSettingsBase>();
        }
        
        public static TSettings LoadGalaxyConfigurations<TSettings>(this ConfigurationManager configurationManager) where TSettings : AppSettingsBase, new()
        {
            return configurationManager.GetSection("galaxy").Get<TSettings>();
        }
        
    }
}
