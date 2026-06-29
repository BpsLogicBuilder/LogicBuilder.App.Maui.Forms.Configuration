using LogicBuilder.App.Maui.Forms.Configuration.Validation;
using System.Collections.Generic;
using System.Text.Json;

namespace LogicBuilder.App.Maui.Forms.Configuration.Tests.Validation
{
    public class ValidationMessageDescriptorTest
    {
        [Fact]
        public void CanSerializeValidationMessageDescriptor()
        {
            // Arrange
            var rule = new ValidationRuleDescriptor("RequiredRule", "Field is required");
            var descriptor = new ValidationMessageDescriptor(
                field: "Name",
                rules: [rule],
                fieldTypeSource: null
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor, SerializationOptions.Default);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(json));
            Assert.Contains("\"Field\"", json);
            Assert.Contains("\"Rules\"", json);
        }

        [Fact]
        public void CanDeserializeValidationMessageDescriptor()
        {
            // Arrange
            string json = """
                {
                    "Field": "Name",
                    "Rules": [
                        {
                            "ClassName": "RequiredRule",
                            "Message": "Field is required"
                        }
                    ],
                    "FieldTypeSource": null
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<ValidationMessageDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("Name", descriptor.Field);
            Assert.NotNull(descriptor.Rules);
            Assert.Single(descriptor.Rules);
        }

        [Fact]
        public void SerializationRoundTripPreservesAllProperties()
        {
            // Arrange
            var original = new ValidationMessageDescriptor(
                field: "Email",
                rules: [],
                fieldTypeSource: "StringType"
            );

            // Act
            string json = JsonSerializer.Serialize(original, SerializationOptions.Default);
            var deserialized = JsonSerializer.Deserialize<ValidationMessageDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserialized);
            Assert.Equal(original.Field, deserialized.Field);
            Assert.Equal(original.FieldTypeSource, deserialized.FieldTypeSource);
        }

        [Fact]
        public void CanDeserializeWithCaseInsensitivePropertyNames()
        {
            // Arrange
            string json = """
                {
                    "field": "Phone",
                    "rules": [],
                    "fieldtypesource": null
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<ValidationMessageDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("Phone", descriptor.Field);
        }
    }
}
