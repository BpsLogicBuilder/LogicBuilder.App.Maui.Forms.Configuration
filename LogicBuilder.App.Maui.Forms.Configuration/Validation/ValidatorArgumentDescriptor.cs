namespace LogicBuilder.App.Maui.Forms.Configuration.Validation
{
    public class ValidatorArgumentDescriptor(string name, object value, string type)
    {
        public string Name { get; } = name;
        public object Value { get; } = value;
        public string Type { get; } = type;
    }
}
