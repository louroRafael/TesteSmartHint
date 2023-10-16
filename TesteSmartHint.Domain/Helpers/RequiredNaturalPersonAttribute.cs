using System.ComponentModel.DataAnnotations;
using TesteSmartHint.Domain.Enums;

namespace TesteSmartHint.Domain.Helpers
{
    public class RequiredNaturalPersonAttribute : RequiredAttribute
    {
        private string PersonTypePropertyName { get; set; }

        public RequiredNaturalPersonAttribute(string personTypePropertyName)
        {
            PersonTypePropertyName = personTypePropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            object instance = context.ObjectInstance;
            Type type = instance.GetType();

            var personTypeValue = (PersonType)type.GetProperty(PersonTypePropertyName).GetValue(instance);

            if (personTypeValue == PersonType.NaturalPerson && value == null)
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;
        }
    }
}
