using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TesteSmartHint.Web.ViewModels.Customer
{
    public class CustomerViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Nome do Cliente/Razão Social")]
        public string Name { get; set; }

        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Telefone")]
        public string Phone { get; set; }

        [DisplayName("Data de Cadastro")]
        public string CreatedAt { get; set; }

        [DisplayName("Bloqueado")]
        public bool Blocked { get; set; }
    }
}
