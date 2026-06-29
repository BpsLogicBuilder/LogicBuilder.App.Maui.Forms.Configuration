using LogicBuilder.App.Maui.Forms.Configuration.Bindings;
using LogicBuilder.App.Maui.Forms.Configuration.DataForm;
using LogicBuilder.App.Maui.Forms.Configuration.Directives;
using LogicBuilder.App.Maui.Forms.Configuration.Validation;
using System.Collections.Generic;
using System.Text.Json;

namespace LogicBuilder.App.Maui.Forms.Configuration.Tests.DataForm
{
    public class FormGroupArraySettingsDescriptorTest
    {
        [Fact]
        public void CanSerializeFormGroupArraySettingsDescriptor()
        {
            // Arrange
            var formGroupTemplate = new FormGroupTemplateDescriptor("PersonFormGroup");
            var displayTemplate = new FormsCollectionDisplayTemplateDescriptor("PersonDisplay", []);
            var descriptor = new FormGroupArraySettingsDescriptor(
                field: "People",
                title: "People List",
                placeholder: "Add people",
                modelType: "Model.Person",
                type: "List<Model.Person>",
                validFormControlText: "Valid",
                invalidFormControlText: "Invalid",
                keyFields: ["Id"],
                formsCollectionDisplayTemplate: displayTemplate,
                formGroupTemplate: formGroupTemplate,
                fieldSettings: [],
                validationMessages: [],
                conditionalDirectives: null,
                headerBindings: null,
                fieldTypeSource: null,
                listElementTypeSource: null
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor, SerializationOptions.Default);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(json));
            Assert.Contains("\"Field\"", json);
            Assert.Contains("\"Title\"", json);
            Assert.Contains("\"Placeholder\"", json);
            Assert.Contains("\"ModelType\"", json);
            Assert.Contains("\"Type\"", json);
            Assert.Contains("\"KeyFields\"", json);
            Assert.Contains("\"FormsCollectionDisplayTemplate\"", json);
            Assert.Contains("\"FormGroupTemplate\"", json);
        }

        [Fact]
        public void CanDeserializeFormGroupArraySettingsDescriptor()
        {
            // Arrange
            string json = """
                {
                    "Field": "People",
                    "Title": "People List",
                    "Placeholder": "Add people",
                    "ModelType": "Model.Person",
                    "Type": "List<Model.Person>",
                    "ValidFormControlText": "Valid",
                    "InvalidFormControlText": "Invalid",
                    "KeyFields": ["Id"],
                    "FormsCollectionDisplayTemplate": {
                        "TemplateName": "PersonDisplay",
                        "Bindings": {}
                    },
                    "FormGroupTemplate": {
                        "TemplateName": "PersonFormGroup"
                    },
                    "FieldSettings": [],
                    "ValidationMessages": {},
                    "ConditionalDirectives": null,
                    "HeaderBindings": null,
                    "FieldTypeSource": null,
                    "ListElementTypeSource": null
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<FormGroupArraySettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("People", descriptor.Field);
            Assert.Equal("People List", descriptor.Title);
            Assert.Equal("Add people", descriptor.Placeholder);
            Assert.Equal("Model.Person", descriptor.ModelType);
            Assert.Equal("List<Model.Person>", descriptor.Type);
            Assert.NotNull(descriptor.KeyFields);
            Assert.Single(descriptor.KeyFields);
            Assert.Equal("People List", descriptor.GroupHeader);
            Assert.False(descriptor.IsHidden);
        }

        [Fact]
        public void SerializationRoundTripPreservesAllProperties()
        {
            // Arrange
            var formGroupTemplate = new FormGroupTemplateDescriptor("OrderFormGroup");
            var displayTemplate = new FormsCollectionDisplayTemplateDescriptor("OrderDisplay", []);
            var original = new FormGroupArraySettingsDescriptor(
                field: "Orders",
                title: "Orders List",
                placeholder: "Add orders",
                modelType: "Model.Order",
                type: "List<Model.Order>",
                validFormControlText: "Valid",
                invalidFormControlText: "Invalid",
                keyFields: ["OrderId", "OrderNumber"],
                formsCollectionDisplayTemplate: displayTemplate,
                formGroupTemplate: formGroupTemplate,
                fieldSettings: [],
                validationMessages: [],
                conditionalDirectives: null,
                headerBindings: null,
                fieldTypeSource: "OrderListType",
                listElementTypeSource: "OrderType"
            );

            // Act
            string json = JsonSerializer.Serialize(original, SerializationOptions.Default);
            var deserialized = JsonSerializer.Deserialize<FormGroupArraySettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserialized);
            Assert.Equal(original.Field, deserialized.Field);
            Assert.Equal(original.Title, deserialized.Title);
            Assert.Equal(original.Placeholder, deserialized.Placeholder);
            Assert.Equal(original.ModelType, deserialized.ModelType);
            Assert.Equal(original.Type, deserialized.Type);
            Assert.Equal(original.KeyFields.Count, deserialized.KeyFields.Count);
            Assert.Equal(original.FieldTypeSource, deserialized.FieldTypeSource);
            Assert.Equal(original.ListElementTypeSource, deserialized.ListElementTypeSource);
            Assert.Equal(original.GroupHeader, deserialized.GroupHeader);
            Assert.Equal(original.IsHidden, deserialized.IsHidden);
        }

        [Fact]
        public void CanDeserializeWithCaseInsensitivePropertyNames()
        {
            // Arrange
            string json = """
                {
                    "field": "Items",
                    "title": "Items List",
                    "placeholder": "Add items",
                    "modeltype": "Model.Item",
                    "type": "List<Model.Item>",
                    "validformcontroltext": "Valid",
                    "invalidformcontroltext": "Invalid",
                    "keyfields": ["ItemId"],
                    "formscollectiondisplaytemplate": {
                        "templatename": "ItemDisplay",
                        "bindings": {}
                    },
                    "formgrouptemplate": {
                        "templatename": "ItemFormGroup"
                    },
                    "fieldsettings": [],
                    "validationmessages": {}
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<FormGroupArraySettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("Items", descriptor.Field);
            Assert.Equal("Items List", descriptor.Title);
        }
    }
}
