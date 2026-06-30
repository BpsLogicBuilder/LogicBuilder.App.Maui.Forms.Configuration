using LogicBuilder.App.Maui.Forms.Configuration.Bindings;
using System.Text.Json;

namespace LogicBuilder.App.Maui.Forms.Configuration.Tests.Bindings
{
    public class MultiSelectItemBindingDescriptorTest
    {
        [Fact]
        public void CanSerializeMultiSelectItemBindingDescriptor()
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
            var descriptor = new MultiSelectItemBindingDescriptor(
                name: "Tags",
                property: "TagIds",
                title: "Tags",
                stringFormat: "{0}",
                keyFields: ["Id"],
                multiSelectTemplate: multiSelectTemplate,
                fieldTypeSource: null,
                listElementTypeSource: null
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor, SerializationOptions.Default);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(json));
            Assert.Contains("\"Name\"", json);
            Assert.Contains("\"Property\"", json);
            Assert.Contains("\"Title\"", json);
            Assert.Contains("\"StringFormat\"", json);
            Assert.Contains("\"KeyFields\"", json);
            Assert.Contains("\"MultiSelectTemplate\"", json);
        }

        [Fact]
        public void CanDeserializeMultiSelectItemBindingDescriptor()
        {
            // Arrange
            string json = """
                {
                    "Name": "Tags",
                    "Property": "TagIds",
                    "Title": "Tags",
                    "StringFormat": "{0}",
                    "KeyFields": ["Id"],
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
                    "FieldTypeSource": null,
                    "ListElementTypeSource": null
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<MultiSelectItemBindingDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("Tags", descriptor.Name);
            Assert.Equal("TagIds", descriptor.Property);
            Assert.Equal("Tags", descriptor.Title);
            Assert.Equal("{0}", descriptor.StringFormat);
            Assert.NotNull(descriptor.KeyFields);
            Assert.Single(descriptor.KeyFields);
            Assert.Contains("Id", descriptor.KeyFields);
            Assert.NotNull(descriptor.MultiSelectTemplate);
            Assert.Equal("TagMultiSelect", descriptor.MultiSelectTemplate.TemplateName);
            Assert.Equal("TagMultiSelect", descriptor.TemplateName);
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
                "Model.Category", "Loading categories...", null!, requestDetails, "CategoryType"
            );
            var original = new MultiSelectItemBindingDescriptor(
                name: "Categories",
                property: "CategoryIds",
                title: "Categories",
                stringFormat: "{0}",
                keyFields: ["CategoryId", "CategoryName"],
                multiSelectTemplate: multiSelectTemplate,
                fieldTypeSource: "CategoryFieldType",
                listElementTypeSource: "Contoso.Person"
            );

            // Act
            string json = JsonSerializer.Serialize(original, SerializationOptions.Default);
            var deserialized = JsonSerializer.Deserialize<MultiSelectItemBindingDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserialized);
            Assert.Equal(original.Name, deserialized.Name);
            Assert.Equal(original.Property, deserialized.Property);
            Assert.Equal(original.Title, deserialized.Title);
            Assert.Equal(original.StringFormat, deserialized.StringFormat);
            Assert.Equal(original.KeyFields.Count, deserialized.KeyFields.Count);
            Assert.Equal(original.FieldTypeSource, deserialized.FieldTypeSource);
            Assert.Equal(original.ListElementTypeSource, deserialized.ListElementTypeSource);
            Assert.Equal(original.TemplateName, deserialized.TemplateName);
        }

        [Fact]
        public void CanDeserializeWithCaseInsensitivePropertyNames()
        {
            // Arrange
            string json = """
                {
                    "name": "Roles",
                    "property": "RoleIds",
                    "title": "Roles",
                    "stringformat": "{0}",
                    "keyfields": ["RoleId"],
                    "multiselecttemplate": {
                        "templatename": "RoleMultiSelect",
                        "placeholdertext": "Select roles",
                        "textfield": "RoleName",
                        "valuefield": "RoleId",
                        "modeltype": "Model.Role",
                        "loadingindicatortext": "Loading roles...",
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
            var descriptor = JsonSerializer.Deserialize<MultiSelectItemBindingDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("Roles", descriptor.Name);
            Assert.Equal("RoleIds", descriptor.Property);
        }
    }
}
