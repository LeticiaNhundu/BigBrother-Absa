using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BigBrotherApi.Services;
using BigBrotherAPI.DataContext;
using BigBrotherAPI.Repositories;
using BigBrotherAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;


namespace BigBrotherAPI
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
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IEmotionService, EmotionsService>();
            services.AddScoped<ITeamPersonService, TeamPersonService>();
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<IEmotionService, EmotionsService>();
            services.AddScoped<IPersonEmotionsService, PersonEmotionsService>();
            services.AddTransient<IPersonEmotionsRepo, PersonEmotionsRepo>();
            services.AddTransient<IPersonRepo, PersonRepo>();
            services.AddTransient<IEmotionsRepo, EmotionsRepo>();
            services.AddTransient<ITeamRepo, TeamRepo>();
            services.AddTransient<ITeamPersonRepo, TeamPersonRepo>();
            services.AddDbContext<BbAppContext>(options => options.UseNpgsql(Configuration.GetConnectionString("BigBrotherDB")));
            services.AddScoped<IVideoService, VideoService>();
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "BigBrother", Description = "Api for Big Brother bigbrother" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors(policy => policy
               .AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod()
               // .WithOrigins("http://localhost:8081")
               .AllowCredentials());
            app.UseMvc();
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Big-Brother API");
            });
        }
    }
}
