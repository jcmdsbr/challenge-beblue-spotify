using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace SC.Api.Middlewares
{
    public static class SwaggerConfig
    {
        public static void RegiterSwagger(this IServiceCollection services) 
        {
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info { Title = "Spotify Commerce API", Version = "v1" }); });
        }

        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("v1/swagger.json", "Sgr API v1.0");
                s.EnableFilter();
                s.DocExpansion(DocExpansion.None);
            });
        }
    }
}
