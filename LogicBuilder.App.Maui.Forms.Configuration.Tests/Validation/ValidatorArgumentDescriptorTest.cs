using LogicBuilder.App.Maui.Forms.Configuration.Validation;
using System.Text.Json;

namespace LogicBuilder.App.Maui.Forms.Configuration.Tests.Validation
{
    public class ValidatorArgumentDescriptorTest
    {
        [Fact]
        public void CanSerializeValidatorArgumentDescriptor()
        {
            // Arrange
            var descriptor = new ValidatorArgumentDescriptor(
                name: "minLength",
                value: 5,
                type: "int"
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor, SerializationOptions.Default);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(json));
            Assert.Contains("\"Name\"", json);
            Assert.Contains("\"Value\"", json);
            Assert.Contains("\"Type\"", json);
        }

        [Fact]
        public void CanDeserializeValidatorArgumentDescriptor()
        {
            // Arrange
            string json = """
                {
                    "Name": "minLength",
                    "Value": 5,
                    "Type": "int"
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<ValidatorArgumentDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("minLength", descriptor.Name);
            Assert.Equal("int", descriptor.Type);
        }

        [Fact]
        public void SerializationRoundTripPreservesAllProperties()
        {
            // Arrange
            var original = new ValidatorArgumentDescriptor(
                name: "pattern",
                value: "[A-Za-z]+",
                type: "string"
            );

            // Act
            string json = JsonSerializer.Serialize(original, SerializationOptions.Default);
            var deserialized = JsonSerializer.Deserialize<ValidatorArgumentDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserialized);
            Assert.Equal(original.Name, deserialized.Name);
            Assert.Equal(original.Type, deserialized.Type);
        }

        [Fact]
        public void CanDeserializeWithCaseInsensitivePropertyNames()
        {
            // Arrange
            string json = """
                {
                    "name": "maxLength",
                    "value": 100,
                    "type": "int"
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<ValidatorArgumentDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("maxLength", descriptor.Name);
            Assert.Equal("int", descriptor.Type);
        }
    }
}
