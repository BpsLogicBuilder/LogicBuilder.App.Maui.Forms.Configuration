using LogicBuilder.Expressions.Utils.ExpressionDescriptors;

namespace LogicBuilder.App.Maui.Forms.Configuration.Directives
{
    public class DirectiveDescriptor(DirectiveDefinitionDescriptor definition, FilterLambdaDescriptor condition)
    {
        public DirectiveDefinitionDescriptor Definition { get; } = definition;
        public FilterLambdaDescriptor Condition { get; } = condition;
    }
}
