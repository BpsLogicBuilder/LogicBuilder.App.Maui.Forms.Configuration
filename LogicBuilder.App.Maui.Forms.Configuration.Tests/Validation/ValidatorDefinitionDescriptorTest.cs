using LogicBuilder.App.Maui.Forms.Configuration.Validation;
using System.Collections.Generic;
using System.Text.Json;

namespace LogicBuilder.App.Maui.Forms.Configuration.Tests.Validation
{
    public class ValidatorDefinitionDescriptorTest
    {
        [Fact]
        public void CanSerializeValidatorDefinitionDescriptor()
        {
            // Arrange
            var arguments = new Dictionary<string, ValidatorArgumentDescriptor>
            {
                { "minLength", new ValidatorArgumentDescriptor("minLength", 5, "int") }
            };
            var descriptor = new ValidatorDefinitionDescriptor(
                className: "LengthValidator",
                functionName: "Validate",
                arguments: arguments
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor, SerializationOptions.Default);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(json));
            Assert.Contains("\"ClassName\"", json);
            Assert.Contains("\"FunctionName\"", json);
            Assert.Contains("\"Arguments\"", json);
        }

        [Fact]
        public void CanDeserializeValidatorDefinitionDescriptor()
        {
            // Arrange
            string json = """
                {
                    "ClassName": "LengthValidator",
                    "FunctionName": "Validate",
                    "Arguments": {
                        "minLength": {
                            "Name": "minLength",
                            "Value": 5,
                            "Type": "int"
                        }
                    }
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<ValidatorDefinitionDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("LengthValidator", descriptor.ClassName);
            Assert.Equal("Validate", descriptor.FunctionName);
            Assert.NotNull(descriptor.Arguments);
            Assert.Single(descriptor.Arguments);
        }

        [Fact]
        public void SerializationRoundTripPreservesAllProperties()
        {
            // Arrange
            var original = new ValidatorDefinitionDescriptor(
                className: "RequiredValidator",
                functionName: "Check",
                arguments: null
            );

            // Act
            string json = JsonSerializer.Serialize(original, SerializationOptions.Default);
            var deserialized = JsonSerializer.Deserialize<ValidatorDefinitionDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserialized);
            Assert.Equal(original.ClassName, deserialized.ClassName);
            Assert.Equal(original.FunctionName, deserialized.FunctionName);
        }

        [Fact]
        public void CanDeserializeWithCaseInsensitivePropertyNames()
        {
            // Arrange
            string json = """
                {
                    "classname": "EmailValidator",
                    "functionname": "Validate",
                    "arguments": null
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<ValidatorDefinitionDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("EmailValidator", descriptor.ClassName);
            Assert.Equal("Validate", descriptor.FunctionName);
        }
    }
}
