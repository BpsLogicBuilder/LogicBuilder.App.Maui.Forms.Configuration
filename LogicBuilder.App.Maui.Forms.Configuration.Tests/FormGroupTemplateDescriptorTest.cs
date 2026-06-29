using System.Text.Json;

namespace LogicBuilder.App.Maui.Forms.Configuration.Tests
{
    public class FormGroupTemplateDescriptorTest
    {
        [Fact]
        public void CanSerializeFormGroupTemplateDescriptor()
        {
            // Arrange
            var descriptor = new FormGroupTemplateDescriptor(
                templateName: "PersonFormGroup"
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor, SerializationOptions.Default);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(json));
            Assert.Contains("\"TemplateName\"", json);
        }

        [Fact]
        public void CanDeserializeFormGroupTemplateDescriptor()
        {
            // Arrange
            string json = """
                {
                    "TemplateName": "PersonFormGroup"
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<FormGroupTemplateDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("PersonFormGroup", descriptor.TemplateName);
        }

        [Fact]
        public void SerializationRoundTripPreservesAllProperties()
        {
            // Arrange
            var original = new FormGroupTemplateDescriptor(
                templateName: "CustomerFormGroup"
            );

            // Act
            string json = JsonSerializer.Serialize(original, SerializationOptions.Default);
            var deserialized = JsonSerializer.Deserialize<FormGroupTemplateDescriptor>(json, SerializationOptions.Default);

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
                    "templatename": "ProductFormGroup"
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<FormGroupTemplateDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("ProductFormGroup", descriptor.TemplateName);
        }
    }
}
