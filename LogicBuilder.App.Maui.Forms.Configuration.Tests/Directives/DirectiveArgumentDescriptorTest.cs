using LogicBuilder.App.Maui.Forms.Configuration.Directives;
using System.Text.Json;

namespace LogicBuilder.App.Maui.Forms.Configuration.Tests.Directives
{
    public class DirectiveArgumentDescriptorTest
    {
        [Fact]
        public void CanSerializeDirectiveArgumentDescriptor()
        {
            // Arrange
            var descriptor = new DirectiveArgumentDescriptor(
                name: "arg1",
                value: "testValue",
                type: "string"
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
        public void CanDeserializeDirectiveArgumentDescriptor()
        {
            // Arrange
            string json = """
                {
                    "Name": "arg1",
                    "Value": "testValue",
                    "Type": "string"
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<DirectiveArgumentDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("arg1", descriptor.Name);
            Assert.Equal("testValue", descriptor.Value.ToString());
            Assert.Equal("string", descriptor.Type);
        }

        [Fact]
        public void SerializationRoundTripPreservesAllProperties()
        {
            // Arrange
            var original = new DirectiveArgumentDescriptor(
                name: "count",
                value: 42,
                type: "int"
            );

            // Act
            string json = JsonSerializer.Serialize(original, SerializationOptions.Default);
            var deserialized = JsonSerializer.Deserialize<DirectiveArgumentDescriptor>(json, SerializationOptions.Default);

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
                    "name": "enabled",
                    "value": true,
                    "type": "bool"
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<DirectiveArgumentDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("enabled", descriptor.Name);
            Assert.Equal("bool", descriptor.Type);
        }
    }
}
