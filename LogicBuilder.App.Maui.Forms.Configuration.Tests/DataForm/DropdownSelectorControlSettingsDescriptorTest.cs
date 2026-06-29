using LogicBuilder.App.Maui.Forms.Configuration.DataForm;
using LogicBuilder.App.Maui.Forms.Configuration.Validation;
using System.Text.Json;

namespace LogicBuilder.App.Maui.Forms.Configuration.Tests.DataForm
{
    public class DropdownSelectorControlSettingsDescriptorTest
    {
        [Fact]
        public void CanSerializeDropdownSelectorControlSettingsDescriptor()
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
            var descriptor = new DropdownSelectorControlSettingsDescriptor(
                field: "CountryId",
                title: "Country",
                placeholder: "Select a country",
                stringFormat: "{0}",
                type: "int",
                dropDownTemplate: dropDownTemplate,
                validationSetting: null,
                fieldTypeSource: null
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor, SerializationOptions.Default);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(json));
            Assert.Contains("\"Field\"", json);
            Assert.Contains("\"Title\"", json);
            Assert.Contains("\"Placeholder\"", json);
            Assert.Contains("\"DropDownTemplate\"", json);
        }

        [Fact]
        public void CanDeserializeDropdownSelectorControlSettingsDescriptor()
        {
            // Arrange
            string json = """
                {
                    "Field": "CountryId",
                    "Title": "Country",
                    "Placeholder": "Select a country",
                    "StringFormat": "{0}",
                    "Type": "int",
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
                    "ValidationSetting": null,
                    "FieldTypeSource": null
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<DropdownSelectorControlSettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("CountryId", descriptor.Field);
            Assert.Equal("Country", descriptor.Title);
            Assert.Equal("Select a country", descriptor.Placeholder);
            Assert.NotNull(descriptor.DropDownTemplate);
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
                "Loading...", null!, requestDetails, null, null
            );
            var original = new DropdownSelectorControlSettingsDescriptor(
                field: "StateId",
                title: "State",
                placeholder: "Select a state",
                stringFormat: "{0}",
                type: "int",
                dropDownTemplate: dropDownTemplate,
                validationSetting: null,
                fieldTypeSource: "IntType"
            );

            // Act
            string json = JsonSerializer.Serialize(original, SerializationOptions.Default);
            var deserialized = JsonSerializer.Deserialize<DropdownSelectorControlSettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserialized);
            Assert.Equal(original.Field, deserialized.Field);
            Assert.Equal(original.Title, deserialized.Title);
            Assert.Equal(original.Placeholder, deserialized.Placeholder);
            Assert.Equal(original.FieldTypeSource, deserialized.FieldTypeSource);
        }

        [Fact]
        public void CanDeserializeWithCaseInsensitivePropertyNames()
        {
            // Arrange
            string json = """
                {
                    "field": "CityId",
                    "title": "City",
                    "placeholder": "Select a city",
                    "stringformat": "{0}",
                    "type": "int",
                    "dropdowntemplate": {
                        "templatename": "CityDropDown",
                        "titletext": "Select City",
                        "textfield": "CityName",
                        "valuefield": "CityId",
                        "loadingindicatortext": "Loading...",
                        "textandvalueselector": null,
                        "requestdetails": {
                            "modeltype": "Model.City",
                            "datatype": "Data.CityData",
                            "modelreturntype": "Model.CityResponse",
                            "datareturntype": "Data.CityDataResponse",
                            "datasourceurl": "/api/cities"
                        }
                    }
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<DropdownSelectorControlSettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("CityId", descriptor.Field);
        }
    }
}
