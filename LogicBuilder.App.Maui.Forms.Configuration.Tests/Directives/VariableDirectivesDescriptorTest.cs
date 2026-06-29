using LogicBuilder.App.Maui.Forms.Configuration.Directives;
using System.Collections.Generic;
using System.Text.Json;

namespace LogicBuilder.App.Maui.Forms.Configuration.Tests.Directives
{
    public class VariableDirectivesDescriptorTest
    {
        [Fact]
        public void CanSerializeVariableDirectivesDescriptor()
        {
            // Arrange
            var definition = new DirectiveDefinitionDescriptor("MyDirective", "Execute", null);
            var directive = new DirectiveDescriptor(definition, null!);
            var descriptor = new VariableDirectivesDescriptor(
                field: "Name",
                conditionalDirectives: [directive],
                fieldTypeSource: null
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor, SerializationOptions.Default);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(json));
            Assert.Contains("\"Field\"", json);
            Assert.Contains("\"ConditionalDirectives\"", json);
        }

        [Fact]
        public void CanDeserializeVariableDirectivesDescriptor()
        {
            // Arrange
            string json = """
                {
                    "Field": "Name",
                    "ConditionalDirectives": [
                        {
                            "Definition": {
                                "ClassName": "MyDirective",
                                "FunctionName": "Execute",
                                "Arguments": null
                            },
                            "Condition": null
                        }
                    ],
                    "FieldTypeSource": null
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<VariableDirectivesDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("Name", descriptor.Field);
            Assert.NotNull(descriptor.ConditionalDirectives);
            Assert.Single(descriptor.ConditionalDirectives);
        }

        [Fact]
        public void SerializationRoundTripPreservesAllProperties()
        {
            // Arrange
            var original = new VariableDirectivesDescriptor(
                field: "Email",
                conditionalDirectives: [],
                fieldTypeSource: "StringType"
            );

            // Act
            string json = JsonSerializer.Serialize(original, SerializationOptions.Default);
            var deserialized = JsonSerializer.Deserialize<VariableDirectivesDescriptor>(json, SerializationOptions.Default);

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
                    "conditionaldirectives": [],
                    "fieldtypesource": null
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<VariableDirectivesDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("Phone", descriptor.Field);
        }
    }
}
