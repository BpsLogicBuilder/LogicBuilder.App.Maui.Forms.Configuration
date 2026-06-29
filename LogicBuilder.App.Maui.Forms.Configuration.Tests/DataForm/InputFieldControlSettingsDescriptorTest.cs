using LogicBuilder.App.Maui.Forms.Configuration.DataForm;
using LogicBuilder.App.Maui.Forms.Configuration.Validation;
using System.Text.Json;

namespace LogicBuilder.App.Maui.Forms.Configuration.Tests.DataForm
{
    public class InputFieldControlSettingsDescriptorTest
    {
        [Fact]
        public void CanSerializeInputFieldControlSettingsDescriptor()
        {
            // Arrange
            var textTemplate = new TextFieldTemplateDescriptor("StandardTextField");
            var descriptor = new InputFieldControlSettingsDescriptor(
                field: "Name",
                title: "Name",
                placeholder: "Enter name",
                stringFormat: "{0}",
                type: "string",
                textTemplate: textTemplate,
                updateOnlyTextTemplate: null,
                validationSetting: null,
                fieldTypeSource: null
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor, SerializationOptions.Default);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(json));
            Assert.Contains("\"Field\"", json);
            Assert.Contains("\"Title\"", json);
            Assert.Contains("\"Placeholder\"", json);
            Assert.Contains("\"StringFormat\"", json);
            Assert.Contains("\"Type\"", json);
            Assert.Contains("\"TextTemplate\"", json);
        }

        [Fact]
        public void CanDeserializeInputFieldControlSettingsDescriptor()
        {
            // Arrange
            string json = """
                {
                    "Field": "Name",
                    "Title": "Name",
                    "Placeholder": "Enter name",
                    "StringFormat": "{0}",
                    "Type": "string",
                    "TextTemplate": {
                        "TemplateName": "StandardTextField"
                    },
                    "UpdateOnlyTextTemplate": null,
                    "ValidationSetting": null,
                    "FieldTypeSource": null
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<InputFieldControlSettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("Name", descriptor.Field);
            Assert.Equal("Name", descriptor.Title);
            Assert.Equal("Enter name", descriptor.Placeholder);
            Assert.Equal("{0}", descriptor.StringFormat);
            Assert.Equal("string", descriptor.Type);
            Assert.NotNull(descriptor.TextTemplate);
        }

        [Fact]
        public void SerializationRoundTripPreservesAllProperties()
        {
            // Arrange
            var textTemplate = new TextFieldTemplateDescriptor("EmailTextField");
            var updateTemplate = new TextFieldTemplateDescriptor("ReadOnlyTextField");
            var original = new InputFieldControlSettingsDescriptor(
                field: "Email",
                title: "Email Address",
                placeholder: "Enter email",
                stringFormat: "{0}",
                type: "string",
                textTemplate: textTemplate,
                updateOnlyTextTemplate: updateTemplate,
                validationSetting: null,
                fieldTypeSource: "StringType"
            );

            // Act
            string json = JsonSerializer.Serialize(original, SerializationOptions.Default);
            var deserialized = JsonSerializer.Deserialize<InputFieldControlSettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserialized);
            Assert.Equal(original.Field, deserialized.Field);
            Assert.Equal(original.Title, deserialized.Title);
            Assert.Equal(original.Placeholder, deserialized.Placeholder);
            Assert.Equal(original.StringFormat, deserialized.StringFormat);
            Assert.Equal(original.Type, deserialized.Type);
            Assert.Equal(original.FieldTypeSource, deserialized.FieldTypeSource);
        }

        [Fact]
        public void CanDeserializeWithCaseInsensitivePropertyNames()
        {
            // Arrange
            string json = """
                {
                    "field": "Phone",
                    "title": "Phone Number",
                    "placeholder": "Enter phone",
                    "stringformat": "{0}",
                    "type": "string",
                    "texttemplate": {
                        "templatename": "PhoneTextField"
                    }
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<InputFieldControlSettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("Phone", descriptor.Field);
            Assert.Equal("Phone Number", descriptor.Title);
        }
    }
}
