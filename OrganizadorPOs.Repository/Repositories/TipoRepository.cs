using OrganizadorPOs.Domain.Entities;
using OrganizadorPOs.Domain.Interfaces;
using OrganizadorPOs.Repository.Context;

namespace OrganizadorPOs.Repository.Repositories
{
    public class TipoRepository : BaseRepository<Tipo>, ITipoRepository
    {
        public TipoRepository(MyContext context) : base(context)
        {
        }
    }
}
