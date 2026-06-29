using LogicBuilder.Expressions.Utils.ExpansionDescriptors;
using LogicBuilder.Expressions.Utils.ExpressionDescriptors;

namespace LogicBuilder.App.Maui.Forms.Configuration
{
#pragma warning disable S107 //Parameters used to configure a request with several settings
    public class FormRequestDetailsDescriptor(string getUrl, string addUrl, string updateUrl, string deleteUrl, string modelType, string dataType, FilterLambdaDescriptor? filter, SelectExpandDefinitionDescriptor? selectExpandDefinition)
#pragma warning restore S107
    {
        public string GetUrl { get; } = getUrl;
        public string AddUrl { get; } = addUrl;
        public string UpdateUrl { get; } = updateUrl;
        public string DeleteUrl { get; } = deleteUrl;
        public string ModelType { get; } = modelType;
        public string DataType { get; } = dataType;
        public FilterLambdaDescriptor? Filter { get; } = filter;
        public SelectExpandDefinitionDescriptor? SelectExpandDefinition { get; } = selectExpandDefinition;
    }
}
