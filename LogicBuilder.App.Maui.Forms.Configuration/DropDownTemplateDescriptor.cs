using LogicBuilder.Expressions.Utils.ExpressionDescriptors;

namespace LogicBuilder.App.Maui.Forms.Configuration
{
#pragma warning disable S107 //Parameters used to configure a control with several settings
    public class DropDownTemplateDescriptor(string templateName, string titleText, string textField, string valueField, string loadingIndicatorText, SelectorLambdaDescriptor textAndValueSelector, RequestDetailsDescriptor requestDetails, string? reloadItemsFlowName, string? fieldTypeSource)
#pragma warning restore S107
    {
        public string TemplateName { get; } = templateName;
        public string TitleText { get; } = titleText;
        public string TextField { get; } = textField;
        public string ValueField { get; } = valueField;
        public string LoadingIndicatorText { get; } = loadingIndicatorText;
        public SelectorLambdaDescriptor TextAndValueSelector { get; } = textAndValueSelector;
        public RequestDetailsDescriptor RequestDetails { get; } = requestDetails;
        public string? ReloadItemsFlowName { get; } = reloadItemsFlowName;
        public string? FieldTypeSource { get; } = fieldTypeSource;
    }
}
