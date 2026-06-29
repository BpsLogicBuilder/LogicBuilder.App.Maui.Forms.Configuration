using LogicBuilder.App.Maui.Forms.Configuration.Bindings;
using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using System.Collections.Generic;

namespace LogicBuilder.App.Maui.Forms.Configuration.ListForm
{
    public class ListFormSettingsDescriptor(string title, string modelType, string loadingIndicatorText, string itemTemplateName, Dictionary<string, ItemBindingDescriptor> bindings, SelectorLambdaDescriptor fieldsSelector, RequestDetailsDescriptor requestDetails)
    {
        public string Title { get; } = title;
        public string ModelType { get; } = modelType;
        public string LoadingIndicatorText { get; } = loadingIndicatorText;
        public string ItemTemplateName { get; } = itemTemplateName;
        public Dictionary<string, ItemBindingDescriptor> Bindings { get; } = bindings;
        public SelectorLambdaDescriptor FieldsSelector { get; } = fieldsSelector;
        public RequestDetailsDescriptor RequestDetails { get; } = requestDetails;
    }
}
