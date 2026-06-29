namespace LogicBuilder.App.Maui.Forms.Configuration.SearchForm
{
    public class SearchFilterDescriptor(string field, string? fieldTypeSource) : SearchFilterDescriptorBase
    {
        public string Field { get; } = field;
        public string? FieldTypeSource { get; } = fieldTypeSource;
    }
}
