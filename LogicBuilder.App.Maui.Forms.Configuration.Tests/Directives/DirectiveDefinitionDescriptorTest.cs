using LogicBuilder.App.Maui.Forms.Configuration.Directives;
using System.Collections.Generic;
using System.Text.Json;

namespace LogicBuilder.App.Maui.Forms.Configuration.Tests.Directives
{
    public class DirectiveDefinitionDescriptorTest
    {
        [Fact]
        public void CanSerializeDirectiveDefinitionDescriptor()
        {
            // Arrange
            var arguments = new Dictionary<string, DirectiveArgumentDescriptor>
            {
                { "arg1", new DirectiveArgumentDescriptor("arg1", "value1", "string") }
            };
            var descriptor = new DirectiveDefinitionDescriptor(
                className: "MyDirective",
                functionName: "Execute",
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
        public void CanDeserializeDirectiveDefinitionDescriptor()
        {
            // Arrange
            string json = """
                {
                    "ClassName": "MyDirective",
                    "FunctionName": "Execute",
                    "Arguments": {
                        "arg1": {
                            "Name": "arg1",
                            "Value": "value1",
                            "Type": "string"
                        }
                    }
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<DirectiveDefinitionDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("MyDirective", descriptor.ClassName);
            Assert.Equal("Execute", descriptor.FunctionName);
            Assert.NotNull(descriptor.Arguments);
            Assert.Single(descriptor.Arguments);
        }

        [Fact]
        public void SerializationRoundTripPreservesAllProperties()
        {
            // Arrange
            var original = new DirectiveDefinitionDescriptor(
                className: "ValidationDirective",
                functionName: "Validate",
                arguments: null
            );

            // Act
            string json = JsonSerializer.Serialize(original, SerializationOptions.Default);
            var deserialized = JsonSerializer.Deserialize<DirectiveDefinitionDescriptor>(json, SerializationOptions.Default);

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
                    "classname": "TestDirective",
                    "functionname": "Run",
                    "arguments": null
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<DirectiveDefinitionDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("TestDirective", descriptor.ClassName);
            Assert.Equal("Run", descriptor.FunctionName);
        }
    }
}
