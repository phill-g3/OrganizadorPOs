using System.ComponentModel.DataAnnotations;

namespace OrganizadorPOs.ViewModels
{
    public class RegistroViewModel
    {
        public int Id { get; set; }

        [MaxLength(25, ErrorMessage = "Máximo de 25 caracteres")]
        public string? Projeto { get; set; }

        [MaxLength(25, ErrorMessage = "Máximo de 25 caracteres")]
        public string? Tipo { get; set; }
        public decimal WWC { get; set; }
        public decimal HORAS { get; set; }

        private DateTime? _feitoEm;
        public DateTime? FeitoEm { get { return _feitoEm; } 
            set {
                if (value == DateTime.MinValue)
                    _feitoEm = null;
                else
                    _feitoEm = value;
            }
        }

        [MaxLength(25, ErrorMessage = "Máximo de 25 caracteres")]
        public string? PO { get; set; }
        public decimal ValorPO { get; set; }
        public bool Status { get; set; }

        private DateTime? _recebidaEm;
        public DateTime? RecebidaEm
        {
            get { return _recebidaEm; }
            set
            {
                if (value == DateTime.MinValue)
                    _recebidaEm = null;
                else
                    _recebidaEm = value;
            }
        }

        public decimal Valor { get; set; }
        public bool EmitiuNotaFiscal { get; set; }
        public bool PagamentoRecebido { get; set; }
        public DateTime? DataExclusao { get; set; }
    }
}
