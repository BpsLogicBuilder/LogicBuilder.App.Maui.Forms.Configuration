using LogicBuilder.App.Maui.Forms.Configuration.Validation;

namespace LogicBuilder.App.Maui.Forms.Configuration.DataForm
{
#pragma warning disable S107 //Parameters used to configure a form group with several settings
    public class DropdownSelectorControlSettingsDescriptor(string field, string title, string placeholder, string stringFormat, string type, DropDownTemplateDescriptor dropDownTemplate, FieldValidationSettingsDescriptor? validationSetting, string? fieldTypeSource) : IFormItemSettingsDescriptor
#pragma warning restore S107
    {
        public string Field { get; } = field;
        public string Title { get; } = title;
        public string Placeholder { get; } = placeholder;
        public string StringFormat { get; } = stringFormat;
        public string Type { get; } = type;
        public DropDownTemplateDescriptor DropDownTemplate { get; } = dropDownTemplate;
        public FieldValidationSettingsDescriptor? ValidationSetting { get; } = validationSetting;
        public string? FieldTypeSource { get; } = fieldTypeSource;
    }
}
