using LogicBuilder.App.Maui.Forms.Configuration.Directives;
using LogicBuilder.App.Maui.Forms.Configuration.Validation;
using System.Collections.Generic;

namespace LogicBuilder.App.Maui.Forms.Configuration.DataForm
{
#pragma warning disable S107 //Parameters used to configure a form array with several settings
    public class FormGroupArraySettingsDescriptor(string field, string title, string placeholder, string modelType, string type, string validFormControlText, string invalidFormControlText, List<string> keyFields, FormsCollectionDisplayTemplateDescriptor formsCollectionDisplayTemplate, FormGroupTemplateDescriptor formGroupTemplate, List<IFormItemSettingsDescriptor> fieldSettings, Dictionary<string, List<ValidationRuleDescriptor>> validationMessages, Dictionary<string, List<DirectiveDescriptor>>? conditionalDirectives, MultiBindingDescriptor? headerBindings, string? fieldTypeSource, string? listElementTypeSource) : IFormItemSettingsDescriptor, IChildFormGroupSettings
#pragma warning restore S107
    {
        public string Field { get; } = field;
        public string Title { get; } = title;
        public string Placeholder { get; } = placeholder;
        public string ModelType { get; } = modelType;
        public string Type { get; } = type;
        public string ValidFormControlText { get; } = validFormControlText;
        public string InvalidFormControlText { get; } = invalidFormControlText;
        public List<string> KeyFields { get; } = keyFields;
        public FormsCollectionDisplayTemplateDescriptor FormsCollectionDisplayTemplate { get; } = formsCollectionDisplayTemplate;
        public FormGroupTemplateDescriptor FormGroupTemplate { get; } = formGroupTemplate;
        public List<IFormItemSettingsDescriptor> FieldSettings { get; } = fieldSettings;
        public Dictionary<string, List<ValidationRuleDescriptor>> ValidationMessages { get; } = validationMessages;
        public Dictionary<string, List<DirectiveDescriptor>>? ConditionalDirectives { get; } = conditionalDirectives;
        public MultiBindingDescriptor? HeaderBindings { get; } = headerBindings;
        public string? FieldTypeSource { get; } = fieldTypeSource;
        public string? ListElementTypeSource { get; } = listElementTypeSource;
        public string GroupHeader => Title;
        public bool IsHidden => false;
    }
}
