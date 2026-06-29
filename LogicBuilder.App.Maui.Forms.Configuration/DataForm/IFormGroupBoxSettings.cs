using System.Collections.Generic;

namespace LogicBuilder.App.Maui.Forms.Configuration.DataForm
{
    public interface IFormGroupBoxSettings
    {
        string GroupHeader { get; }
        List<IFormItemSettingsDescriptor> FieldSettings { get; }
        MultiBindingDescriptor? HeaderBindings { get; }
        bool IsHidden { get; }
    }
}
