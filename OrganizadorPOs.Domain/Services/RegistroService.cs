using Microsoft.EntityFrameworkCore;
using OrganizadorPOs.Domain.Entities;
using OrganizadorPOs.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorPOs.Domain.Services
{
    public class RegistroService : BaseService<Registro>, IRegistroService
    {
        private readonly IRegistroRepository _registroRepository;
        private readonly ITipoRepository _tipoRepository;

        public RegistroService(IRegistroRepository registroRepository, ITipoRepository tipoRepository) : base(registroRepository)
        {
            _registroRepository = registroRepository;
            _tipoRepository = tipoRepository;
        }

        public async Task AdicionarAtualizar(Registro registro)
        {
            Task[] tasks = new Task[2] { ChecarSeTipoExiste(registro), CalcularValor(registro) };

            await Task.WhenAll(tasks);

            if (registro.Id == 0)
                await _registroRepository.Adicionar(registro);
            else
                await _registroRepository.Atualizar(registro);
        }

        public async Task AtivarDesativar(int id)
        {
            await _registroRepository.AtivarDesativar(id);
        }

        public async Task<IQueryable<Registro>> List(FiltroRegistros filtro)
        {
            IQueryable<Registro> retorno = await _registroRepository.List(filtro);

            return retorno;
        }

        public async Task<List<Tipo>> ListarTipos()
        {
            IQueryable<Tipo> query = await _tipoRepository.ObterQueryable();

            return await query.ToListAsync();
        }

        private async Task ChecarSeTipoExiste(Registro registro)
        {
            IQueryable<Tipo> query = await _tipoRepository.ObterQueryable();
            bool tipoExiste = query.Any(x => x.Nome != null && registro.Tipo != null && x.Nome.ToLower() == registro.Tipo.ToLower());

            if (registro.Tipo != null && !tipoExiste)
                await _tipoRepository.Adicionar(new Tipo { Nome = registro.Tipo });
        }

        private async Task CalcularValor(Registro registro)
        {
            double valorWWC = registro.WWC * 0.07;
            double valorHora = registro.HORAS * 25;

            if (registro.WWC != 0)
                valorWWC = valorWWC < 10 ? 10 : valorWWC;

            registro.Valor = valorWWC + valorHora;

            await Task.FromResult(Task.CompletedTask);
        }

        public async Task AtivarDesativarEmMassa(List<int> id)
        {
            IEnumerable<Task> tasks = id.Select(x => _registroRepository.AtivarDesativarMultiThread(x));
            await Task.WhenAll(tasks);
        }
    }
}
