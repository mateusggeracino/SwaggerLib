using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SwaggerLib.Services;
using SwaggerLib.Services.Models;

namespace SwaggerLib.Web.Configurations
{
    /// <summary>
    /// Classe de configuração com propriedades personalizadas
    /// </summary>
    public static class SwaggerConfig
    {
        /// <summary>
        /// Método de extensão da interface: IServiceCollection
        /// Propriedades personalizadas 
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigSwaggerServices(this IServiceCollection services)
        {
            SwaggerContact.Config("Joseé", "My github");
            SwaggerInfo.Config("v1", "Josézinho", "Test");

            services.ConfigureServicesSwagger();
        }

        /// <summary>
        /// Método de extensão da interface: IApplicationBuilder
        /// Propriedades de EndPoint personalizadas
        /// </summary>
        /// <param name="app"></param>
        public static void ConfigSwaggerApp(this IApplicationBuilder app)
        {
            SwaggerEndPoint.Config("/swagger/v1/swagger.json", "Josezinho");

            app.ConfigureAppSwagger();
        }
    }
}