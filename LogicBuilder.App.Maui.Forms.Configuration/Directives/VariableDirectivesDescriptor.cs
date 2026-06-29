using System.Collections.Generic;

namespace LogicBuilder.App.Maui.Forms.Configuration.Directives
{
    public class VariableDirectivesDescriptor(string field, List<DirectiveDescriptor> conditionalDirectives, string? fieldTypeSource)
    {
        public string Field { get; } = field;
        public List<DirectiveDescriptor> ConditionalDirectives { get; } = conditionalDirectives;
        public string? FieldTypeSource { get; } = fieldTypeSource;
    }
}
