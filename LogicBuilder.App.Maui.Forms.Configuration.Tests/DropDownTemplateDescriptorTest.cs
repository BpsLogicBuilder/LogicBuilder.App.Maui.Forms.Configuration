using System.Text.Json;

namespace LogicBuilder.App.Maui.Forms.Configuration.Tests
{
    public class DropDownTemplateDescriptorTest
    {
        [Fact]
        public void CanSerializeDropDownTemplateDescriptor()
        {
            // Arrange
            var requestDetails = new RequestDetailsDescriptor(
                "Model.Person", "Data.PersonData", "Model.PersonResponse", 
                "Data.PersonDataResponse", "/api/persons"
            );
            var descriptor = new DropDownTemplateDescriptor(
                templateName: "PersonDropDown",
                titleText: "Select Person",
                textField: "Name",
                valueField: "Id",
                loadingIndicatorText: "Loading...",
                textAndValueSelector: null!,
                requestDetails: requestDetails,
                reloadItemsFlowName: null,
                fieldTypeSource: null
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor, SerializationOptions.Default);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(json));
            Assert.Contains("\"TemplateName\"", json);
            Assert.Contains("\"TitleText\"", json);
            Assert.Contains("\"TextField\"", json);
            Assert.Contains("\"ValueField\"", json);
            Assert.Contains("\"LoadingIndicatorText\"", json);
            Assert.Contains("\"RequestDetails\"", json);
        }

        [Fact]
        public void CanDeserializeDropDownTemplateDescriptor()
        {
            // Arrange
            string json = """
                {
                    "TemplateName": "PersonDropDown",
                    "TitleText": "Select Person",
                    "TextField": "Name",
                    "ValueField": "Id",
                    "LoadingIndicatorText": "Loading...",
                    "TextAndValueSelector": null,
                    "RequestDetails": {
                        "ModelType": "Model.Person",
                        "DataType": "Data.PersonData",
                        "ModelReturnType": "Model.PersonResponse",
                        "DataReturnType": "Data.PersonDataResponse",
                        "DataSourceUrl": "/api/persons"
                    },
                    "ReloadItemsFlowName": null,
                    "FieldTypeSource": null
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<DropDownTemplateDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("PersonDropDown", descriptor.TemplateName);
            Assert.Equal("Select Person", descriptor.TitleText);
            Assert.Equal("Name", descriptor.TextField);
            Assert.Equal("Id", descriptor.ValueField);
            Assert.Equal("Loading...", descriptor.LoadingIndicatorText);
            Assert.NotNull(descriptor.RequestDetails);
        }

        [Fact]
        public void SerializationRoundTripPreservesAllProperties()
        {
            // Arrange
            var requestDetails = new RequestDetailsDescriptor(
                "Model.Customer", "Data.CustomerData", "Model.CustomerResponse",
                "Data.CustomerDataResponse", "/api/customers"
            );
            var original = new DropDownTemplateDescriptor(
                templateName: "CustomerDropDown",
                titleText: "Select Customer",
                textField: "CompanyName",
                valueField: "CustomerId",
                loadingIndicatorText: "Please wait...",
                textAndValueSelector: null!,
                requestDetails: requestDetails,
                reloadItemsFlowName: "ReloadCustomers",
                fieldTypeSource: "CustomerType"
            );

            // Act
            string json = JsonSerializer.Serialize(original, SerializationOptions.Default);
            var deserialized = JsonSerializer.Deserialize<DropDownTemplateDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserialized);
            Assert.Equal(original.TemplateName, deserialized.TemplateName);
            Assert.Equal(original.TitleText, deserialized.TitleText);
            Assert.Equal(original.TextField, deserialized.TextField);
            Assert.Equal(original.ValueField, deserialized.ValueField);
            Assert.Equal(original.LoadingIndicatorText, deserialized.LoadingIndicatorText);
            Assert.Equal(original.ReloadItemsFlowName, deserialized.ReloadItemsFlowName);
            Assert.Equal(original.FieldTypeSource, deserialized.FieldTypeSource);
        }

        [Fact]
        public void CanDeserializeWithCaseInsensitivePropertyNames()
        {
            // Arrange
            string json = """
                {
                    "templatename": "ProductDropDown",
                    "titletext": "Select Product",
                    "textfield": "ProductName",
                    "valuefield": "ProductId",
                    "loadingindicatortext": "Loading products...",
                    "textandvalueselector": null,
                    "requestdetails": {
                        "modeltype": "Model.Product",
                        "datatype": "Data.ProductData",
                        "modelreturntype": "Model.ProductResponse",
                        "datareturntype": "Data.ProductDataResponse",
                        "datasourceurl": "/api/products"
                    }
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<DropDownTemplateDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("ProductDropDown", descriptor.TemplateName);
            Assert.Equal("Select Product", descriptor.TitleText);
        }
    }
}
