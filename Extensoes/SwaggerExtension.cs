using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace WebApi.Extensoes
{
    public static  class SwaggerExtension
    {
        public static IServiceCollection AddServiceSwagger(this IServiceCollection services)
          => services.AddSwaggerGen(s =>
          {
              s.SwaggerDoc("v1", new OpenApiInfo { Title = "Ecomerce", Version = "v1" });
          });


        public static void ConfigureServiceSwagger(this IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));
            }
        }
    }
}
