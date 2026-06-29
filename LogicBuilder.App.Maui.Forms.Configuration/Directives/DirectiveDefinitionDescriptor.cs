using System.Collections.Generic;

namespace LogicBuilder.App.Maui.Forms.Configuration.Directives
{
    public class DirectiveDefinitionDescriptor(string className, string functionName, Dictionary<string, DirectiveArgumentDescriptor>? arguments)
    {
        public string ClassName { get; } = className;
        public string FunctionName { get; } = functionName;
        public Dictionary<string, DirectiveArgumentDescriptor>? Arguments { get; } = arguments;
    }
}
