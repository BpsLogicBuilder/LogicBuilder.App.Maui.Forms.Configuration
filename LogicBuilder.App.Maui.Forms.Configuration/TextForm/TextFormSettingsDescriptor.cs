using System.Collections.Generic;

namespace LogicBuilder.App.Maui.Forms.Configuration.TextForm
{
    public class TextFormSettingsDescriptor(string title, List<TextGroupDescriptor> textGroups)
    {
        public string Title { get; } = title;
        public List<TextGroupDescriptor> TextGroups { get; } = textGroups;
    }
}
