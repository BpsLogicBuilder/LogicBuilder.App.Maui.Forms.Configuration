namespace LogicBuilder.App.Maui.Forms.Configuration.DataForm
{
    public interface IChildFormGroupSettings : IFormGroupSettings
    {
        string ValidFormControlText { get; }
        string InvalidFormControlText { get; }
        string Placeholder { get; }
        FormGroupTemplateDescriptor FormGroupTemplate { get; }
    }
}
