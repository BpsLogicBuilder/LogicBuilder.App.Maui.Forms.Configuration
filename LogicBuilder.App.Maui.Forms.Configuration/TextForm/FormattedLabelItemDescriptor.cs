using System.Collections.Generic;

namespace LogicBuilder.App.Maui.Forms.Configuration.TextForm
{
    public class FormattedLabelItemDescriptor(List<SpanItemDescriptorBase> items) : LabelItemDescriptorBase
    {
        public List<SpanItemDescriptorBase> Items { get; } = items;
    }
}
