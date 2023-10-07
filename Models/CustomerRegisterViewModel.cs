using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TesteSmartHint.Models
{
    public class CustomerRegisterViewModel
    {
        
        [Required, MaxLength(150)]
        [DisplayName("Nome/Razão Social")]
        public string Name { get; set; }

        [Required, EmailAddress, MaxLength(150)]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Telefone")]
        public string Phone { get; set; }
    }
}
