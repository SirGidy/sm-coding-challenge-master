using System;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using sm_coding_challenge.Domain.Models;
using sm_coding_challenge.Domain.Repositories;
using sm_coding_challenge.Domain.Services;
using sm_coding_challenge.Persistence.Context;
using sm_coding_challenge.Persistence.Repositories;
using sm_coding_challenge.Services;
using sm_coding_challenge.Services.DataProvider;

namespace sm_coding_challenge
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

            services.AddDistributedRedisCache(options =>
            {
                options.Configuration = "localhost:6379";
            });
            services.AddScoped<ETagCache>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            services.AddDbContext<AppDbContext>(options => {
                options.UseInMemoryDatabase("api-in-memory");
            });
            services.AddControllersWithViews();
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IDownloadTrackerRepository, DownloadTrackerRepository>();
            services.AddScoped<IKickingRepository, KickingRepository>();
            services.AddScoped<IPassingRepository, PassingRepository>();
            services.AddScoped<IReceivingRepository, ReceivingRepository>();
            services.AddScoped<IRushingRepository, RushingRepository>();
            services.AddScoped<IUnitOfWork,UnitOfWork>();

            services.AddTransient<IDataProvider, DataProviderImpl>();
            services.AddScoped<IKickingService, KickingService>();
            services.AddScoped<IPassingService, PassingService>();
            services.AddScoped<IReceivingService,ReceivingService>();
            services.AddScoped<IRushingService,RushingService>();
            services.AddScoped<IPlayerService, PlayerService>();
            services.AddScoped<IDownloadTrackerService, DownloadTrackerService>();

            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseResponseCaching();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
