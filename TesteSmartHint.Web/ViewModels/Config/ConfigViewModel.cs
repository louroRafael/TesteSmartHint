using System.ComponentModel.DataAnnotations;

namespace TesteSmartHint.Web.ViewModels.Config
{
    public class ConfigViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Value { get; set; }
    }
}
