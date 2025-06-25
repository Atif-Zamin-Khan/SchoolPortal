using Mapster;
using System.Reflection;

namespace SchoolManagementSystem.Mapster
{
    public static class MapsterConfiguration
    {
        public static void Configure()
        {
            // Apply global settings (optional)
            TypeAdapterConfig.GlobalSettings.Default.NameMatchingStrategy(NameMatchingStrategy.IgnoreCase);

            // Scan and register all mappings in the Profiles folder
            var assembly = Assembly.GetExecutingAssembly();
            TypeAdapterConfig.GlobalSettings.Scan(assembly);

        }

    }
}
