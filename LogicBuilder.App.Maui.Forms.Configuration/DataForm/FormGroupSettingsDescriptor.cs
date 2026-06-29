using LogicBuilder.App.Maui.Forms.Configuration.Directives;
using LogicBuilder.App.Maui.Forms.Configuration.Validation;
using System.Collections.Generic;

namespace LogicBuilder.App.Maui.Forms.Configuration.DataForm
{
#pragma warning disable S107 //Parameters used to configure a form group with several settings
    public class FormGroupSettingsDescriptor(string field, string title, string validFormControlText, string invalidFormControlText, string placeholder, string modelType, FormGroupTemplateDescriptor formGroupTemplate, List<IFormItemSettingsDescriptor> fieldSettings, Dictionary<string, List<ValidationRuleDescriptor>> validationMessages, Dictionary<string, List<DirectiveDescriptor>>? conditionalDirectives, MultiBindingDescriptor? headerBindings, string? fieldTypeSource) : IFormItemSettingsDescriptor, IChildFormGroupSettings
#pragma warning restore S107
    {
        public string Field { get; } = field;
        public string Title { get; } = title;
        public string ValidFormControlText { get; } = validFormControlText;
        public string InvalidFormControlText { get; } = invalidFormControlText;
        public string Placeholder { get; } = placeholder;
        public string ModelType { get; } = modelType;
        public FormGroupTemplateDescriptor FormGroupTemplate { get; } = formGroupTemplate;
        public List<IFormItemSettingsDescriptor> FieldSettings { get; } = fieldSettings;
        public Dictionary<string, List<ValidationRuleDescriptor>> ValidationMessages { get; } = validationMessages;
        public Dictionary<string, List<DirectiveDescriptor>>? ConditionalDirectives { get; } = conditionalDirectives;
        public MultiBindingDescriptor? HeaderBindings { get; } = headerBindings;
        public string? FieldTypeSource { get; } = fieldTypeSource;
        public string GroupHeader => Title;
        public bool IsHidden => false;
    }
}
