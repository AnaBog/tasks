using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Timesheet.Api.Controllers;
using Timesheet.Core;
using Timesheet.Core.Repositories;
using Timesheet.Infrastructure;

namespace Timesheet.Api
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
            services.AddControllersWithViews();
            
            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            services.AddSingleton<IClientRepository, ClientRepository>(); 
            services.AddScoped<ClientService>();
            services.AddScoped<ClientsSearchFactory>();
            services.AddScoped<ClientsFactory>();
            services.AddScoped<ClientDtoMapper>();
            services.AddScoped<PagedClientsDtoMapper>();

            services.AddSingleton<IProjectRepository, ProjectRepository>();
            services.AddScoped<ProjectService>();
            services.AddScoped<ProjectsSearchFactory>();
            services.AddScoped<ProjectsFactory>();
            services.AddScoped<ProjectDtoMapper>();
            services.AddScoped<PagedProjectsDtoMapper>();

            services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<EmployeeService>();
            services.AddScoped<EmployeesSearchFactory>();
            services.AddScoped<EmployeesFactory>();
            services.AddScoped<EmployeeDtoMapper>();
            services.AddScoped<PagedEmployeesDtoMapper>();

            services.AddSingleton<ITimesheetRepository, TimesheetRepository>();
            services.AddScoped<TimesheetService>();
            services.AddScoped<DailyTimesheetFactory>();
            services.AddScoped<TimesheetEntryFactory>();
            services.AddScoped<DailyTimesheetDtoMapper>();
            services.AddScoped<TimesheetEntryDtoMapper>();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
