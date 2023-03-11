using Microsoft.EntityFrameworkCore;

namespace OrganizadorPOs.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        DbContext ObterContexto();

        Task<TEntity?> Adicionar(TEntity objeto);

        Task<TEntity?> Atualizar(TEntity objeto);

        Task Remover(TEntity objeto);

        Task<TEntity?> ObterPorId(int id);

        Task<IQueryable<TEntity>> ObterQueryable();

        void BeginTrans();

        void CommitTrans();

        void RollbackTrans();
    }
}