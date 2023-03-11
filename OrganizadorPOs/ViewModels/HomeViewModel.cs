using Microsoft.AspNetCore.Mvc.Rendering;

namespace OrganizadorPOs.ViewModels
{
    public class HomeViewModel
    {
        public List<RegistroViewModel>? Registros { get; set; }
        public FiltroRegistrosViewModel? Filtro { get; set; }
        public double ValorTotal
        {
            get
            {
                if (Registros != null && Registros.Any())
                    return (double)Registros.Sum(x => x.Valor);

                return 0;
            }
        }
        public double ValorPOTotal
        {
            get
            {
                if (Registros != null && Registros.Any())
                    return (double)Registros.Sum(x => x.ValorPO);

                return 0;
            }
        }
    }
}
