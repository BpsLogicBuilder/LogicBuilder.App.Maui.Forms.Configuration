using LogicBuilder.App.Maui.Forms.Configuration.Navigation;
using System.Collections.Generic;
using System.Text.Json;

namespace LogicBuilder.App.Maui.Forms.Configuration.Tests.Navigation
{
    public class NavigationBarDescriptorTest
    {
        [Fact]
        public void CanSerializeNavigationBarDescriptor()
        {
            // Arrange
            var menuItem = new NavigationMenuItemDescriptor("Home", "Home", "home.png", true, []);
            var descriptor = new NavigationBarDescriptor(
                brandText: "My App",
                currentModule: "Home",
                menuItems: [menuItem]
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor, SerializationOptions.Default);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(json));
            Assert.Contains("\"BrandText\"", json);
            Assert.Contains("\"CurrentModule\"", json);
            Assert.Contains("\"MenuItems\"", json);
        }

        [Fact]
        public void CanDeserializeNavigationBarDescriptor()
        {
            // Arrange
            string json = """
                {
                    "BrandText": "My App",
                    "CurrentModule": "Home",
                    "MenuItems": [
                        {
                            "InitialModule": "Home",
                            "Text": "Home",
                            "Icon": "home.png",
                            "Active": true,
                            "SubItems": []
                        }
                    ]
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<NavigationBarDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("My App", descriptor.BrandText);
            Assert.Equal("Home", descriptor.CurrentModule);
            Assert.NotNull(descriptor.MenuItems);
            Assert.Single(descriptor.MenuItems);
        }

        [Fact]
        public void SerializationRoundTripPreservesAllProperties()
        {
            // Arrange
            var original = new NavigationBarDescriptor(
                brandText: "Test App",
                currentModule: "Dashboard",
                menuItems: []
            );

            // Act
            string json = JsonSerializer.Serialize(original, SerializationOptions.Default);
            var deserialized = JsonSerializer.Deserialize<NavigationBarDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserialized);
            Assert.Equal(original.BrandText, deserialized.BrandText);
            Assert.Equal(original.CurrentModule, deserialized.CurrentModule);
        }

        [Fact]
        public void CanDeserializeWithCaseInsensitivePropertyNames()
        {
            // Arrange
            string json = """
                {
                    "brandtext": "App Name",
                    "currentmodule": "Settings",
                    "menuitems": []
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<NavigationBarDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("App Name", descriptor.BrandText);
        }
    }
}
