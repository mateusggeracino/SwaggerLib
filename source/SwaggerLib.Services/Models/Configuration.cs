using Microsoft.Extensions.PlatformAbstractions;

namespace SwaggerLib.Services.Models
{
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

    public static class SwaggerContact
    {
        public static void Config(string name, string url)
        {
            Name = name;
            Url = url;
        }

        public static string Name = "Mateus G. Geracino";
        public static string Url = "https://github.com/mateusggeracino";
    }

    public class SwaggerEndPoint
    {
        public static void Config(string url, string name)
        {
            Url = url;
            Name = name;
        }

        public static string Url = $"/swagger/{PlatformServices.Default.Application.ApplicationVersion}/swagger.json";
        public static string Name = $"{PlatformServices.Default.Application.ApplicationName} - {PlatformServices.Default.Application.ApplicationVersion}";
    }
}