namespace OrganizadorPOs.Domain.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        Task<TEntity?> Adicionar(TEntity objeto);

        Task<TEntity?> Atualizar(TEntity objeto);

        Task Remover(TEntity objeto);

        Task<TEntity?> ObterPorId(int id);

        Task<IQueryable<TEntity>?> ObterQueryable();
    }
}