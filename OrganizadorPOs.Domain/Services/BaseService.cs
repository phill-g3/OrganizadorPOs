using OrganizadorPOs.Domain.Interfaces;

namespace OrganizadorPOs.Domain.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        public readonly IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository ?? throw new ArgumentNullException(nameof(baseRepository));
        }

        public async Task<TEntity?> Adicionar(TEntity obj)
        {
            try
            {
                await _baseRepository.Adicionar(obj);

                return obj;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<TEntity?> Atualizar(TEntity obj)
        {
            try
            {
                await _baseRepository.Atualizar(obj);

                return obj;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task Remover(TEntity obj)
        {
            try
            {
                await _baseRepository.Remover(obj);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<TEntity?> ObterPorId(int id)
        {
            try
            {
                TEntity? retorno = await _baseRepository.ObterPorId(id);

                return retorno;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IQueryable<TEntity>?> ObterQueryable()
        {
            try
            {
                IQueryable<TEntity>? retorno = await _baseRepository.ObterQueryable();

                return retorno;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}