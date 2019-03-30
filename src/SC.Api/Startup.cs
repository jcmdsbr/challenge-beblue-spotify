using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SC.Api.Middlewares;
using SC.IoC;
using Swashbuckle.AspNetCore.Swagger;

namespace SC.Api {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices (IServiceCollection services) {
            services.RegisterAspNet ();

            services.RegiterSwagger ();

            services.RegisterServices ();
        }

        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            app.ConfigureCors ();

            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }

            app.ConfigureAspNet ();
            app.ConfigureSwagger ();
        }
    }
}