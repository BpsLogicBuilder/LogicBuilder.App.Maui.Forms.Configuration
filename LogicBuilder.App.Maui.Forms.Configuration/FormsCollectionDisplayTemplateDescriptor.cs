using LogicBuilder.App.Maui.Forms.Configuration.Bindings;
using System.Collections.Generic;

namespace LogicBuilder.App.Maui.Forms.Configuration
{
    public class FormsCollectionDisplayTemplateDescriptor(string templateName, Dictionary<string, ItemBindingDescriptor> bindings)
    {
        public string TemplateName { get; } = templateName;
        public Dictionary<string, ItemBindingDescriptor> Bindings { get; } = bindings;
    }
}
