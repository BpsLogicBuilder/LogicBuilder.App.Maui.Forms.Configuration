using LogicBuilder.App.Maui.Forms.Configuration.TextForm;
using System.Text.Json;

namespace LogicBuilder.App.Maui.Forms.Configuration.Tests.TextForm
{
    public class LabelItemDescriptorTest
    {
        [Fact]
        public void CanSerializeLabelItemDescriptor()
        {
            // Arrange
            var descriptor = new LabelItemDescriptor(
                text: "Hello World"
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor, SerializationOptions.Default);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(json));
            Assert.Contains("\"Text\"", json);
        }

        [Fact]
        public void CanDeserializeLabelItemDescriptor()
        {
            // Arrange
            string json = """
                {
                    "TypeString": "LogicBuilder.App.Maui.Forms.Configuration.TextForm.LabelItemDescriptor, LogicBuilder.App.Maui.Forms.Configuration",
                    "Text": "Hello World"
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<LabelItemDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("Hello World", descriptor.Text);
        }

        [Fact]
        public void SerializationRoundTripPreservesAllProperties()
        {
            // Arrange
            var original = new LabelItemDescriptor(
                text: "Test Label"
            );

            // Act
            string json = JsonSerializer.Serialize(original, SerializationOptions.Default);
            var deserialized = JsonSerializer.Deserialize<LabelItemDescriptor>(json, SerializationOptions.Default);

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
                    "text": "Case Insensitive"
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<LabelItemDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("Case Insensitive", descriptor.Text);
        }
    }
}
