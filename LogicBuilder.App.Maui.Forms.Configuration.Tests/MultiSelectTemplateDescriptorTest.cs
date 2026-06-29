using System.Text.Json;

namespace LogicBuilder.App.Maui.Forms.Configuration.Tests
{
    public class MultiSelectTemplateDescriptorTest
    {
        [Fact]
        public void CanSerializeMultiSelectTemplateDescriptor()
        {
            // Arrange
            var requestDetails = new RequestDetailsDescriptor(
                "Model.Tag", "Data.TagData", "Model.TagResponse",
                "Data.TagDataResponse", "/api/tags"
            );
            var descriptor = new MultiSelectTemplateDescriptor(
                templateName: "TagMultiSelect",
                placeholderText: "Select tags",
                textField: "Name",
                valueField: "Id",
                modelType: "Model.Tag",
                loadingIndicatorText: "Loading...",
                textAndValueSelector: null!,
                requestDetails: requestDetails,
                fieldTypeSource: null
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor, SerializationOptions.Default);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(json));
            Assert.Contains("\"TemplateName\"", json);
            Assert.Contains("\"PlaceholderText\"", json);
            Assert.Contains("\"TextField\"", json);
            Assert.Contains("\"ValueField\"", json);
            Assert.Contains("\"ModelType\"", json);
            Assert.Contains("\"LoadingIndicatorText\"", json);
            Assert.Contains("\"RequestDetails\"", json);
        }

        [Fact]
        public void CanDeserializeMultiSelectTemplateDescriptor()
        {
            // Arrange
            string json = """
                {
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
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<MultiSelectTemplateDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("TagMultiSelect", descriptor.TemplateName);
            Assert.Equal("Select tags", descriptor.PlaceholderText);
            Assert.Equal("Name", descriptor.TextField);
            Assert.Equal("Id", descriptor.ValueField);
            Assert.Equal("Model.Tag", descriptor.ModelType);
            Assert.Equal("Loading...", descriptor.LoadingIndicatorText);
            Assert.NotNull(descriptor.RequestDetails);
        }

        [Fact]
        public void SerializationRoundTripPreservesAllProperties()
        {
            // Arrange
            var requestDetails = new RequestDetailsDescriptor(
                "Model.Category", "Data.CategoryData", "Model.CategoryResponse",
                "Data.CategoryDataResponse", "/api/categories"
            );
            var original = new MultiSelectTemplateDescriptor(
                templateName: "CategoryMultiSelect",
                placeholderText: "Select categories",
                textField: "CategoryName",
                valueField: "CategoryId",
                modelType: "Model.Category",
                loadingIndicatorText: "Please wait...",
                textAndValueSelector: null!,
                requestDetails: requestDetails,
                fieldTypeSource: "CategoryType"
            );

            // Act
            string json = JsonSerializer.Serialize(original, SerializationOptions.Default);
            var deserialized = JsonSerializer.Deserialize<MultiSelectTemplateDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserialized);
            Assert.Equal(original.TemplateName, deserialized.TemplateName);
            Assert.Equal(original.PlaceholderText, deserialized.PlaceholderText);
            Assert.Equal(original.TextField, deserialized.TextField);
            Assert.Equal(original.ValueField, deserialized.ValueField);
            Assert.Equal(original.ModelType, deserialized.ModelType);
            Assert.Equal(original.LoadingIndicatorText, deserialized.LoadingIndicatorText);
            Assert.Equal(original.FieldTypeSource, deserialized.FieldTypeSource);
        }

        [Fact]
        public void CanDeserializeWithCaseInsensitivePropertyNames()
        {
            // Arrange
            string json = """
                {
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
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<MultiSelectTemplateDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("RoleMultiSelect", descriptor.TemplateName);
            Assert.Equal("Select roles", descriptor.PlaceholderText);
        }
    }
}
