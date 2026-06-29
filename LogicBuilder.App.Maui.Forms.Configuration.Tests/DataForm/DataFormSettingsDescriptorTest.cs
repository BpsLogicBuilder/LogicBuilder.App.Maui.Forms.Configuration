using LogicBuilder.App.Maui.Forms.Configuration.DataForm;
using LogicBuilder.App.Maui.Forms.Configuration.Directives;
using LogicBuilder.App.Maui.Forms.Configuration.Validation;
using System.Collections.Generic;
using System.Text.Json;

namespace LogicBuilder.App.Maui.Forms.Configuration.Tests.DataForm
{
    public class DataFormSettingsDescriptorTest
    {
        [Fact]
        public void CanSerializeDataFormSettingsDescriptor()
        {
            // Arrange
            var descriptor = new DataFormSettingsDescriptor(
                title: "Person Form",
                validationMessages: [],
                fieldSettings: [],
                formType: FormType.Add,
                modelType: "Model.Person",
                headerBindings: null,
                requestDetails: null,
                conditionalDirectives: null,
                subtitleBindings: null
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor, SerializationOptions.Default);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(json));
            Assert.Contains("\"Title\"", json);
            Assert.Contains("\"ValidationMessages\"", json);
            Assert.Contains("\"FieldSettings\"", json);
            Assert.Contains("\"FormType\"", json);
            Assert.Contains("\"ModelType\"", json);
        }

        [Fact]
        public void CanDeserializeDataFormSettingsDescriptor()
        {
            // Arrange
            string json = """
                {
                    "Title": "Person Form",
                    "ValidationMessages": {},
                    "FieldSettings": [],
                    "FormType": 0,
                    "ModelType": "Model.Person",
                    "HeaderBindings": null,
                    "RequestDetails": null,
                    "ConditionalDirectives": null,
                    "SubtitleBindings": null
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<DataFormSettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("Person Form", descriptor.Title);
            Assert.NotNull(descriptor.ValidationMessages);
            Assert.NotNull(descriptor.FieldSettings);
            Assert.Equal(FormType.Add, descriptor.FormType);
            Assert.Equal("Model.Person", descriptor.ModelType);
            Assert.Equal("Person Form", descriptor.GroupHeader);
            Assert.False(descriptor.IsHidden);
        }

        [Fact]
        public void SerializationRoundTripPreservesAllProperties()
        {
            // Arrange
            var validationRule = new ValidationRuleDescriptor("RequiredRule", "Field is required");
            var validationMessages = new Dictionary<string, List<ValidationRuleDescriptor>>
            {
                { "Name", new List<ValidationRuleDescriptor> { validationRule } }
            };
            var original = new DataFormSettingsDescriptor(
                title: "Customer Form",
                validationMessages: validationMessages,
                fieldSettings: [],
                formType: FormType.Update,
                modelType: "Model.Customer",
                headerBindings: null,
                requestDetails: null,
                conditionalDirectives: null,
                subtitleBindings: null
            );

            // Act
            string json = JsonSerializer.Serialize(original, SerializationOptions.Default);
            var deserialized = JsonSerializer.Deserialize<DataFormSettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserialized);
            Assert.Equal(original.Title, deserialized.Title);
            Assert.Equal(original.FormType, deserialized.FormType);
            Assert.Equal(original.ModelType, deserialized.ModelType);
            Assert.Equal(original.GroupHeader, deserialized.GroupHeader);
            Assert.Equal(original.IsHidden, deserialized.IsHidden);
        }

        [Fact]
        public void CanDeserializeWithCaseInsensitivePropertyNames()
        {
            // Arrange
            string json = """
                {
                    "title": "Product Form",
                    "validationmessages": {},
                    "fieldsettings": [],
                    "formtype": 2,
                    "modeltype": "Model.Product"
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<DataFormSettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("Product Form", descriptor.Title);
            Assert.Equal(FormType.Delete, descriptor.FormType);
        }
    }
}
