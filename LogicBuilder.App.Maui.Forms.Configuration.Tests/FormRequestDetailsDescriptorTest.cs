using System.Text.Json;

namespace LogicBuilder.App.Maui.Forms.Configuration.Tests
{
    public class FormRequestDetailsDescriptorTest
    {
        [Fact]
        public void CanSerializeFormRequestDetailsDescriptor()
        {
            // Arrange
            var descriptor = new FormRequestDetailsDescriptor(
                getUrl: "/api/get",
                addUrl: "/api/add",
                updateUrl: "/api/update",
                deleteUrl: "/api/delete",
                modelType: "Model.Person",
                dataType: "Data.PersonData",
                filter: null,
                selectExpandDefinition: null
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor, SerializationOptions.Default);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(json));
            Assert.Contains("\"GetUrl\"", json);
            Assert.Contains("\"AddUrl\"", json);
            Assert.Contains("\"UpdateUrl\"", json);
            Assert.Contains("\"DeleteUrl\"", json);
            Assert.Contains("\"ModelType\"", json);
            Assert.Contains("\"DataType\"", json);
        }

        [Fact]
        public void CanDeserializeFormRequestDetailsDescriptor()
        {
            // Arrange
            string json = """
                {
                    "GetUrl": "/api/get",
                    "AddUrl": "/api/add",
                    "UpdateUrl": "/api/update",
                    "DeleteUrl": "/api/delete",
                    "ModelType": "Model.Person",
                    "DataType": "Data.PersonData",
                    "Filter": null,
                    "SelectExpandDefinition": null
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<FormRequestDetailsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("/api/get", descriptor.GetUrl);
            Assert.Equal("/api/add", descriptor.AddUrl);
            Assert.Equal("/api/update", descriptor.UpdateUrl);
            Assert.Equal("/api/delete", descriptor.DeleteUrl);
            Assert.Equal("Model.Person", descriptor.ModelType);
            Assert.Equal("Data.PersonData", descriptor.DataType);
            Assert.Null(descriptor.Filter);
            Assert.Null(descriptor.SelectExpandDefinition);
        }

        [Fact]
        public void SerializationRoundTripPreservesAllProperties()
        {
            // Arrange
            var original = new FormRequestDetailsDescriptor(
                getUrl: "/api/customer/get",
                addUrl: "/api/customer/add",
                updateUrl: "/api/customer/update",
                deleteUrl: "/api/customer/delete",
                modelType: "Model.Customer",
                dataType: "Data.CustomerData",
                filter: null,
                selectExpandDefinition: null
            );

            // Act
            string json = JsonSerializer.Serialize(original, SerializationOptions.Default);
            var deserialized = JsonSerializer.Deserialize<FormRequestDetailsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserialized);
            Assert.Equal(original.GetUrl, deserialized.GetUrl);
            Assert.Equal(original.AddUrl, deserialized.AddUrl);
            Assert.Equal(original.UpdateUrl, deserialized.UpdateUrl);
            Assert.Equal(original.DeleteUrl, deserialized.DeleteUrl);
            Assert.Equal(original.ModelType, deserialized.ModelType);
            Assert.Equal(original.DataType, deserialized.DataType);
        }

        [Fact]
        public void CanDeserializeWithCaseInsensitivePropertyNames()
        {
            // Arrange
            string json = """
                {
                    "geturl": "/api/get",
                    "addurl": "/api/add",
                    "updateurl": "/api/update",
                    "deleteurl": "/api/delete",
                    "modeltype": "Model.Product",
                    "datatype": "Data.ProductData"
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<FormRequestDetailsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("/api/get", descriptor.GetUrl);
            Assert.Equal("Model.Product", descriptor.ModelType);
        }
    }
}
