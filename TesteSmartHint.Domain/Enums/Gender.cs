using System.ComponentModel.DataAnnotations;

namespace TesteSmartHint.Domain.Enums
{
    public enum Gender
    {
        [Display(Name = "Feminino")]
        Female,
        [Display(Name = "Masculino")]
        Male,
        [Display(Name = "Outro")]
        Other
    }
}
