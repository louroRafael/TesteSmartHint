using System.ComponentModel.DataAnnotations;

namespace TesteSmartHint.Domain.Entities
{
    public class Config : EntityBase
    {
        [Required, MaxLength(150)]
        public string Name { get; set; }
        [Required, MaxLength(150)]
        public string Description { get; set; }
        [Required]
        public bool Value { get; set; }
    }
}
