using AccesoADatos;
using Microsoft.EntityFrameworkCore;
using Servicios;

namespace BancoUsuariosWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<DbContext, Contexto>(options => {
                options.UseSqlServer(builder.Configuration.GetConnectionString("StringConnection"));

            });

            //Inyeccion de repositorio
            builder.Services.AddScoped(typeof(IRepositorioUsuario), typeof(RepositorioUsuario));
            //Inyeccion de servicio
            builder.Services.AddScoped(typeof(IServicioUsuario), typeof(ServicioUsuario));

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
