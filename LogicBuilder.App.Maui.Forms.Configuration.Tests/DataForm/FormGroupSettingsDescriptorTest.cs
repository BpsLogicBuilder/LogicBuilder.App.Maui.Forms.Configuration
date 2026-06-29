using LogicBuilder.App.Maui.Forms.Configuration.DataForm;
using LogicBuilder.App.Maui.Forms.Configuration.Directives;
using LogicBuilder.App.Maui.Forms.Configuration.Validation;
using System.Collections.Generic;
using System.Text.Json;

namespace LogicBuilder.App.Maui.Forms.Configuration.Tests.DataForm
{
    public class FormGroupSettingsDescriptorTest
    {
        [Fact]
        public void CanSerializeFormGroupSettingsDescriptor()
        {
            // Arrange
            var formGroupTemplate = new FormGroupTemplateDescriptor("PersonFormGroup");
            var descriptor = new FormGroupSettingsDescriptor(
                field: "Person",
                title: "Person Information",
                validFormControlText: "Valid",
                invalidFormControlText: "Invalid",
                placeholder: "Enter person data",
                modelType: "Model.Person",
                formGroupTemplate: formGroupTemplate,
                fieldSettings: [],
                validationMessages: [],
                conditionalDirectives: null,
                headerBindings: null,
                fieldTypeSource: null
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor, SerializationOptions.Default);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(json));
            Assert.Contains("\"Field\"", json);
            Assert.Contains("\"Title\"", json);
            Assert.Contains("\"ValidFormControlText\"", json);
            Assert.Contains("\"InvalidFormControlText\"", json);
            Assert.Contains("\"Placeholder\"", json);
            Assert.Contains("\"ModelType\"", json);
            Assert.Contains("\"FormGroupTemplate\"", json);
            Assert.Contains("\"FieldSettings\"", json);
            Assert.Contains("\"ValidationMessages\"", json);
        }

        [Fact]
        public void CanDeserializeFormGroupSettingsDescriptor()
        {
            // Arrange
            string json = """
                {
                    "Field": "Person",
                    "Title": "Person Information",
                    "ValidFormControlText": "Valid",
                    "InvalidFormControlText": "Invalid",
                    "Placeholder": "Enter person data",
                    "ModelType": "Model.Person",
                    "FormGroupTemplate": {
                        "TemplateName": "PersonFormGroup"
                    },
                    "FieldSettings": [],
                    "ValidationMessages": {},
                    "ConditionalDirectives": null,
                    "HeaderBindings": null,
                    "FieldTypeSource": null
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<FormGroupSettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("Person", descriptor.Field);
            Assert.Equal("Person Information", descriptor.Title);
            Assert.Equal("Valid", descriptor.ValidFormControlText);
            Assert.Equal("Invalid", descriptor.InvalidFormControlText);
            Assert.Equal("Enter person data", descriptor.Placeholder);
            Assert.Equal("Model.Person", descriptor.ModelType);
            Assert.NotNull(descriptor.FormGroupTemplate);
            Assert.Equal("Person Information", descriptor.GroupHeader);
            Assert.False(descriptor.IsHidden);
        }

        [Fact]
        public void SerializationRoundTripPreservesAllProperties()
        {
            // Arrange
            var formGroupTemplate = new FormGroupTemplateDescriptor("CustomerFormGroup");
            var original = new FormGroupSettingsDescriptor(
                field: "Customer",
                title: "Customer Information",
                validFormControlText: "OK",
                invalidFormControlText: "Error",
                placeholder: "Enter customer data",
                modelType: "Model.Customer",
                formGroupTemplate: formGroupTemplate,
                fieldSettings: [],
                validationMessages: [],
                conditionalDirectives: null,
                headerBindings: null,
                fieldTypeSource: "CustomerType"
            );

            // Act
            string json = JsonSerializer.Serialize(original, SerializationOptions.Default);
            var deserialized = JsonSerializer.Deserialize<FormGroupSettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserialized);
            Assert.Equal(original.Field, deserialized.Field);
            Assert.Equal(original.Title, deserialized.Title);
            Assert.Equal(original.ValidFormControlText, deserialized.ValidFormControlText);
            Assert.Equal(original.InvalidFormControlText, deserialized.InvalidFormControlText);
            Assert.Equal(original.Placeholder, deserialized.Placeholder);
            Assert.Equal(original.ModelType, deserialized.ModelType);
            Assert.Equal(original.FieldTypeSource, deserialized.FieldTypeSource);
            Assert.Equal(original.GroupHeader, deserialized.GroupHeader);
            Assert.Equal(original.IsHidden, deserialized.IsHidden);
        }

        [Fact]
        public void CanDeserializeWithCaseInsensitivePropertyNames()
        {
            // Arrange
            string json = """
                {
                    "field": "Product",
                    "title": "Product Information",
                    "validformcontroltext": "Valid",
                    "invalidformcontroltext": "Invalid",
                    "placeholder": "Enter product data",
                    "modeltype": "Model.Product",
                    "formgrouptemplate": {
                        "templatename": "ProductFormGroup"
                    },
                    "fieldsettings": [],
                    "validationmessages": {}
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<FormGroupSettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("Product", descriptor.Field);
            Assert.Equal("Product Information", descriptor.Title);
        }
    }
}
