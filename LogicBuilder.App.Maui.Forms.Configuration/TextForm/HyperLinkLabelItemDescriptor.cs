namespace LogicBuilder.App.Maui.Forms.Configuration.TextForm
{
    public class HyperLinkLabelItemDescriptor(string text, string url) : LabelItemDescriptorBase
    {
        public string Text { get; } = text;
        public string Url { get; } = url;
    }
}
