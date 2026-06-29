using LogicBuilder.App.Maui.Forms.Configuration.Bindings;
using System.Text.Json;

namespace LogicBuilder.App.Maui.Forms.Configuration.Tests.Bindings
{
    public class DropDownItemBindingDescriptorTest
    {
        [Fact]
        public void CanSerializeDropDownItemBindingDescriptor()
        {
            // Arrange
            var requestDetails = new RequestDetailsDescriptor(
                "Model.Country", "Data.CountryData", "Model.CountryResponse",
                "Data.CountryDataResponse", "/api/countries"
            );
            var dropDownTemplate = new DropDownTemplateDescriptor(
                "CountryDropDown", "Select Country", "Name", "Id",
                "Loading...", null!, requestDetails, null, null
            );
            var descriptor = new DropDownItemBindingDescriptor(
                name: "Country",
                property: "CountryId",
                title: "Country",
                stringFormat: "{0}",
                dropDownTemplate: dropDownTemplate,
                requiresReload: false,
                fieldTypeSource: null
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor, SerializationOptions.Default);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(json));
            Assert.Contains("\"Name\"", json);
            Assert.Contains("\"Property\"", json);
            Assert.Contains("\"Title\"", json);
            Assert.Contains("\"StringFormat\"", json);
            Assert.Contains("\"DropDownTemplate\"", json);
            Assert.Contains("\"RequiresReload\"", json);
        }

        [Fact]
        public void CanDeserializeDropDownItemBindingDescriptor()
        {
            // Arrange
            string json = """
                {
                    "Name": "Country",
                    "Property": "CountryId",
                    "Title": "Country",
                    "StringFormat": "{0}",
                    "DropDownTemplate": {
                        "TemplateName": "CountryDropDown",
                        "TitleText": "Select Country",
                        "TextField": "Name",
                        "ValueField": "Id",
                        "LoadingIndicatorText": "Loading...",
                        "TextAndValueSelector": null,
                        "RequestDetails": {
                            "ModelType": "Model.Country",
                            "DataType": "Data.CountryData",
                            "ModelReturnType": "Model.CountryResponse",
                            "DataReturnType": "Data.CountryDataResponse",
                            "DataSourceUrl": "/api/countries"
                        },
                        "ReloadItemsFlowName": null,
                        "FieldTypeSource": null
                    },
                    "RequiresReload": false,
                    "FieldTypeSource": null
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<DropDownItemBindingDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("Country", descriptor.Name);
            Assert.Equal("CountryId", descriptor.Property);
            Assert.Equal("Country", descriptor.Title);
            Assert.Equal("{0}", descriptor.StringFormat);
            Assert.NotNull(descriptor.DropDownTemplate);
            Assert.Equal("CountryDropDown", descriptor.DropDownTemplate.TemplateName);
            Assert.False(descriptor.RequiresReload);
            Assert.Equal("CountryDropDown", descriptor.TemplateName);
        }

        [Fact]
        public void SerializationRoundTripPreservesAllProperties()
        {
            // Arrange
            var requestDetails = new RequestDetailsDescriptor(
                "Model.State", "Data.StateData", "Model.StateResponse",
                "Data.StateDataResponse", "/api/states"
            );
            var dropDownTemplate = new DropDownTemplateDescriptor(
                "StateDropDown", "Select State", "StateName", "StateId",
                "Loading states...", null!, requestDetails, "ReloadStates", "StateType"
            );
            var original = new DropDownItemBindingDescriptor(
                name: "State",
                property: "StateId",
                title: "State",
                stringFormat: "{0}",
                dropDownTemplate: dropDownTemplate,
                requiresReload: true,
                fieldTypeSource: "StateFieldType"
            );

            // Act
            string json = JsonSerializer.Serialize(original, SerializationOptions.Default);
            var deserialized = JsonSerializer.Deserialize<DropDownItemBindingDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserialized);
            Assert.Equal(original.Name, deserialized.Name);
            Assert.Equal(original.Property, deserialized.Property);
            Assert.Equal(original.Title, deserialized.Title);
            Assert.Equal(original.StringFormat, deserialized.StringFormat);
            Assert.Equal(original.RequiresReload, deserialized.RequiresReload);
            Assert.Equal(original.FieldTypeSource, deserialized.FieldTypeSource);
            Assert.Equal(original.TemplateName, deserialized.TemplateName);
        }

        [Fact]
        public void CanDeserializeWithCaseInsensitivePropertyNames()
        {
            // Arrange
            string json = """
                {
                    "name": "City",
                    "property": "CityId",
                    "title": "City",
                    "stringformat": "{0}",
                    "dropdowntemplate": {
                        "templatename": "CityDropDown",
                        "titletext": "Select City",
                        "textfield": "CityName",
                        "valuefield": "CityId",
                        "loadingindicatortext": "Loading cities...",
                        "textandvalueselector": null,
                        "requestdetails": {
                            "modeltype": "Model.City",
                            "datatype": "Data.CityData",
                            "modelreturntype": "Model.CityResponse",
                            "datareturntype": "Data.CityDataResponse",
                            "datasourceurl": "/api/cities"
                        },
                        "reloaditemsflowname": null,
                        "fieldtypesource": null
                    },
                    "requiresreload": true
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<DropDownItemBindingDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("City", descriptor.Name);
            Assert.True(descriptor.RequiresReload);
        }
    }
}
