using System.Collections.Generic;

namespace LogicBuilder.App.Maui.Forms.Configuration.Navigation
{
    public class NavigationBarDescriptor(string brandText, string currentModule, List<NavigationMenuItemDescriptor> menuItems)
    {
        public string BrandText { get; } = brandText;
        public string CurrentModule { get; } = currentModule;
        public List<NavigationMenuItemDescriptor> MenuItems { get; } = menuItems;
    }
}
