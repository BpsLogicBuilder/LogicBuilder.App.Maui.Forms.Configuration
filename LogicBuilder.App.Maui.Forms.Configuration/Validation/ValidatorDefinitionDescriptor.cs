using System.Collections.Generic;

namespace LogicBuilder.App.Maui.Forms.Configuration.Validation
{
    public class ValidatorDefinitionDescriptor(string className, string functionName, Dictionary<string, ValidatorArgumentDescriptor>? arguments)
    {
        public string ClassName { get; } = className;
        public string FunctionName { get; } = functionName;
        public Dictionary<string, ValidatorArgumentDescriptor>? Arguments { get; } = arguments;
    }
}
