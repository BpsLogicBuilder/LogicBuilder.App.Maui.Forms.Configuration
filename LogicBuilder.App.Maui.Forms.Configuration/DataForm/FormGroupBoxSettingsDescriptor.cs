using System.Collections.Generic;

namespace LogicBuilder.App.Maui.Forms.Configuration.DataForm
{
    public class FormGroupBoxSettingsDescriptor(string groupHeader, List<IFormItemSettingsDescriptor> fieldSettings, MultiBindingDescriptor? headerBindings, bool isHidden) : IFormItemSettingsDescriptor, IFormGroupBoxSettings
    {
        public string GroupHeader { get; } = groupHeader;
        public List<IFormItemSettingsDescriptor> FieldSettings { get; } = fieldSettings;
        public MultiBindingDescriptor? HeaderBindings { get; } = headerBindings;
        public bool IsHidden { get; } = isHidden;
    }
}
