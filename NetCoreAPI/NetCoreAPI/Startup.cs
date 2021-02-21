using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace NetCoreAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.Authority = "https://okta.oktamanor.com/oauth2/aus5qj9tdEkuA12S71d6";
                options.Audience = "http://localhost:5000";
                options.RequireHttpsMetadata = false;
            });



            // Optionally to specify a policy to check for a specific scope "app:permissions"
            //    with this able to modify the [authorization] annotation with [authorization("ScopeCheck")]
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ScopeCheck", policyBuilder =>
                    policyBuilder.RequireAssertion(handler =>
                    {
                        var scopeClaim = handler.User.FindFirst("http://schemas.microsoft.com/identity/claims/scope");
                        var scopes = scopeClaim?.Value.Split(' ');
                        var hasScope = scopes?.Where(scope => scope == "app:permissions").Any() ?? false;
                        return hasScope;
                    }));
            });


            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
