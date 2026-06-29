using System.Text.Json;

namespace LogicBuilder.App.Maui.Forms.Configuration.Tests
{
    public class RequestDetailsDescriptorTest
    {
        [Fact]
        public void CanSerializeRequestDetailsDescriptor()
        {
            // Arrange
            var descriptor = new RequestDetailsDescriptor(
                modelType: "Model.Person",
                dataType: "Data.PersonData",
                modelReturnType: "Model.PersonResponse",
                dataReturnType: "Data.PersonDataResponse",
                dataSourceUrl: "/api/persons"
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor, SerializationOptions.Default);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(json));
            Assert.Contains("\"ModelType\"", json);
            Assert.Contains("\"DataType\"", json);
            Assert.Contains("\"ModelReturnType\"", json);
            Assert.Contains("\"DataReturnType\"", json);
            Assert.Contains("\"DataSourceUrl\"", json);
        }

        [Fact]
        public void CanDeserializeRequestDetailsDescriptor()
        {
            // Arrange
            string json = """
                {
                    "ModelType": "Model.Person",
                    "DataType": "Data.PersonData",
                    "ModelReturnType": "Model.PersonResponse",
                    "DataReturnType": "Data.PersonDataResponse",
                    "DataSourceUrl": "/api/persons"
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<RequestDetailsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("Model.Person", descriptor.ModelType);
            Assert.Equal("Data.PersonData", descriptor.DataType);
            Assert.Equal("Model.PersonResponse", descriptor.ModelReturnType);
            Assert.Equal("Data.PersonDataResponse", descriptor.DataReturnType);
            Assert.Equal("/api/persons", descriptor.DataSourceUrl);
        }

        [Fact]
        public void SerializationRoundTripPreservesAllProperties()
        {
            // Arrange
            var original = new RequestDetailsDescriptor(
                modelType: "Model.Customer",
                dataType: "Data.CustomerData",
                modelReturnType: "Model.CustomerResponse",
                dataReturnType: "Data.CustomerDataResponse",
                dataSourceUrl: "/api/customers"
            );

            // Act
            string json = JsonSerializer.Serialize(original, SerializationOptions.Default);
            var deserialized = JsonSerializer.Deserialize<RequestDetailsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserialized);
            Assert.Equal(original.ModelType, deserialized.ModelType);
            Assert.Equal(original.DataType, deserialized.DataType);
            Assert.Equal(original.ModelReturnType, deserialized.ModelReturnType);
            Assert.Equal(original.DataReturnType, deserialized.DataReturnType);
            Assert.Equal(original.DataSourceUrl, deserialized.DataSourceUrl);
        }

        [Fact]
        public void CanDeserializeWithCaseInsensitivePropertyNames()
        {
            // Arrange
            string json = """
                {
                    "modeltype": "Model.Product",
                    "datatype": "Data.ProductData",
                    "modelreturntype": "Model.ProductResponse",
                    "datareturntype": "Data.ProductDataResponse",
                    "datasourceurl": "/api/products"
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<RequestDetailsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("Model.Product", descriptor.ModelType);
            Assert.Equal("Data.ProductData", descriptor.DataType);
        }
    }
}
