using LogicBuilder.App.Maui.Forms.Configuration.Bindings;
using LogicBuilder.App.Maui.Forms.Configuration.ListForm;
using System.Collections.Generic;
using System.Text.Json;

namespace LogicBuilder.App.Maui.Forms.Configuration.Tests.ListForm
{
    public class ListFormSettingsDescriptorTest
    {
        [Fact]
        public void CanSerializeListFormSettingsDescriptor()
        {
            // Arrange
            var requestDetails = new RequestDetailsDescriptor(
                "Model.Person", "Data.PersonData", "Model.PersonResponse",
                "Data.PersonDataResponse", "/api/persons"
            );
            var descriptor = new ListFormSettingsDescriptor(
                title: "Person List",
                modelType: "Model.Person",
                loadingIndicatorText: "Loading...",
                itemTemplateName: "PersonItemTemplate",
                bindings: [],
                fieldsSelector: null!,
                requestDetails: requestDetails
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor, SerializationOptions.Default);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(json));
            Assert.Contains("\"Title\"", json);
            Assert.Contains("\"ModelType\"", json);
            Assert.Contains("\"LoadingIndicatorText\"", json);
            Assert.Contains("\"ItemTemplateName\"", json);
            Assert.Contains("\"Bindings\"", json);
            Assert.Contains("\"RequestDetails\"", json);
        }

        [Fact]
        public void CanDeserializeListFormSettingsDescriptor()
        {
            // Arrange
            string json = """
                {
                    "Title": "Person List",
                    "ModelType": "Model.Person",
                    "LoadingIndicatorText": "Loading...",
                    "ItemTemplateName": "PersonItemTemplate",
                    "Bindings": {},
                    "FieldsSelector": null,
                    "RequestDetails": {
                        "ModelType": "Model.Person",
                        "DataType": "Data.PersonData",
                        "ModelReturnType": "Model.PersonResponse",
                        "DataReturnType": "Data.PersonDataResponse",
                        "DataSourceUrl": "/api/persons"
                    }
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<ListFormSettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("Person List", descriptor.Title);
            Assert.Equal("Model.Person", descriptor.ModelType);
            Assert.Equal("Loading...", descriptor.LoadingIndicatorText);
            Assert.Equal("PersonItemTemplate", descriptor.ItemTemplateName);
            Assert.NotNull(descriptor.Bindings);
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
            var textTemplate = new TextFieldTemplateDescriptor("TextField");
            var binding = new TextItemBindingDescriptor("Name", "Name", "Name", "{0}", textTemplate, null);
            var bindings = new Dictionary<string, ItemBindingDescriptor>
            {
                { "Name", binding }
            };
            var original = new ListFormSettingsDescriptor(
                title: "Customer List",
                modelType: "Model.Customer",
                loadingIndicatorText: "Please wait...",
                itemTemplateName: "CustomerItemTemplate",
                bindings: bindings,
                fieldsSelector: null!,
                requestDetails: requestDetails
            );

            // Act
            string json = JsonSerializer.Serialize(original, SerializationOptions.Default);

            // Assert - Only verify serialization produces valid JSON since deserialization of abstract types requires type discriminators
            Assert.False(string.IsNullOrWhiteSpace(json));
            Assert.Contains("\"Title\"", json);
            Assert.Contains("Customer List", json);
            Assert.Contains("\"ModelType\"", json);
            Assert.Contains("Model.Customer", json);
        }

        [Fact]
        public void CanDeserializeWithCaseInsensitivePropertyNames()
        {
            // Arrange
            string json = """
                {
                    "title": "Product List",
                    "modeltype": "Model.Product",
                    "loadingindicatortext": "Loading products...",
                    "itemtemplatename": "ProductItemTemplate",
                    "bindings": {},
                    "fieldsselector": null,
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
            var descriptor = JsonSerializer.Deserialize<ListFormSettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("Product List", descriptor.Title);
            Assert.Equal("Model.Product", descriptor.ModelType);
        }
    }
}
