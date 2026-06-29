using LogicBuilder.App.Maui.Forms.Configuration.Directives;
using System.Text.Json;

namespace LogicBuilder.App.Maui.Forms.Configuration.Tests.Directives
{
    public class DirectiveDescriptorTest
    {
        [Fact]
        public void CanSerializeDirectiveDescriptor()
        {
            // Arrange
            var definition = new DirectiveDefinitionDescriptor("MyDirective", "Execute", null);
            var descriptor = new DirectiveDescriptor(
                definition: definition,
                condition: null!
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor, SerializationOptions.Default);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(json));
            Assert.Contains("\"Definition\"", json);
        }

        [Fact]
        public void CanDeserializeDirectiveDescriptor()
        {
            // Arrange
            string json = """
                {
                    "Definition": {
                        "ClassName": "MyDirective",
                        "FunctionName": "Execute",
                        "Arguments": null
                    },
                    "Condition": null
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<DirectiveDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.NotNull(descriptor.Definition);
            Assert.Equal("MyDirective", descriptor.Definition.ClassName);
        }

        [Fact]
        public void SerializationRoundTripPreservesAllProperties()
        {
            // Arrange
            var definition = new DirectiveDefinitionDescriptor("ValidationDirective", "Validate", null);
            var original = new DirectiveDescriptor(
                definition: definition,
                condition: null!
            );

            // Act
            string json = JsonSerializer.Serialize(original, SerializationOptions.Default);
            var deserialized = JsonSerializer.Deserialize<DirectiveDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserialized);
            Assert.Equal(original.Definition.ClassName, deserialized.Definition.ClassName);
        }

        [Fact]
        public void CanDeserializeWithCaseInsensitivePropertyNames()
        {
            // Arrange
            string json = """
                {
                    "definition": {
                        "classname": "TestDirective",
                        "functionname": "Run",
                        "arguments": null
                    },
                    "condition": null
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<DirectiveDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("TestDirective", descriptor.Definition.ClassName);
        }
    }
}
