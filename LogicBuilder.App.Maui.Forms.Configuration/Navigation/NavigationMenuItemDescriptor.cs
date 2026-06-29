using System.Collections.Generic;

namespace LogicBuilder.App.Maui.Forms.Configuration.Navigation
{
    public class NavigationMenuItemDescriptor(string initialModule, string text, string icon, bool active, List<NavigationMenuItemDescriptor> subItems)
    {
        public string InitialModule { get; } = initialModule;
        public string Text { get; } = text;
        public string Icon { get; } = icon;
        public bool Active { get; } = active;
        public List<NavigationMenuItemDescriptor> SubItems { get; } = subItems;
    }
}
