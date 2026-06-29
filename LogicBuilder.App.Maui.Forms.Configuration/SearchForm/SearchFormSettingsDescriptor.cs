using LogicBuilder.App.Maui.Forms.Configuration.Bindings;
using System.Collections.Generic;

namespace LogicBuilder.App.Maui.Forms.Configuration.SearchForm
{
#pragma warning disable S107 //Parameters used to configure a form with several settings
    public class SearchFormSettingsDescriptor(string title, string modelType, string loadingIndicatorText, string itemTemplateName, string filterPlaceholder, string createPagingSelectorFlowName, Dictionary<string, ItemBindingDescriptor> bindings, RequestDetailsDescriptor requestDetails)
#pragma warning restore S107
    {
        public string Title { get; } = title;
        public string ModelType { get; } = modelType;
        public string LoadingIndicatorText { get; } = loadingIndicatorText;
        public string ItemTemplateName { get; } = itemTemplateName;
        public string FilterPlaceholder { get; } = filterPlaceholder;
        public string CreatePagingSelectorFlowName { get; } = createPagingSelectorFlowName;
        public Dictionary<string, ItemBindingDescriptor> Bindings { get; } = bindings;
        public RequestDetailsDescriptor RequestDetails { get; } = requestDetails;
    }
}
