﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;

namespace DevIO.Api.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection WebApiConfig(this IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddCors(options =>
            {
            options.AddPolicy(name: "Development",
                configurePolicy: builder => builder.AllowAnyOrigin()
                 .AllowAnyMethod()
                 .AllowAnyHeader()
                 .AllowCredentials());

            options.AddPolicy(name: "Production",
                configurePolicy: builder =>
                 builder
                     .WithMethods("GET")
                     .WithOrigins("http://desenvolvedor.io")
                     .SetIsOriginAllowedToAllowWildcardSubdomains()
                     .WithHeaders(HeaderNames.ContentType, "x-custom-header")
                     .AllowAnyHeader());
            });

            return services;
        }

        public static IApplicationBuilder UseMvcConfiguration(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection(); //redirecionamento automático para HTTPS
            app.UseCors("Development");
            app.UseMvc();

            return app;
        }
    }
}
