using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DziennikTreningowy.Configurations;
using DziennikTreningowy.Infrastructure.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
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

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            SwaggerConfiguration.RegisterUi(app);
        }
    }
}
