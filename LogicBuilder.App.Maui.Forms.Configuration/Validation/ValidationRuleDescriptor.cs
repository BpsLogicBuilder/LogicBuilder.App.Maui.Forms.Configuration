namespace LogicBuilder.App.Maui.Forms.Configuration.Validation
{
    public class ValidationRuleDescriptor(string className, string message)
    {
        public string ClassName { get; } = className;
        public string Message { get; } = message;
    }
}
