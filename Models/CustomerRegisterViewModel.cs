using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TesteSmartHint.Models
{
    public class CustomerRegisterViewModel
    {
        public Guid Id { get; set; }

        [Required, MaxLength(150)]
        [DisplayName("Nome do Cliente/Razão Social")]
        public string Name { get; set; }

        [Required, EmailAddress, MaxLength(150)]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Telefone")]
        public string Phone { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Data de Cadastro")]
        public DateTime CreatedAt { get; set; }
    }
}
