using System.Collections.Generic;

namespace LogicBuilder.App.Maui.Forms.Configuration.Validation
{
    public class FieldValidationSettingsDescriptor(object defaultValue, List<ValidatorDefinitionDescriptor>? validators)
    {
        public object DefaultValue { get; } = defaultValue;
        public List<ValidatorDefinitionDescriptor>? Validators { get; } = validators;
    }
}
