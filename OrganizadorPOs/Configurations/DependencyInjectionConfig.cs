using OrganizadorPOs.Domain.Interfaces;
using OrganizadorPOs.Domain.Services;
using OrganizadorPOs.Repository.Repositories;

namespace OrganizadorPOs.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddTransient<IRegistroService, RegistroService>();
            services.AddTransient<IRegistroRepository, RegistroRepository>();
            services.AddTransient<ITipoRepository, TipoRepository>();
        }
    }
}
