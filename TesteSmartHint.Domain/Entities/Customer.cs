using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TesteSmartHint.Domain.Enums;

namespace TesteSmartHint.Domain.Entities
{
    public class Customer : EntityBase
    {
        [Required, MaxLength(150)]
        public string Name { get; set; }

        [Required, MaxLength(150)]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        public DateTime CreatedAt { get; set; }

        [Required]
        public PersonType Type { get; set; }

        [Required]
        public string CpfCnpj { get; set; }

        public string? StateRegistration { get; set; }

        public bool Exempt { get; set; }

        public Gender? Gender { get; set; }

        public DateTime? Birth { get; set; }

        public bool Blocked { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
