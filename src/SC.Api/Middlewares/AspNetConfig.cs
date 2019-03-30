using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SC.Api.BackgroundServices;

namespace SC.Api.Middlewares {
    public static class AspNetConfig {
        public static void RegisterAspNet (this IServiceCollection services) 
        {
            services.AddMvc ()
                .SetCompatibilityVersion (CompatibilityVersion.Version_2_1)
                .AddJsonOptions (options => {
                    options.SerializerSettings.Converters.Add (new StringEnumConverter ());
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });

            services.AddCors (options => {
                options.AddPolicy ("CorsPolicy",
                    builder => builder.AllowAnyOrigin ().AllowAnyHeader ().AllowAnyMethod ());
            });

            //TODO => Mover para IoC
            services.AddTransient<IHostedService,SpotifyMigrationService>();
        }

        public static void ConfigureCors(this IApplicationBuilder app)
        {
            app.UseCors("CorsPolicy");
        }

        public static void ConfigureAspNet(this IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}