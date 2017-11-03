using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using StoreEP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using StoreEP.Data;
using StoreEP.Services;
using StoreEP.Models.Interface;
using StoreEP.Models.Repositorio;

namespace StoreEP
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .Build();
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddNodeServices();

            services.AddDbContext<StoreEPDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("StoreEP")));
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Identity")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IProdutoRepositorio, EFProdutoRepositorio>();
            services.AddTransient<IPedidoRepositorio, EFPedidoRepositorio>();
            services.AddTransient<IEnderecoRepositorio, EFEnderecoRepositorio>();
            services.AddTransient<IComentariosRepositorio, EFComentariosRepository>();
            services.AddTransient<IImagensRepositorio, EFImagemRepositorio>();
            services.AddTransient<IHistoricoPrecosRepositorio, EFHistoricoPreco>();
            services.AddTransient<IProdutoVisitadoRepositorio, EFProdutoVisitadoRepositorio>();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Administrador", policy => policy.RequireRole("Administrator"));
            });
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 6;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.Cookie.Expiration = TimeSpan.FromDays(7);
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped<Carrinho>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
                app.UseDeveloperExceptionPage();

            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: null,
                    template: "{category}/Page{page:int}",
                    defaults: new { controller = "Produtos", action = "Listar" });
                routes.MapRoute(
                  name: null,
                  template: "{controller}/Produto{batata:int}",
                  defaults: new { controller = "Admin", action = "Edit" });
                routes.MapRoute(
                    name: null,
                    template: "Page{page:int}",
                    defaults: new { controller = "Produtos", action = "Listar" });
                routes.MapRoute(
                    name: null,
                    template: "ListarTodosProdutos{opcaoSelecionada}",
                    defaults: new { controller = "Admin", action = "ListarTodosProdutos" });
                routes.MapRoute(
                    name: null,
                    template: "ValidarComentarios{opcaoSelecionada}",
                    defaults: new { controller = "Admin", action = "ValidarComentarios" });
                routes.MapRoute(
                    name: null,
                    template: "CriarProduto{opcaoSelecionada}",
                    defaults: new { controller = "Admin", action = "CriarProduto" });
                routes.MapRoute(
                    name: null,
                    template: "Criar{opcaoSelecionada}",
                    defaults: new { controller = "Identidade", action = "Criar" });
                routes.MapRoute(
                    name: null,
                    template: "{category}",
                    defaults: new { controller = "Admin", action = "ListarTodosProdutos" });
                routes.MapRoute(
                    name: null,
                    template: "",
                    defaults: new { controller = "Produtos", action = "Listar" });
                routes.MapRoute(
                    name: null,
                    template: "{controller=Produtos}/{action=Listar}/{id?}");
                routes.MapRoute(
                    name: null,
                    template: "{controller=Endereco}/Index/{ID}");
            });
            //IdentityDbContext.Initialize(app.ApplicationServices);
        }
    }
}