using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;
using System.Linq;
using SwaggerLib.Services.Models;
using Swashbuckle.AspNetCore.Swagger;
using Contact = Swashbuckle.AspNetCore.Swagger.Contact;
using Info = Swashbuckle.AspNetCore.Swagger.Info;

namespace SwaggerLib.Services
{
    public static class Swagger
    {
        public static void ConfigureServicesSwagger(this IServiceCollection services, bool addToken)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(SwaggerInfo.Version,
                    new Info
                    {
                        Title = SwaggerInfo.Title,
                        Version = SwaggerInfo.Version,
                        Description = SwaggerInfo.Description,
                        Contact = new Contact
                        {
                            Name = SwaggerContact.Name,
                            Url = SwaggerContact.Url
                        }
                    });

                var pathApp =
                    PlatformServices.Default.Application.ApplicationBasePath;
                var nameApp =
                    PlatformServices.Default.Application.ApplicationName;
                var pathXmlDoc =
                    Path.Combine(pathApp, $"{nameApp}.xml");

                c.IncludeXmlComments(pathXmlDoc);

                if (addToken)
                {
                    c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                    {
                        In = "header",
                        Description = "Por favor, digite a palavra 'Bearer' seguida de um espaço e o seu token",
                        Name = "Authorization",
                        Type = "apiKey"
                    });
                    c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> {
                        { "Bearer", Enumerable.Empty<string>() },
                    });
                }
            });
        }

        public static void ConfigureAppSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(SwaggerEndPoint.Url,
                    SwaggerEndPoint.Name);
            });
        }
    }
}
