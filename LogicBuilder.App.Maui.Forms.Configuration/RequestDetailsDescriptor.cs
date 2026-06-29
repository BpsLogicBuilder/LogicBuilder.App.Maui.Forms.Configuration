namespace LogicBuilder.App.Maui.Forms.Configuration
{
    public class RequestDetailsDescriptor(string modelType, string dataType, string modelReturnType, string dataReturnType, string dataSourceUrl)
    {
        public string ModelType { get; } = modelType;
        public string DataType { get; } = dataType;
        public string ModelReturnType { get; } = modelReturnType;
        public string DataReturnType { get; } = dataReturnType;
        public string DataSourceUrl { get; } = dataSourceUrl;
    }
}
