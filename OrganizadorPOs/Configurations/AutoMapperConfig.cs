using AutoMapper;
using OrganizadorPOs.Domain.Entities;
using OrganizadorPOs.ViewModels;

namespace OrganizadorPOs.Configurations
{
    public static class AutoMapperConfig
    {
        public static IServiceCollection ConfigAutoMapper(this IServiceCollection services)
        {
            MapperConfiguration config = new(cfg =>
            {
                cfg.CreateMap<Registro, RegistroViewModel>().ReverseMap();
                cfg.CreateMap<FiltroRegistros, FiltroRegistrosViewModel>().ReverseMap();
            });

            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }
    }
}