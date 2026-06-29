using LogicBuilder.Expressions.Utils.ExpressionDescriptors;

namespace LogicBuilder.App.Maui.Forms.Configuration
{
#pragma warning disable S107 //Parameters used to configure a control with several settings
    public class MultiSelectTemplateDescriptor(string templateName, string placeholderText, string textField, string valueField, string modelType, string loadingIndicatorText, SelectorLambdaDescriptor textAndValueSelector, RequestDetailsDescriptor requestDetails, string? fieldTypeSource)
#pragma warning restore S107
    {
        public string TemplateName { get; } = templateName;
        public string PlaceholderText { get; } = placeholderText;
        public string TextField { get; } = textField;
        public string ValueField { get; } = valueField;
        public string ModelType { get; } = modelType;
        public string LoadingIndicatorText { get; } = loadingIndicatorText;
        public SelectorLambdaDescriptor TextAndValueSelector { get; } = textAndValueSelector;
        public RequestDetailsDescriptor RequestDetails { get; } = requestDetails;
        public string? FieldTypeSource { get; } = fieldTypeSource;
    }
}
