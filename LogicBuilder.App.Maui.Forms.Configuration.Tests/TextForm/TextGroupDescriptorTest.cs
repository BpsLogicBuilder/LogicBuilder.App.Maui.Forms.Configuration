using LogicBuilder.App.Maui.Forms.Configuration.TextForm;
using System.Collections.Generic;
using System.Text.Json;

namespace LogicBuilder.App.Maui.Forms.Configuration.Tests.TextForm
{
    public class TextGroupDescriptorTest
    {
        [Fact]
        public void CanSerializeTextGroupDescriptor()
        {
            // Arrange
            var label = new LabelItemDescriptor("Hello World");
            var descriptor = new TextGroupDescriptor(
                title: "Introduction",
                labels: [label]
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor, SerializationOptions.Default);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(json));
            Assert.Contains("\"Title\"", json);
            Assert.Contains("\"Labels\"", json);
        }

        [Fact]
        public void CanDeserializeTextGroupDescriptor()
        {
            // Arrange
            string json = """
                {
                    "Title": "Introduction",
                    "Labels": [
                        {
                            "TypeString": "LogicBuilder.App.Maui.Forms.Configuration.TextForm.LabelItemDescriptor, LogicBuilder.App.Maui.Forms.Configuration",
                            "Text": "Hello World"
                        }
                    ]
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<TextGroupDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("Introduction", descriptor.Title);
            Assert.NotNull(descriptor.Labels);
            Assert.Single(descriptor.Labels);
        }

        [Fact]
        public void SerializationRoundTripPreservesAllProperties()
        {
            // Arrange
            var label1 = new LabelItemDescriptor("First paragraph");
            var label2 = new LabelItemDescriptor("Second paragraph");
            var original = new TextGroupDescriptor(
                title: "Content",
                labels: [label1, label2]
            );

            // Act
            string json = JsonSerializer.Serialize(original, SerializationOptions.Default);
            var deserialized = JsonSerializer.Deserialize<TextGroupDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserialized);
            Assert.Equal(original.Title, deserialized.Title);
            Assert.Equal(original.Labels.Count, deserialized.Labels.Count);
        }

        [Fact]
        public void CanDeserializeWithCaseInsensitivePropertyNames()
        {
            // Arrange
            string json = """
                {
                    "title": "Summary",
                    "labels": []
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<TextGroupDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("Summary", descriptor.Title);
            Assert.NotNull(descriptor.Labels);
        }
    }
}
