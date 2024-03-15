using LanchesMac.Context;
using LanchesMac.Models;
using LanchesMac.Repositories;
using LanchesMac.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>
            (
                o => o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );

        services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

        // Sobreescrevendo as regras de senha do identity
        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;
        });

        services.AddTransient<ILancheRepository, LancheRepository>();
        services.AddTransient<ICategoriaRepository, CategoriaRepository>();
        services.AddTransient<IPedidoRepository, PedidoRepository>();

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddScoped(sp => CarrinhoCompra.GetCarrinho(sp));

        services.AddControllersWithViews();
        services.AddMemoryCache();
        services.AddSession();
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
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseSession();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "categoriaFiltro",
                pattern: "Lanche/{action}/{categoria?}",
                defaults: new { Controller = "Lanche", Action = "List" });

            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}