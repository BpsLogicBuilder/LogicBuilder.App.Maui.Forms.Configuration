using LogicBuilder.App.Maui.Forms.Configuration.Bindings;
using System.Text.Json;

namespace LogicBuilder.App.Maui.Forms.Configuration.Tests.Bindings
{
    public class TextItemBindingDescriptorTest
    {
        [Fact]
        public void CanSerializeTextItemBindingDescriptor()
        {
            // Arrange
            var textTemplate = new TextFieldTemplateDescriptor("StandardTextField");
            var descriptor = new TextItemBindingDescriptor(
                name: "Name",
                property: "FullName",
                title: "Full Name",
                stringFormat: "{0}",
                textTemplate: textTemplate,
                fieldTypeSource: null
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor, SerializationOptions.Default);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(json));
            Assert.Contains("\"Name\"", json);
            Assert.Contains("\"Property\"", json);
            Assert.Contains("\"Title\"", json);
            Assert.Contains("\"StringFormat\"", json);
            Assert.Contains("\"TextTemplate\"", json);
        }

        [Fact]
        public void CanDeserializeTextItemBindingDescriptor()
        {
            // Arrange
            string json = """
                {
                    "Name": "Name",
                    "Property": "FullName",
                    "Title": "Full Name",
                    "StringFormat": "{0}",
                    "TextTemplate": {
                        "TemplateName": "StandardTextField"
                    },
                    "FieldTypeSource": null
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<TextItemBindingDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("Name", descriptor.Name);
            Assert.Equal("FullName", descriptor.Property);
            Assert.Equal("Full Name", descriptor.Title);
            Assert.Equal("{0}", descriptor.StringFormat);
            Assert.NotNull(descriptor.TextTemplate);
            Assert.Equal("StandardTextField", descriptor.TextTemplate.TemplateName);
            Assert.Equal("StandardTextField", descriptor.TemplateName);
        }

        [Fact]
        public void SerializationRoundTripPreservesAllProperties()
        {
            // Arrange
            var textTemplate = new TextFieldTemplateDescriptor("EmailTextField");
            var original = new TextItemBindingDescriptor(
                name: "Email",
                property: "EmailAddress",
                title: "Email Address",
                stringFormat: "{0}",
                textTemplate: textTemplate,
                fieldTypeSource: "StringType"
            );

            // Act
            string json = JsonSerializer.Serialize(original, SerializationOptions.Default);
            var deserialized = JsonSerializer.Deserialize<TextItemBindingDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserialized);
            Assert.Equal(original.Name, deserialized.Name);
            Assert.Equal(original.Property, deserialized.Property);
            Assert.Equal(original.Title, deserialized.Title);
            Assert.Equal(original.StringFormat, deserialized.StringFormat);
            Assert.Equal(original.FieldTypeSource, deserialized.FieldTypeSource);
            Assert.Equal(original.TemplateName, deserialized.TemplateName);
        }

        [Fact]
        public void CanDeserializeWithCaseInsensitivePropertyNames()
        {
            // Arrange
            string json = """
                {
                    "name": "Phone",
                    "property": "PhoneNumber",
                    "title": "Phone Number",
                    "stringformat": "{0}",
                    "texttemplate": {
                        "templatename": "PhoneTextField"
                    }
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<TextItemBindingDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("Phone", descriptor.Name);
            Assert.Equal("PhoneNumber", descriptor.Property);
        }
    }
}
