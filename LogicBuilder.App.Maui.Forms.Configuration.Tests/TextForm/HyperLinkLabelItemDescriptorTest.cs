using LogicBuilder.App.Maui.Forms.Configuration.TextForm;
using System.Text.Json;

namespace LogicBuilder.App.Maui.Forms.Configuration.Tests.TextForm
{
    public class HyperLinkLabelItemDescriptorTest
    {
        [Fact]
        public void CanSerializeHyperLinkLabelItemDescriptor()
        {
            // Arrange
            var descriptor = new HyperLinkLabelItemDescriptor(
                text: "Click here",
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
        public void CanDeserializeHyperLinkLabelItemDescriptor()
        {
            // Arrange
            string json = """
                {
                    "TypeString": "LogicBuilder.App.Maui.Forms.Configuration.TextForm.HyperLinkLabelItemDescriptor, LogicBuilder.App.Maui.Forms.Configuration",
                    "Text": "Click here",
                    "Url": "https://example.com"
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<HyperLinkLabelItemDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("Click here", descriptor.Text);
            Assert.Equal("https://example.com", descriptor.Url);
        }

        [Fact]
        public void SerializationRoundTripPreservesAllProperties()
        {
            // Arrange
            var original = new HyperLinkLabelItemDescriptor(
                text: "Visit our site",
                url: "https://test.com"
            );

            // Act
            string json = JsonSerializer.Serialize(original, SerializationOptions.Default);
            var deserialized = JsonSerializer.Deserialize<HyperLinkLabelItemDescriptor>(json, SerializationOptions.Default);

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
                    "text": "Learn more",
                    "url": "https://docs.example.com"
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<HyperLinkLabelItemDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("Learn more", descriptor.Text);
            Assert.Equal("https://docs.example.com", descriptor.Url);
        }
    }
}
