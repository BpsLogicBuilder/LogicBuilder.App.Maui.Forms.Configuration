namespace LogicBuilder.App.Maui.Forms.Configuration.Bindings
{
    public class TextItemBindingDescriptor(string name, string property, string title, string stringFormat, TextFieldTemplateDescriptor textTemplate, string? fieldTypeSource) : ItemBindingDescriptor(name, property, title, stringFormat, fieldTypeSource)
    {
        public TextFieldTemplateDescriptor TextTemplate { get; } = textTemplate;

        public override string TemplateName => TextTemplate.TemplateName;
    }
}
