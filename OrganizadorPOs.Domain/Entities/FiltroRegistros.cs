using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorPOs.Domain.Entities
{
    public class FiltroRegistros
    {
        public bool? Status { get; set; }
        public bool? Pagamento { get; set; }
        public bool? Nf { get; set; }
        public bool? AtivadoDesativado { get; set; }
        public DateTime? FeitoEmMin { get; set; }
        public DateTime? FeitoEmMax { get; set; }
        public DateTime? RecebidaEmMin { get; set; }
        public DateTime? RecebidaEmMax { get; set; }
        public string? Projeto { get; set; }
        public string? Tipo { get; set; }
    }
}
