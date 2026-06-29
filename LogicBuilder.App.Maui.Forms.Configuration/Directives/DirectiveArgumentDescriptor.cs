namespace LogicBuilder.App.Maui.Forms.Configuration.Directives
{
    public class DirectiveArgumentDescriptor(string name, object value, string type)
    {
        public string Name { get; } = name;
        public object Value { get; } = value;
        public string Type { get; } = type;
    }
}
