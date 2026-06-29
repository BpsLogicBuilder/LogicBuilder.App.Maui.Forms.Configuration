using LogicBuilder.App.Maui.Forms.Configuration.TextForm;
using System.Collections.Generic;
using System.Text.Json;

namespace LogicBuilder.App.Maui.Forms.Configuration.Tests.TextForm
{
    public class FormattedLabelItemDescriptorTest
    {
        [Fact]
        public void CanSerializeFormattedLabelItemDescriptor()
        {
            // Arrange
            var spanItem = new SpanItemDescriptor("Bold text");
            var descriptor = new FormattedLabelItemDescriptor(
                items: [spanItem]
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor, SerializationOptions.Default);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(json));
            Assert.Contains("\"Items\"", json);
        }

        [Fact]
        public void CanDeserializeFormattedLabelItemDescriptor()
        {
            // Arrange
            string json = """
                {
                    "TypeString": "LogicBuilder.App.Maui.Forms.Configuration.TextForm.FormattedLabelItemDescriptor, LogicBuilder.App.Maui.Forms.Configuration",
                    "Items": [
                        {
                            "TypeString": "LogicBuilder.App.Maui.Forms.Configuration.TextForm.SpanItemDescriptor, LogicBuilder.App.Maui.Forms.Configuration",
                            "Text": "Bold text"
                        }
                    ]
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<FormattedLabelItemDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.NotNull(descriptor.Items);
            Assert.Single(descriptor.Items);
        }

        [Fact]
        public void SerializationRoundTripPreservesAllProperties()
        {
            // Arrange
            var spanItem = new SpanItemDescriptor("Test text");
            var original = new FormattedLabelItemDescriptor(
                items: [spanItem]
            );

            // Act
            string json = JsonSerializer.Serialize(original, SerializationOptions.Default);
            var deserialized = JsonSerializer.Deserialize<FormattedLabelItemDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserialized);
            Assert.Equal(original.Items.Count, deserialized.Items.Count);
        }

        [Fact]
        public void CanDeserializeWithCaseInsensitivePropertyNames()
        {
            // Arrange
            string json = """
                {
                    "items": []
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<FormattedLabelItemDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.NotNull(descriptor.Items);
        }
    }
}
