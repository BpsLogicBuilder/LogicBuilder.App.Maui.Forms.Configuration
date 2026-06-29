namespace LogicBuilder.App.Maui.Forms.Configuration.Bindings
{
    public class DropDownItemBindingDescriptor(string name, string property, string title, string stringFormat, DropDownTemplateDescriptor dropDownTemplate, bool requiresReload, string? fieldTypeSource) : ItemBindingDescriptor(name, property, title, stringFormat, fieldTypeSource)
    {
        public DropDownTemplateDescriptor DropDownTemplate { get; } = dropDownTemplate;
        public bool RequiresReload { get; } = requiresReload;

        public override string TemplateName => DropDownTemplate.TemplateName;
    }
}
