using LogicBuilder.App.Maui.Forms.Configuration.DataForm;
using LogicBuilder.App.Maui.Forms.Configuration.Validation;
using System.Collections.Generic;
using System.Text.Json;

namespace LogicBuilder.App.Maui.Forms.Configuration.Tests.DataForm
{
    public class MultiSelectFormControlSettingsDescriptorTest
    {
        [Fact]
        public void CanSerializeMultiSelectFormControlSettingsDescriptor()
        {
            // Arrange
            var requestDetails = new RequestDetailsDescriptor(
                "Model.Tag", "Data.TagData", "Model.TagResponse",
                "Data.TagDataResponse", "/api/tags"
            );
            var multiSelectTemplate = new MultiSelectTemplateDescriptor(
                "TagMultiSelect", "Select tags", "Name", "Id", "Model.Tag",
                "Loading...", null!, requestDetails, null
            );
            var descriptor = new MultiSelectFormControlSettingsDescriptor(
                field: "TagIds",
                keyFields: ["Id"],
                title: "Tags",
                placeholder: "Select tags",
                stringFormat: "{0}",
                type: "List<int>",
                multiSelectTemplate: multiSelectTemplate,
                validationSetting: null,
                fieldTypeSource: null,
                listElementTypeSource: null
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor, SerializationOptions.Default);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(json));
            Assert.Contains("\"Field\"", json);
            Assert.Contains("\"KeyFields\"", json);
            Assert.Contains("\"Title\"", json);
            Assert.Contains("\"MultiSelectTemplate\"", json);
        }

        [Fact]
        public void CanDeserializeMultiSelectFormControlSettingsDescriptor()
        {
            // Arrange
            string json = """
                {
                    "Field": "TagIds",
                    "KeyFields": ["Id"],
                    "Title": "Tags",
                    "Placeholder": "Select tags",
                    "StringFormat": "{0}",
                    "Type": "List<int>",
                    "MultiSelectTemplate": {
                        "TemplateName": "TagMultiSelect",
                        "PlaceholderText": "Select tags",
                        "TextField": "Name",
                        "ValueField": "Id",
                        "ModelType": "Model.Tag",
                        "LoadingIndicatorText": "Loading...",
                        "TextAndValueSelector": null,
                        "RequestDetails": {
                            "ModelType": "Model.Tag",
                            "DataType": "Data.TagData",
                            "ModelReturnType": "Model.TagResponse",
                            "DataReturnType": "Data.TagDataResponse",
                            "DataSourceUrl": "/api/tags"
                        },
                        "FieldTypeSource": null
                    },
                    "ValidationSetting": null,
                    "FieldTypeSource": null,
                    "ListElementTypeSource": null
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<MultiSelectFormControlSettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("TagIds", descriptor.Field);
            Assert.NotNull(descriptor.KeyFields);
            Assert.Single(descriptor.KeyFields);
            Assert.Equal("Tags", descriptor.Title);
            Assert.NotNull(descriptor.MultiSelectTemplate);
        }

        [Fact]
        public void SerializationRoundTripPreservesAllProperties()
        {
            // Arrange
            var requestDetails = new RequestDetailsDescriptor(
                "Model.Category", "Data.CategoryData", "Model.CategoryResponse",
                "Data.CategoryDataResponse", "/api/categories"
            );
            var multiSelectTemplate = new MultiSelectTemplateDescriptor(
                "CategoryMultiSelect", "Select categories", "CategoryName", "CategoryId",
                "Model.Category", "Loading...", null!, requestDetails, "CategoryType"
            );
            var original = new MultiSelectFormControlSettingsDescriptor(
                field: "CategoryIds",
                keyFields: ["CategoryId", "CategoryName"],
                title: "Categories",
                placeholder: "Select categories",
                stringFormat: "{0}",
                type: "List<int>",
                multiSelectTemplate: multiSelectTemplate,
                validationSetting: null,
                fieldTypeSource: "ListIntType",
                listElementTypeSource: "IntType"
            );

            // Act
            string json = JsonSerializer.Serialize(original, SerializationOptions.Default);
            var deserialized = JsonSerializer.Deserialize<MultiSelectFormControlSettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserialized);
            Assert.Equal(original.Field, deserialized.Field);
            Assert.Equal(original.KeyFields.Count, deserialized.KeyFields.Count);
            Assert.Equal(original.Title, deserialized.Title);
            Assert.Equal(original.FieldTypeSource, deserialized.FieldTypeSource);
            Assert.Equal(original.ListElementTypeSource, deserialized.ListElementTypeSource);
        }

        [Fact]
        public void CanDeserializeWithCaseInsensitivePropertyNames()
        {
            // Arrange
            string json = """
                {
                    "field": "RoleIds",
                    "keyfields": ["RoleId"],
                    "title": "Roles",
                    "placeholder": "Select roles",
                    "stringformat": "{0}",
                    "type": "List<int>",
                    "multiselecttemplate": {
                        "templatename": "RoleMultiSelect",
                        "placeholdertext": "Select roles",
                        "textfield": "RoleName",
                        "valuefield": "RoleId",
                        "modeltype": "Model.Role",
                        "loadingindicatortext": "Loading...",
                        "textandvalueselector": null,
                        "requestdetails": {
                            "modeltype": "Model.Role",
                            "datatype": "Data.RoleData",
                            "modelreturntype": "Model.RoleResponse",
                            "datareturntype": "Data.RoleDataResponse",
                            "datasourceurl": "/api/roles"
                        }
                    }
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<MultiSelectFormControlSettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("RoleIds", descriptor.Field);
        }
    }
}
