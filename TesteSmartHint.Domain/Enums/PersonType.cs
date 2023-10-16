using System.ComponentModel.DataAnnotations;

namespace TesteSmartHint.Domain.Enums
{
    public enum PersonType
    {
        [Display(Name = "Física")]
        NaturalPerson,
        [Display(Name = "Jurídica")]
        LegalPerson
    }
}
