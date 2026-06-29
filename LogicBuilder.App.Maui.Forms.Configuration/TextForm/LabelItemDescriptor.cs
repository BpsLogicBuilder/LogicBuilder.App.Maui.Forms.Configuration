namespace LogicBuilder.App.Maui.Forms.Configuration.TextForm
{
    public class LabelItemDescriptor(string text) : LabelItemDescriptorBase
    {
        public string Text { get; } = text;
    }
}
