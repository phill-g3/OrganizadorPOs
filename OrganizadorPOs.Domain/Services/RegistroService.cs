using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using OrganizadorPOs.Domain.Entities;
using OrganizadorPOs.Domain.Interfaces;

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
            await Task.WhenAll(ChecarSeTipoExiste(registro), CalcularValor(registro));

            if (registro.Id == 0)
                await _registroRepository.Adicionar(registro);
            else
                await _registroRepository.Atualizar(registro);
        }

        public async Task AtivarDesativar(int id)
        {
            await _registroRepository.AtivarDesativar(id);
        }

        public async Task<List<Registro>> List(FiltroRegistros filtro)
        {
            List<Registro> retorno = await _registroRepository.List(filtro);

            return retorno;
        }

        public async Task<List<Tipo>> ListarTipos()
        {
            IQueryable<Tipo> query = await _tipoRepository.ObterQueryable();

            return await query.ToListAsync();
        }

        public async Task<byte[]> GerarExcel(List<Registro> registros)
        {
            using (var workbook = new XLWorkbook())
            {
                IXLWorksheet worksheet = workbook.Worksheets.Add("Controle");
                int currentRow = 1;

                #region Header
                worksheet.Cell(currentRow, 1).Value = "PROJETO";
                worksheet.Cell(currentRow, 2).Value = "TIPO";
                worksheet.Cell(currentRow, 3).Value = "WWC";
                worksheet.Cell(currentRow, 4).Value = "HORAS";
                worksheet.Cell(currentRow, 5).Value = "FEITO EM";
                worksheet.Cell(currentRow, 6).Value = "VALOR (R$)";
                worksheet.Cell(currentRow, 7).Value = "PO";
                worksheet.Cell(currentRow, 8).Value = "STATUS";
                worksheet.Cell(currentRow, 9).Value = "RECEBIDA EM";
                worksheet.Cell(currentRow, 10).Value = "VALOR PO (R$)";
                worksheet.Cell(currentRow, 11).Value = "NOTA FISCAL";
                worksheet.Cell(currentRow, 12).Value = "PAGAMENTO";
                #endregion

                #region Body
                foreach (Registro registro in registros)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = registro.Projeto;
                    worksheet.Cell(currentRow, 2).Value = registro.Tipo;
                    worksheet.Cell(currentRow, 3).Value = registro.WWC;
                    worksheet.Cell(currentRow, 4).Value = registro.HORAS;
                    worksheet.Cell(currentRow, 5).Value = registro.FeitoEm;
                    worksheet.Cell(currentRow, 6).Value = registro.Valor;
                    worksheet.Cell(currentRow, 7).Value = registro.PO;
                    worksheet.Cell(currentRow, 8).Value = registro.Status ? "Recebida" : "Pendente";
                    worksheet.Cell(currentRow, 9).Value = registro.RecebidaEm;
                    worksheet.Cell(currentRow, 10).Value = registro.ValorPO;
                    worksheet.Cell(currentRow, 11).Value = registro.EmitiuNotaFiscal ? "Emitida" : "Pendente";
                    worksheet.Cell(currentRow, 12).Value = registro.PagamentoRecebido ? "Pago" : "Pendente";
                }
                #endregion

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    byte[] content = stream.ToArray();

                    return await Task.FromResult(content);
                }
            }
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
