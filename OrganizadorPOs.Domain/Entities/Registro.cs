using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrganizadorPOs.Domain.Entities
{
    public class Registro
    {
        public int Id { get; set; }

        [MaxLength(25)]
        public string? Projeto { get; set; }

        [MaxLength(25)]
        public string? Tipo { get; set; }
        public double WWC { get; set; }
        public double HORAS { get; set; }
        public DateTime? FeitoEm { get; set; }

        [MaxLength(25)]
        public string? PO { get; set; }
        public double ValorPO { get; set; }
        public bool Status { get; set; }
        public DateTime? RecebidaEm { get; set; }
        public double Valor { get; set; }
        public bool EmitiuNotaFiscal { get; set; }
        public bool PagamentoRecebido { get; set; }
        public DateTime? DataExclusao { get; set; }
    }
}
