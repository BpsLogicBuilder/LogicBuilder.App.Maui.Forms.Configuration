using LogicBuilder.App.Maui.Forms.Configuration.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicBuilder.App.Maui.Forms.Configuration.DataForm
{
#pragma warning disable S107 //Parameters used to configure a form group with several settings
    public class InputFieldControlSettingsDescriptor(string field, string title, string placeholder, string stringFormat, string type, TextFieldTemplateDescriptor textTemplate, TextFieldTemplateDescriptor? updateOnlyTextTemplate, FieldValidationSettingsDescriptor? validationSetting, string? fieldTypeSource) : IFormItemSettingsDescriptor
#pragma warning restore S107
    {
        public string Field { get; } = field;
        public string Title { get; } = title;
        public string Placeholder { get; } = placeholder;
        public string StringFormat { get; } = stringFormat;
        public string Type { get; } = type;
        public TextFieldTemplateDescriptor TextTemplate { get; } = textTemplate;
        public TextFieldTemplateDescriptor? UpdateOnlyTextTemplate { get; } = updateOnlyTextTemplate;
        public FieldValidationSettingsDescriptor? ValidationSetting { get; } = validationSetting;
        public string? FieldTypeSource { get; } = fieldTypeSource;
    }
}
