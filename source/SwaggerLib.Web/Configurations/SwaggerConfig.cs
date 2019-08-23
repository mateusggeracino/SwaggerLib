using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SwaggerLib.Services;
using SwaggerLib.Services.Models;

namespace SwaggerLib.Web.Configurations
{
    public static class SwaggerConfig
    {
        public static void ConfigSwaggerServices(this IServiceCollection services)
        {
            SwaggerContact.Config("Joseé", "My github");
            SwaggerInfo.Config("v1", "Josézinho", "Test");

            services.ConfigureServicesSwagger();
        }

        public static void ConfigSwaggerApp(this IApplicationBuilder app)
        {
            EndPoint.Config("/swagger/v1/swagger.json", "Josezinho");
            app.ConfigureAppSwagger();
        }
    }
}