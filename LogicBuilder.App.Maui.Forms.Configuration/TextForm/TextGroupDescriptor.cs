using System.Collections.Generic;

namespace LogicBuilder.App.Maui.Forms.Configuration.TextForm
{
    public class TextGroupDescriptor(string title, List<LabelItemDescriptorBase> labels)
    {
        public string Title { get; } = title;
        public List<LabelItemDescriptorBase> Labels { get; } = labels;
    }
}
