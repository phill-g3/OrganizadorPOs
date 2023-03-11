using System.ComponentModel.DataAnnotations;

namespace OrganizadorPOs.Domain.Entities
{
    public class Tipo
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string? Nome { get; set; }
    }
}
