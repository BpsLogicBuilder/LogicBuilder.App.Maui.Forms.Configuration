using LogicBuilder.App.Maui.Forms.Configuration.Navigation;
using System.Collections.Generic;
using System.Text.Json;

namespace LogicBuilder.App.Maui.Forms.Configuration.Tests.Navigation
{
    public class NavigationMenuItemDescriptorTest
    {
        [Fact]
        public void CanSerializeNavigationMenuItemDescriptor()
        {
            // Arrange
            var descriptor = new NavigationMenuItemDescriptor(
                initialModule: "Home",
                text: "Home",
                icon: "home.png",
                active: true,
                subItems: []
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor, SerializationOptions.Default);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(json));
            Assert.Contains("\"InitialModule\"", json);
            Assert.Contains("\"Text\"", json);
            Assert.Contains("\"Icon\"", json);
            Assert.Contains("\"Active\"", json);
            Assert.Contains("\"SubItems\"", json);
        }

        [Fact]
        public void CanDeserializeNavigationMenuItemDescriptor()
        {
            // Arrange
            string json = """
                {
                    "InitialModule": "Home",
                    "Text": "Home",
                    "Icon": "home.png",
                    "Active": true,
                    "SubItems": []
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<NavigationMenuItemDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("Home", descriptor.InitialModule);
            Assert.Equal("Home", descriptor.Text);
            Assert.Equal("home.png", descriptor.Icon);
            Assert.True(descriptor.Active);
            Assert.NotNull(descriptor.SubItems);
        }

        [Fact]
        public void SerializationRoundTripPreservesAllProperties()
        {
            // Arrange
            var subItem = new NavigationMenuItemDescriptor("SubModule", "Sub", "sub.png", false, []);
            var original = new NavigationMenuItemDescriptor(
                initialModule: "Main",
                text: "Main Menu",
                icon: "main.png",
                active: false,
                subItems: [subItem]
            );

            // Act
            string json = JsonSerializer.Serialize(original, SerializationOptions.Default);
            var deserialized = JsonSerializer.Deserialize<NavigationMenuItemDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserialized);
            Assert.Equal(original.InitialModule, deserialized.InitialModule);
            Assert.Equal(original.Text, deserialized.Text);
            Assert.Equal(original.Icon, deserialized.Icon);
            Assert.Equal(original.Active, deserialized.Active);
            Assert.Equal(original.SubItems.Count, deserialized.SubItems.Count);
        }

        [Fact]
        public void CanDeserializeWithCaseInsensitivePropertyNames()
        {
            // Arrange
            string json = """
                {
                    "initialmodule": "Settings",
                    "text": "Settings",
                    "icon": "settings.png",
                    "active": false,
                    "subitems": []
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<NavigationMenuItemDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("Settings", descriptor.InitialModule);
        }
    }
}
