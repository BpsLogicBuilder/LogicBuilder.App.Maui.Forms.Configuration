using LogicBuilder.App.Maui.Forms.Configuration.TextForm;
using System.Collections.Generic;
using System.Text.Json;

namespace LogicBuilder.App.Maui.Forms.Configuration.Tests.TextForm
{
    public class TextFormSettingsDescriptorTest
    {
        [Fact]
        public void CanSerializeTextFormSettingsDescriptor()
        {
            // Arrange
            var label = new LabelItemDescriptor("Welcome");
            var textGroup = new TextGroupDescriptor("Introduction", [label]);
            var descriptor = new TextFormSettingsDescriptor(
                title: "Welcome Page",
                textGroups: [textGroup]
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor, SerializationOptions.Default);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(json));
            Assert.Contains("\"Title\"", json);
            Assert.Contains("\"TextGroups\"", json);
        }

        [Fact]
        public void CanDeserializeTextFormSettingsDescriptor()
        {
            // Arrange
            string json = """
                {
                    "Title": "Welcome Page",
                    "TextGroups": [
                        {
                            "Title": "Introduction",
                            "Labels": [
                                {
                                    "TypeString": "LogicBuilder.App.Maui.Forms.Configuration.TextForm.LabelItemDescriptor, LogicBuilder.App.Maui.Forms.Configuration",
                                    "Text": "Welcome"
                                }
                            ]
                        }
                    ]
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<TextFormSettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("Welcome Page", descriptor.Title);
            Assert.NotNull(descriptor.TextGroups);
            Assert.Single(descriptor.TextGroups);
        }

        [Fact]
        public void SerializationRoundTripPreservesAllProperties()
        {
            // Arrange
            var label = new LabelItemDescriptor("Content");
            var textGroup = new TextGroupDescriptor("Section 1", [label]);
            var original = new TextFormSettingsDescriptor(
                title: "Information Page",
                textGroups: [textGroup]
            );

            // Act
            string json = JsonSerializer.Serialize(original, SerializationOptions.Default);
            var deserialized = JsonSerializer.Deserialize<TextFormSettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserialized);
            Assert.Equal(original.Title, deserialized.Title);
            Assert.Equal(original.TextGroups.Count, deserialized.TextGroups.Count);
        }

        [Fact]
        public void CanDeserializeWithCaseInsensitivePropertyNames()
        {
            // Arrange
            string json = """
                {
                    "title": "About Page",
                    "textgroups": []
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<TextFormSettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("About Page", descriptor.Title);
            Assert.NotNull(descriptor.TextGroups);
        }
    }
}
