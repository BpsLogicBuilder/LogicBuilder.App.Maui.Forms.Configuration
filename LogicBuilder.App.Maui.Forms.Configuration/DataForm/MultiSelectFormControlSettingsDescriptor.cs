using LogicBuilder.App.Maui.Forms.Configuration.Validation;
using System.Collections.Generic;

namespace LogicBuilder.App.Maui.Forms.Configuration.DataForm
{
#pragma warning disable S107 //Parameters used to configure a control with several settings
    public class MultiSelectFormControlSettingsDescriptor(string field, List<string> keyFields, string title, string placeholder, string stringFormat, string type, MultiSelectTemplateDescriptor multiSelectTemplate, FieldValidationSettingsDescriptor? validationSetting, string? fieldTypeSource, string? listElementTypeSource) : IFormItemSettingsDescriptor
#pragma warning restore S107
    {
        public string Field { get; } = field;
        public List<string> KeyFields { get; } = keyFields;
        public string Title { get; } = title;
        public string Placeholder { get; } = placeholder;
        public string StringFormat { get; } = stringFormat;
        public string Type { get; } = type;
        public MultiSelectTemplateDescriptor MultiSelectTemplate { get; } = multiSelectTemplate;
        public FieldValidationSettingsDescriptor? ValidationSetting { get; } = validationSetting;
        public string? FieldTypeSource { get; } = fieldTypeSource;
        public string? ListElementTypeSource { get; } = listElementTypeSource;
    }
}
