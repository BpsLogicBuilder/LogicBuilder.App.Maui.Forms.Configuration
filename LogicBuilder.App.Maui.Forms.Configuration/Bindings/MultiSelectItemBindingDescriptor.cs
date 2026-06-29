using System.Collections.Generic;

namespace LogicBuilder.App.Maui.Forms.Configuration.Bindings
{
    public class MultiSelectItemBindingDescriptor(string name, string property, string title, string stringFormat, List<string> keyFields, MultiSelectTemplateDescriptor multiSelectTemplate, string? fieldTypeSource) : ItemBindingDescriptor(name, property, title, stringFormat, fieldTypeSource)
    {
        public List<string> KeyFields { get; } = keyFields;
        public MultiSelectTemplateDescriptor MultiSelectTemplate { get; } = multiSelectTemplate;

        public override string TemplateName => MultiSelectTemplate.TemplateName;
    }
}
