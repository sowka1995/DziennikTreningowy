using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DziennikTreningowy.Configurations;
using DziennikTreningowy.Core.Interfaces;
using DziennikTreningowy.Core.Models;
using DziennikTreningowy.Infrastructure.Context;
using DziennikTreningowy.Infrastructure.Repositories;
using DziennikTreningowy.Infrastructure.Services.Auth;
using DziennikTreningowy.Infrastructure.Services.User;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DziennikTreningowy
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
            WorkoutDiaryDbContext.ConnectionString = this.Configuration.GetConnectionString("Default");
            services.AddDbContext<WorkoutDiaryDbContext>(options =>
                options.UseSqlServer(this.Configuration.GetConnectionString("Default")));

            SwaggerConfiguration.RegisterService(services);

            services.AddIdentity<User, IdentityRole<int>>()
                    .AddEntityFrameworkStores<WorkoutDiaryDbContext>()
                    .AddDefaultTokenProviders();

            JwtBearerAuthenticationConfiguration.RegisterBearerPolicy(services, Configuration);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAutoMapper();

            services.AddScoped<IOAuthService, OAuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            using (var context = new WorkoutDiaryDbContext())
            {
                context.Database.Migrate();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                DatabaseSeed.Initialize(app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope().ServiceProvider);
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
            app.UseSwagger();
            SwaggerConfiguration.RegisterUi(app);
        }
    }
}
