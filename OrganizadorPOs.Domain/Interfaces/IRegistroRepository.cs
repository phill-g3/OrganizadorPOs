using OrganizadorPOs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorPOs.Domain.Interfaces
{
    public interface IRegistroRepository : IBaseRepository<Registro>
    {
        Task<IQueryable<Registro>> List(FiltroRegistros filtro);
        Task AtivarDesativar(int id);
        Task AtivarDesativarMultiThread(int id);
    }
}
