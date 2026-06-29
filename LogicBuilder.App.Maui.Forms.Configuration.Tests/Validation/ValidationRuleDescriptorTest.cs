using LogicBuilder.App.Maui.Forms.Configuration.Validation;
using System.Text.Json;

namespace LogicBuilder.App.Maui.Forms.Configuration.Tests.Validation
{
    public class ValidationRuleDescriptorTest
    {
        [Fact]
        public void CanSerializeValidationRuleDescriptor()
        {
            // Arrange
            var descriptor = new ValidationRuleDescriptor(
                className: "RequiredRule",
                message: "This field is required"
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor, SerializationOptions.Default);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(json));
            Assert.Contains("\"ClassName\"", json);
            Assert.Contains("\"Message\"", json);
        }

        [Fact]
        public void CanDeserializeValidationRuleDescriptor()
        {
            // Arrange
            string json = """
                {
                    "ClassName": "RequiredRule",
                    "Message": "This field is required"
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<ValidationRuleDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("RequiredRule", descriptor.ClassName);
            Assert.Equal("This field is required", descriptor.Message);
        }

        [Fact]
        public void SerializationRoundTripPreservesAllProperties()
        {
            // Arrange
            var original = new ValidationRuleDescriptor(
                className: "EmailRule",
                message: "Invalid email format"
            );

            // Act
            string json = JsonSerializer.Serialize(original, SerializationOptions.Default);
            var deserialized = JsonSerializer.Deserialize<ValidationRuleDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserialized);
            Assert.Equal(original.ClassName, deserialized.ClassName);
            Assert.Equal(original.Message, deserialized.Message);
        }

        [Fact]
        public void CanDeserializeWithCaseInsensitivePropertyNames()
        {
            // Arrange
            string json = """
                {
                    "classname": "RangeRule",
                    "message": "Value out of range"
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<ValidationRuleDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("RangeRule", descriptor.ClassName);
            Assert.Equal("Value out of range", descriptor.Message);
        }
    }
}
