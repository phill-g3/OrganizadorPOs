using Microsoft.EntityFrameworkCore;
using OrganizadorPOs.Domain.Entities;
using OrganizadorPOs.Domain.Interfaces;
using OrganizadorPOs.Repository.Context;

namespace OrganizadorPOs.Repository.Repositories
{
    public class RegistroRepository : BaseRepository<Registro>, IRegistroRepository
    {
        private readonly IDbContextFactory<MyContext> _dbContextFactory;

        public RegistroRepository(MyContext context, IDbContextFactory<MyContext> dbContextFactory) : base(context)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task AtivarDesativar(int id)
        {
            Registro? registro = await ObterPorId(id);

            if (registro != null)
            {
                if (registro.DataExclusao == null)
                    registro.DataExclusao = DateTime.Now;
                else
                    registro.DataExclusao = null;

                await _context.SaveChangesAsync();
            }
        }

        public async Task AtivarDesativarMultiThread(int id)
        {
            try
            {
                using (MyContext context = _dbContextFactory.CreateDbContext())
                {
                    Registro? registro = new();

                    if (context.Registros != null)
                    {
                        registro = await context.Registros.FirstOrDefaultAsync(x => x.Id == id);

                        if (registro != null)
                        {
                            if (registro.DataExclusao == null)
                                registro.DataExclusao = DateTime.Now;
                            else
                                registro.DataExclusao = null;

                            await context.SaveChangesAsync();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        public async Task<IQueryable<Registro>> List(FiltroRegistros filtro)
        {
            IQueryable<Registro> query = await ObterQueryable();

            if (filtro.AtivadoDesativado == null || (bool)filtro.AtivadoDesativado)
                query = query.Where(x => x.DataExclusao == null);

            if (filtro.Nf != null)
                query = query.Where(x => x.EmitiuNotaFiscal == filtro.Nf);

            if (filtro.Status != null)
                query = query.Where(x => x.Status == filtro.Status);

            if (filtro.Pagamento != null)
                query = query.Where(x => x.PagamentoRecebido == filtro.Pagamento);

            if (filtro.Nf != null)
                query = query.Where(x => x.EmitiuNotaFiscal == filtro.Nf);

            if (filtro.Projeto != null)
                query = query.Where(x => x.Projeto != null && x.Projeto.ToLower() == filtro.Projeto.ToLower());

            if (filtro.Tipo != null)
                query = query.Where(x => x.Tipo != null && x.Tipo.ToLower() == filtro.Tipo.ToLower());


            if (filtro.FeitoEmMin != null && filtro.FeitoEmMax != null)
                query = query.Where(x => x.FeitoEm != null && x.FeitoEm >= filtro.FeitoEmMin && x.FeitoEm <= filtro.FeitoEmMax);

            else if (filtro.FeitoEmMin != null)
                query = query.Where(x => x.FeitoEm != null && x.FeitoEm >= filtro.FeitoEmMin);

            else if (filtro.FeitoEmMax != null)
                query = query.Where(x => x.FeitoEm != null && x.FeitoEm <= filtro.FeitoEmMax);


            if (filtro.RecebidaEmMin != null && filtro.RecebidaEmMax != null)
                query = query.Where(x => x.RecebidaEm != null && x.RecebidaEm >= filtro.RecebidaEmMin && x.RecebidaEm <= filtro.RecebidaEmMax);

            else if (filtro.RecebidaEmMin != null)
                query = query.Where(x => x.RecebidaEm != null && x.RecebidaEm >= filtro.RecebidaEmMin);

            else if (filtro.RecebidaEmMax != null)
                query = query.Where(x => x.RecebidaEm != null && x.RecebidaEm <= filtro.RecebidaEmMax);


            return query;
        }
    }
}
