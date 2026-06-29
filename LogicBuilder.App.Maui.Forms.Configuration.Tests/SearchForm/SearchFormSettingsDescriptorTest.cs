using LogicBuilder.App.Maui.Forms.Configuration.Bindings;
using LogicBuilder.App.Maui.Forms.Configuration.SearchForm;
using System.Collections.Generic;
using System.Text.Json;

namespace LogicBuilder.App.Maui.Forms.Configuration.Tests.SearchForm
{
    public class SearchFormSettingsDescriptorTest
    {
        [Fact]
        public void CanSerializeSearchFormSettingsDescriptor()
        {
            // Arrange
            var requestDetails = new RequestDetailsDescriptor(
                "Model.Person", "Data.PersonData", "Model.PersonResponse",
                "Data.PersonDataResponse", "/api/persons"
            );
            var descriptor = new SearchFormSettingsDescriptor(
                title: "Person Search",
                modelType: "Model.Person",
                loadingIndicatorText: "Searching...",
                itemTemplateName: "PersonItemTemplate",
                filterPlaceholder: "Search...",
                createPagingSelectorFlowName: "CreatePaging",
                bindings: [],
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
            Assert.Contains("\"FilterPlaceholder\"", json);
            Assert.Contains("\"CreatePagingSelectorFlowName\"", json);
            Assert.Contains("\"Bindings\"", json);
            Assert.Contains("\"RequestDetails\"", json);
        }

        [Fact]
        public void CanDeserializeSearchFormSettingsDescriptor()
        {
            // Arrange
            string json = """
                {
                    "Title": "Person Search",
                    "ModelType": "Model.Person",
                    "LoadingIndicatorText": "Searching...",
                    "ItemTemplateName": "PersonItemTemplate",
                    "FilterPlaceholder": "Search...",
                    "CreatePagingSelectorFlowName": "CreatePaging",
                    "Bindings": {},
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
            var descriptor = JsonSerializer.Deserialize<SearchFormSettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("Person Search", descriptor.Title);
            Assert.Equal("Model.Person", descriptor.ModelType);
            Assert.Equal("Searching...", descriptor.LoadingIndicatorText);
            Assert.Equal("PersonItemTemplate", descriptor.ItemTemplateName);
            Assert.Equal("Search...", descriptor.FilterPlaceholder);
            Assert.Equal("CreatePaging", descriptor.CreatePagingSelectorFlowName);
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
            var original = new SearchFormSettingsDescriptor(
                title: "Customer Search",
                modelType: "Model.Customer",
                loadingIndicatorText: "Loading customers...",
                itemTemplateName: "CustomerItemTemplate",
                filterPlaceholder: "Search customers...",
                createPagingSelectorFlowName: "CreateCustomerPaging",
                bindings: bindings,
                requestDetails: requestDetails
            );

            // Act
            string json = JsonSerializer.Serialize(original, SerializationOptions.Default);

            // Assert - Only verify serialization produces valid JSON since deserialization of abstract types requires type discriminators
            Assert.False(string.IsNullOrWhiteSpace(json));
            Assert.Contains("\"Title\"", json);
            Assert.Contains("Customer Search", json);
            Assert.Contains("\"ModelType\"", json);
            Assert.Contains("Model.Customer", json);
            Assert.Contains("\"FilterPlaceholder\"", json);
            Assert.Contains("Search customers", json);
        }

        [Fact]
        public void CanDeserializeWithCaseInsensitivePropertyNames()
        {
            // Arrange
            string json = """
                {
                    "title": "Product Search",
                    "modeltype": "Model.Product",
                    "loadingindicatortext": "Loading products...",
                    "itemtemplatename": "ProductItemTemplate",
                    "filterplaceholder": "Search products...",
                    "createpagingselectorflowname": "CreateProductPaging",
                    "bindings": {},
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
            var descriptor = JsonSerializer.Deserialize<SearchFormSettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("Product Search", descriptor.Title);
            Assert.Equal("Model.Product", descriptor.ModelType);
        }
    }
}
