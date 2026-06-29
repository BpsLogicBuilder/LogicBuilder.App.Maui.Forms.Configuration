using LogicBuilder.App.Maui.Forms.Configuration.Directives;
using LogicBuilder.App.Maui.Forms.Configuration.Validation;
using System.Collections.Generic;

namespace LogicBuilder.App.Maui.Forms.Configuration.DataForm
{
    public interface IFormGroupSettings : IFormGroupBoxSettings
    {
        string ModelType { get; }
        string Title { get; }
        Dictionary<string, List<DirectiveDescriptor>>? ConditionalDirectives { get; }
        Dictionary<string, List<ValidationRuleDescriptor>> ValidationMessages { get; }
    }
}
