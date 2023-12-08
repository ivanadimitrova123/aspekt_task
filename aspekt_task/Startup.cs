using aspekt_task.Repositories;
using aspekt_task.Services;
using aspekt_task.Services.impl;
using Microsoft.EntityFrameworkCore;

namespace aspekt_task;

public class Startup
{ 
    public IConfiguration Configuration { get; }
    
    public Startup(IConfiguration configuration) 
    { 
        Configuration = configuration;
    }
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options => 
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
        
            services.AddMvc();
            services.AddControllers();
            services.AddRazorPages();
            services.AddControllersWithViews();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IContactRepository, ContactRepository>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }   
            app.UseStaticFiles();
            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }