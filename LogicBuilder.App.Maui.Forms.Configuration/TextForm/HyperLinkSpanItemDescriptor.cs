namespace LogicBuilder.App.Maui.Forms.Configuration.TextForm
{
    public class HyperLinkSpanItemDescriptor(string text, string url) : SpanItemDescriptorBase
    {
        public string Text { get; } = text;
        public string Url { get; } = url;
    }
}
