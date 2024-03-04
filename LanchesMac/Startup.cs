using LanchesMac.Context;
using LanchesMac.Repositories;
using LanchesMac.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac;
// Responsável por configurar o aplicativo durante o tempo de inicialização.
public class Startup
{
    // Configuration representa a configuração do aplicativo.
    public IConfiguration Configuration { get; }

    // O construtor recebe a configuração como parâmetro.
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    // Este método é chamado pelo tempo de execução e é usado para adicionar serviços ao contêiner de injeção de dependência.
    public void ConfigureServices(IServiceCollection services)
    {
        // Adiciona o contexto do banco de dados utilizando o provedor Entity Framework Core com o SQL Server.
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        // Adiciona os repositórios como serviços transitórios, o que significa que uma nova instância será criada para cada solicitação. DI
        services.AddTransient<ILancheRepository, LancheRepository>();
        services.AddTransient<ICategoriaRepository, CategoriaRepository>();

        // Tempo de vida vale por tudo
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        // Adiciona o suporte para controladores MVC.
        services.AddControllersWithViews();
        // Habilitando cache
        services.AddMemoryCache();
        // Habilitando a Session
        services.AddSession();
    }

    // Este método é chamado pelo tempo de execução e é usado para configurar o pipeline de solicitação HTTP.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Verifica se o aplicativo está em ambiente de desenvolvimento.
        if (env.IsDevelopment()) 
        {
            // Habilita a página de exceção do desenvolvedor para facilitar a depuração.
            app.UseDeveloperExceptionPage();
        }
        else
        {
            // Em caso contrário, configura a página de exceção padrão
            app.UseExceptionHandler("/Home/Error");
            // Define a política de HSTS padrão para 30 dias. Recomendado alterar em cenários de produção.
            app.UseHsts();
        }
        // Redireciona solicitações HTTP para HTTPS.
        app.UseHttpsRedirection();
        // Permite o acesso aos arquivos estáticos, como CSS, JavaScript e imagens.
        app.UseStaticFiles();

        // Configura o roteamento de solicitações HTTP.
        app.UseRouting();

        // Ativando a Session
        app.UseSession();

        // Habilita a autorização para controlar o acesso aos endpoints.
        app.UseAuthorization();

        // Configura os endpoints dos controladores MVC.
        app.UseEndpoints(endpoints => 
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}