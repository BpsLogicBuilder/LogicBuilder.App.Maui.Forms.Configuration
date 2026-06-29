using System.Collections.Generic;

namespace LogicBuilder.App.Maui.Forms.Configuration.Validation
{
    public class ValidationMessageDescriptor(string field, List<ValidationRuleDescriptor> rules, string? fieldTypeSource)
    {
        public string Field { get; } = field;
        public List<ValidationRuleDescriptor> Rules { get; } = rules;
        public string? FieldTypeSource { get; } = fieldTypeSource;
    }
}
