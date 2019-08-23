using Microsoft.Extensions.PlatformAbstractions;

namespace SwaggerLib.Services.Models
{
    /// <summary>
    /// Propriedades que aparecerem no header do swagger
    /// </summary>
    public static class SwaggerInfo
    {
        public static void Config(string version, string title, string description)
        {
            Version = version;
            Title = title;
            Description = description;
        }

        public static string Version = PlatformServices.Default.Application.ApplicationVersion;
        public static string Title = PlatformServices.Default.Application.ApplicationName;
        public static string Description = "This information is generate automatic";
    }
}