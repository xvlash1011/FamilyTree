using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using GiaPhaApi.Data;
using GiaPhaApi.Data.Services;

namespace GiaPhaApi.Api
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
      services.AddScoped((_) => new GiaPhaApiDbContext());
      services.AddScoped<MemberService>();
      services.AddScoped<EthnicService>();
      services.AddScoped<RelationService>();
      services.AddScoped<RelationShipService>();
      services.AddScoped<RoleService>();
      services.AddScoped<UserService>();
      services.AddCors(options =>
      {
        options.AddDefaultPolicy(
            builder =>
            {
              builder.AllowAnyHeader()
                             .AllowAnyMethod()
                             .SetIsOriginAllowed((host) => true)
                             .AllowCredentials();
            });
      });
      services.AddControllers();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "GiaPhaApi.Api", Version = "v1" });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GiaPhaApi.Api"));
      }

      app.UseHttpsRedirection();

      app.UseRouting();
      app.UseCors();
      app.UseAuthorization();
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
