using Microsoft.EntityFrameworkCore;
using OrganizadorPOs.Domain.Interfaces;

namespace OrganizadorPOs.Repository.Repositories
{
    public class BaseRepository<TEntity> : IDisposable, IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public DbContext ObterContexto()
        {
            try
            {
                DbContext retorno = _context;

                return retorno;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<TEntity?> Adicionar(TEntity obj)
        {
            try
            {
                await _context.Set<TEntity>().AddAsync(obj);

                await _context.SaveChangesAsync();

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
                _context.Entry(obj).State = EntityState.Modified;

                await _context.SaveChangesAsync();

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
                _context.Set<TEntity>().Remove(obj);

                await _context.SaveChangesAsync();
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
                TEntity? retorno = await _context.Set<TEntity>().FindAsync(id);

                return retorno;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IQueryable<TEntity>> ObterQueryable()
        {
            try
            {
                IQueryable<TEntity> retorno = _context.Set<TEntity>();

                return await Task.FromResult(retorno);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void BeginTrans()
        {
            try
            {
                _context.Database.BeginTransactionAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void CommitTrans()
        {
            try
            {
                _context.SaveChangesAsync();

                _context.Database.CommitTransaction();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void RollbackTrans()
        {
            try
            {
                _context.Database.RollbackTransaction();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Dispose()
        {
            try
            {
                GC.SuppressFinalize(this);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}