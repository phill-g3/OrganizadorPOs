﻿using OrganizadorPOs.Domain.Entities;

namespace OrganizadorPOs.Domain.Interfaces
{
    public interface IRegistroService : IBaseService<Registro>
    {
        Task<List<Registro>> List(FiltroRegistros filtro);
        Task AtivarDesativar(int id);
        Task AtivarDesativarEmMassa(List<int> id);
        Task AdicionarAtualizar(Registro registro);
        Task<List<Tipo>> ListarTipos();
        Task<byte[]> GerarExcel(List<Registro> registros);
    }
}
