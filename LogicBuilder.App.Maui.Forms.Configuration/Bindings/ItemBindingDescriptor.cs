namespace LogicBuilder.App.Maui.Forms.Configuration.Bindings
{
    abstract public class ItemBindingDescriptor(string name, string property, string title, string stringFormat, string? fieldTypeSource)
    {
        public string Name { get; } = name;
        public string Property { get; } = property;
        public string Title { get; } = title;
        public string StringFormat { get; } = stringFormat;
        public string? FieldTypeSource { get; } = fieldTypeSource;
        abstract public string TemplateName { get; }
    }
}
