using System.Text.Json;

namespace LogicBuilder.App.Maui.Forms.Configuration.Tests
{
    public class TextFieldTemplateDescriptorTest
    {
        [Fact]
        public void CanSerializeTextFieldTemplateDescriptor()
        {
            // Arrange
            var descriptor = new TextFieldTemplateDescriptor(
                templateName: "StandardTextField"
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor, SerializationOptions.Default);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(json));
            Assert.Contains("\"TemplateName\"", json);
        }

        [Fact]
        public void CanDeserializeTextFieldTemplateDescriptor()
        {
            // Arrange
            string json = """
                {
                    "TemplateName": "StandardTextField"
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<TextFieldTemplateDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("StandardTextField", descriptor.TemplateName);
        }

        [Fact]
        public void SerializationRoundTripPreservesAllProperties()
        {
            // Arrange
            var original = new TextFieldTemplateDescriptor(
                templateName: "EmailTextField"
            );

            // Act
            string json = JsonSerializer.Serialize(original, SerializationOptions.Default);
            var deserialized = JsonSerializer.Deserialize<TextFieldTemplateDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserialized);
            Assert.Equal(original.TemplateName, deserialized.TemplateName);
        }

        [Fact]
        public void CanDeserializeWithCaseInsensitivePropertyNames()
        {
            // Arrange
            string json = """
                {
                    "templatename": "PasswordTextField"
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<TextFieldTemplateDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("PasswordTextField", descriptor.TemplateName);
        }
    }
}
