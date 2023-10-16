using System.ComponentModel.DataAnnotations;
using TesteSmartHint.Domain.Enums;

namespace TesteSmartHint.Domain.Helpers
{
    public class RequiredStateRegistrationAttribute : RequiredAttribute
    {
        private string ExemptPropertyName { get; set; }
        private string PersonTypePropertyName { get; set; }
        private string ForNaturalPersonPropertyName { get; set; }

        public RequiredStateRegistrationAttribute(string exemptPropertyName, string personTypePropertyName, string forNaturalPersonPropertyName)
        {
            ExemptPropertyName = exemptPropertyName;
            PersonTypePropertyName = personTypePropertyName;
            ForNaturalPersonPropertyName = forNaturalPersonPropertyName;
        }
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            object instance = context.ObjectInstance;
            Type type = instance.GetType();

            var exemptValue = (bool)type.GetProperty(ExemptPropertyName).GetValue(instance);
            var personTypeValue = (PersonType)type.GetProperty(PersonTypePropertyName).GetValue(instance);
            var forNaturalPersonValue = (bool)type.GetProperty(ForNaturalPersonPropertyName).GetValue(instance);

            if (!exemptValue && (personTypeValue == PersonType.LegalPerson || forNaturalPersonValue) && value == null)
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;
        }

    }
}
