using LogicBuilder.App.Maui.Forms.Configuration.Directives;
using LogicBuilder.App.Maui.Forms.Configuration.Validation;
using System.Collections.Generic;

namespace LogicBuilder.App.Maui.Forms.Configuration.DataForm
{
#pragma warning disable S107 //Parameters used to configure a form with several settings
    public class DataFormSettingsDescriptor(string title, Dictionary<string, List<ValidationRuleDescriptor>> validationMessages, List<IFormItemSettingsDescriptor> fieldSettings, FormType formType, string modelType, MultiBindingDescriptor? headerBindings, FormRequestDetailsDescriptor? requestDetails, Dictionary<string, List<DirectiveDescriptor>>? conditionalDirectives, MultiBindingDescriptor? subtitleBindings) : IFormGroupSettings
#pragma warning restore S107
    {
        public string Title { get; } = title;
        public Dictionary<string, List<ValidationRuleDescriptor>> ValidationMessages { get; } = validationMessages;
        public List<IFormItemSettingsDescriptor> FieldSettings { get; } = fieldSettings;
        public FormType FormType { get; } = formType;
        public string ModelType { get; } = modelType;
        public MultiBindingDescriptor? HeaderBindings { get; } = headerBindings;
        public FormRequestDetailsDescriptor? RequestDetails { get; } = requestDetails;
        public Dictionary<string, List<DirectiveDescriptor>>? ConditionalDirectives { get; } = conditionalDirectives;
        public MultiBindingDescriptor? SubtitleBindings { get; } = subtitleBindings;
        public string GroupHeader => Title;
        public bool IsHidden => false;
    }
}
