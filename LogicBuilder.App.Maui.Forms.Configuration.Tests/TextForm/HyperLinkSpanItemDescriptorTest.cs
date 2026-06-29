using LogicBuilder.App.Maui.Forms.Configuration.TextForm;
using System.Text.Json;

namespace LogicBuilder.App.Maui.Forms.Configuration.Tests.TextForm
{
    public class HyperLinkSpanItemDescriptorTest
    {
        [Fact]
        public void CanSerializeHyperLinkSpanItemDescriptor()
        {
            // Arrange
            var descriptor = new HyperLinkSpanItemDescriptor(
                text: "Link text",
                url: "https://example.com"
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor, SerializationOptions.Default);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(json));
            Assert.Contains("\"Text\"", json);
            Assert.Contains("\"Url\"", json);
        }

        [Fact]
        public void CanDeserializeHyperLinkSpanItemDescriptor()
        {
            // Arrange
            string json = """
                {
                    "TypeString": "LogicBuilder.App.Maui.Forms.Configuration.TextForm.HyperLinkSpanItemDescriptor, LogicBuilder.App.Maui.Forms.Configuration",
                    "Text": "Link text",
                    "Url": "https://example.com"
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<HyperLinkSpanItemDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("Link text", descriptor.Text);
            Assert.Equal("https://example.com", descriptor.Url);
        }

        [Fact]
        public void SerializationRoundTripPreservesAllProperties()
        {
            // Arrange
            var original = new HyperLinkSpanItemDescriptor(
                text: "Documentation",
                url: "https://docs.example.com"
            );

            // Act
            string json = JsonSerializer.Serialize(original, SerializationOptions.Default);
            var deserialized = JsonSerializer.Deserialize<HyperLinkSpanItemDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserialized);
            Assert.Equal(original.Text, deserialized.Text);
            Assert.Equal(original.Url, deserialized.Url);
        }

        [Fact]
        public void CanDeserializeWithCaseInsensitivePropertyNames()
        {
            // Arrange
            string json = """
                {
                    "text": "Help",
                    "url": "https://help.example.com"
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<HyperLinkSpanItemDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("Help", descriptor.Text);
            Assert.Equal("https://help.example.com", descriptor.Url);
        }
    }
}
