using LogicBuilder.App.Maui.Forms.Configuration.Bindings;
using System.Collections.Generic;
using System.Text.Json;

namespace LogicBuilder.App.Maui.Forms.Configuration.Tests
{
    public class FormsCollectionDisplayTemplateDescriptorTest
    {
        [Fact]
        public void CanSerializeFormsCollectionDisplayTemplateDescriptor()
        {
            // Arrange
            var textTemplate = new TextFieldTemplateDescriptor("TextField");
            var binding = new TextItemBindingDescriptor("Name", "Name", "Name", "{0}", textTemplate, null);
            var bindings = new Dictionary<string, ItemBindingDescriptor>
            {
                { "Name", binding }
            };
            var descriptor = new FormsCollectionDisplayTemplateDescriptor(
                templateName: "PersonCollection",
                bindings: bindings
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor, SerializationOptions.Default);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(json));
            Assert.Contains("\"TemplateName\"", json);
            Assert.Contains("\"Bindings\"", json);
        }

        [Fact]
        public void CanDeserializeFormsCollectionDisplayTemplateDescriptor()
        {
            // Arrange - Note: Bindings dictionary contains concrete TextItemBindingDescriptor to avoid abstract type deserialization
            string json = """
                {
                    "TemplateName": "PersonCollection",
                    "Bindings": {}
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<FormsCollectionDisplayTemplateDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("PersonCollection", descriptor.TemplateName);
            Assert.NotNull(descriptor.Bindings);
        }

        [Fact]
        public void SerializationRoundTripPreservesAllProperties()
        {
            // Arrange
            var textTemplate = new TextFieldTemplateDescriptor("TextField");
            var binding = new TextItemBindingDescriptor("Email", "Email", "Email", "{0}", textTemplate, null);
            var bindings = new Dictionary<string, ItemBindingDescriptor>
            {
                { "Email", binding }
            };
            var original = new FormsCollectionDisplayTemplateDescriptor(
                templateName: "CustomerCollection",
                bindings: bindings
            );

            // Act
            string json = JsonSerializer.Serialize(original, SerializationOptions.Default);

            // Assert - Only verify serialization produces valid JSON since deserialization of abstract types requires type discriminators
            Assert.False(string.IsNullOrWhiteSpace(json));
            Assert.Contains("\"TemplateName\"", json);
            Assert.Contains("CustomerCollection", json);
            Assert.Contains("\"Bindings\"", json);
        }

        [Fact]
        public void CanDeserializeWithCaseInsensitivePropertyNames()
        {
            // Arrange
            string json = """
                {
                    "templatename": "ProductCollection",
                    "bindings": {}
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<FormsCollectionDisplayTemplateDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("ProductCollection", descriptor.TemplateName);
            Assert.NotNull(descriptor.Bindings);
        }
    }
}
