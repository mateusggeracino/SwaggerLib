using Microsoft.Extensions.PlatformAbstractions;

namespace SwaggerLib.Services.Models
{
    /// <summary>
    /// Propriedades de EndPoint para que o swagger adicione o arquivo de log .json
    /// </summary>
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