using LogicBuilder.App.Maui.Forms.Configuration.TextForm;
using System.Text.Json;

namespace LogicBuilder.App.Maui.Forms.Configuration.Tests.TextForm
{
    public class SpanItemDescriptorTest
    {
        [Fact]
        public void CanSerializeSpanItemDescriptor()
        {
            // Arrange
            var descriptor = new SpanItemDescriptor(
                text: "Bold text"
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor, SerializationOptions.Default);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(json));
            Assert.Contains("\"Text\"", json);
        }

        [Fact]
        public void CanDeserializeSpanItemDescriptor()
        {
            // Arrange
            string json = """
                {
                    "TypeString": "LogicBuilder.App.Maui.Forms.Configuration.TextForm.SpanItemDescriptor, LogicBuilder.App.Maui.Forms.Configuration",
                    "Text": "Bold text"
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<SpanItemDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("Bold text", descriptor.Text);
        }

        [Fact]
        public void SerializationRoundTripPreservesAllProperties()
        {
            // Arrange
            var original = new SpanItemDescriptor(
                text: "Italic text"
            );

            // Act
            string json = JsonSerializer.Serialize(original, SerializationOptions.Default);
            var deserialized = JsonSerializer.Deserialize<SpanItemDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserialized);
            Assert.Equal(original.Text, deserialized.Text);
        }

        [Fact]
        public void CanDeserializeWithCaseInsensitivePropertyNames()
        {
            // Arrange
            string json = """
                {
                    "text": "Underlined text"
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<SpanItemDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("Underlined text", descriptor.Text);
        }
    }
}
