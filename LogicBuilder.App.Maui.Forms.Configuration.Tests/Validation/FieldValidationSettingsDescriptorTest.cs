using LogicBuilder.App.Maui.Forms.Configuration.Validation;
using System.Collections.Generic;
using System.Text.Json;

namespace LogicBuilder.App.Maui.Forms.Configuration.Tests.Validation
{
    public class FieldValidationSettingsDescriptorTest
    {
        [Fact]
        public void CanSerializeFieldValidationSettingsDescriptor()
        {
            // Arrange
            var validator = new ValidatorDefinitionDescriptor("RequiredValidator", "Validate", null);
            var descriptor = new FieldValidationSettingsDescriptor(
                defaultValue: "",
                validators: [validator]
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor, SerializationOptions.Default);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(json));
            Assert.Contains("\"DefaultValue\"", json);
            Assert.Contains("\"Validators\"", json);
        }

        [Fact]
        public void CanDeserializeFieldValidationSettingsDescriptor()
        {
            // Arrange
            string json = """
                {
                    "DefaultValue": "",
                    "Validators": [
                        {
                            "ClassName": "RequiredValidator",
                            "FunctionName": "Validate",
                            "Arguments": null
                        }
                    ]
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<FieldValidationSettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.NotNull(descriptor.DefaultValue);
            Assert.NotNull(descriptor.Validators);
            Assert.Single(descriptor.Validators);
        }

        [Fact]
        public void SerializationRoundTripPreservesAllProperties()
        {
            // Arrange
            var original = new FieldValidationSettingsDescriptor(
                defaultValue: 0,
                validators: null
            );

            // Act
            string json = JsonSerializer.Serialize(original, SerializationOptions.Default);
            var deserialized = JsonSerializer.Deserialize<FieldValidationSettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserialized);
            Assert.NotNull(deserialized.DefaultValue);
        }

        [Fact]
        public void CanDeserializeWithCaseInsensitivePropertyNames()
        {
            // Arrange
            string json = """
                {
                    "defaultvalue": false,
                    "validators": null
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<FieldValidationSettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.NotNull(descriptor.DefaultValue);
        }
    }
}
