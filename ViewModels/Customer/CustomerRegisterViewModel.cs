using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TesteSmartHint.Domain.Enums;
using TesteSmartHint.Domain.Helpers;

namespace TesteSmartHint.Web.ViewModels.Customer
{
    public class CustomerRegisterViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [MaxLength(150, ErrorMessage = "O nome deve possuir no máximo 150 caracteres")]
        [DisplayName("Nome do Cliente/Razão Social")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo E-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "Endereço de e-mail inválido")] 
        [MaxLength(150, ErrorMessage = "O nome deve possuir no máximo 150 caracteres")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Telefone é obrigatório")]
        [MaxLength(15, ErrorMessage = "O telefone deve possuir no máximo 11 dígitos")]
        [DisplayName("Telefone")]
        public string Phone { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Data de Cadastro")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "O campo Tipo de Pessoa é obrigatório")]
        [DisplayName("Tipo de Pessoa")]
        public PersonType Type { get; set; }

        [Required(ErrorMessage = "O campo CPF/CNPJ é obrigatório")]
        [MaxLength(18, ErrorMessage = "O campo CPF/CNPJ deve possuir no máximo 14 dígitos")]
        [DisplayName("CPF/CNPJ")]
        public string CpfCnpj { get; set; }

        [RequiredStateRegistration(nameof(Exempt), nameof(Type), ErrorMessage = "O campo Inscrição Estadual é obrigatório")]
        [MaxLength(15, ErrorMessage = "O campo Incrição Estadual deve possuir no máximo 12 dígitos")]
        [DisplayName("Inscrição Estadual")]
        public string? StateRegistration { get; set; }

        [DisplayName("Isento")]
        public bool Exempt { get; set; }

        [RequiredNaturalPerson(nameof(Type), ErrorMessage = "O campo Gênero é obrigatório")]
        [DisplayName("Gênero")]
        public Gender? Gender { get; set; }

        [RequiredNaturalPerson(nameof(Type), ErrorMessage = "O campo Data de Nascimento é obrigatório")]
        [DataType(DataType.Date)]
        [DisplayName("Data de Nascimento")]
        public DateTime? Birth { get; set; }

        [DisplayName("Bloqueado")]
        public bool Blocked { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório")]
        [MinLength(8, ErrorMessage = "A senha deve possuir pelo menos 8 caracteres")]
        [MaxLength(15, ErrorMessage = "A senha deve possuir no máximo 15 caracteres")]
        [DisplayName("Senha")]
        public string Password { get; set; }

        [Required(ErrorMessage = "O campo Confirmação Senha é obrigatório")]
        [MinLength(8, ErrorMessage = "A senha deve possuir pelo menos 8 caracteres")]
        [MaxLength(15, ErrorMessage = "A senha deve possuir no máximo 15 caracteres")]
        [Compare("Password", ErrorMessage = "As senhas não conferem.")]
        [DisplayName("Confirmação Senha")]
        public string PasswordConfirm { get; set; }
    }
}
