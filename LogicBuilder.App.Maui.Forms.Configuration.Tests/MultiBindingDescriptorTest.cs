using System.Collections.Generic;
using System.Text.Json;

namespace LogicBuilder.App.Maui.Forms.Configuration.Tests
{
    public class MultiBindingDescriptorTest
    {
        [Fact]
        public void CanSerializeMultiBindingDescriptor()
        {
            // Arrange
            var descriptor = new MultiBindingDescriptor(
                stringFormat: "{0} - {1}",
                fields: ["FirstName", "LastName"],
                fieldTypeSource: "PersonType"
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor, SerializationOptions.Default);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(json));
            Assert.Contains("\"StringFormat\"", json);
            Assert.Contains("\"Fields\"", json);
            Assert.Contains("\"FieldTypeSource\"", json);
        }

        [Fact]
        public void CanDeserializeMultiBindingDescriptor()
        {
            // Arrange
            string json = """
                {
                    "StringFormat": "{0} - {1}",
                    "Fields": ["FirstName", "LastName"],
                    "FieldTypeSource": "PersonType"
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<MultiBindingDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("{0} - {1}", descriptor.StringFormat);
            Assert.Equal(2, descriptor.Fields.Count);
            Assert.Contains("FirstName", descriptor.Fields);
            Assert.Contains("LastName", descriptor.Fields);
            Assert.Equal("PersonType", descriptor.FieldTypeSource);
        }

        [Fact]
        public void SerializationRoundTripPreservesAllProperties()
        {
            // Arrange
            var original = new MultiBindingDescriptor(
                stringFormat: "{0} {1} {2}",
                fields: ["Title", "FirstName", "LastName"],
                fieldTypeSource: null
            );

            // Act
            string json = JsonSerializer.Serialize(original, SerializationOptions.Default);
            var deserialized = JsonSerializer.Deserialize<MultiBindingDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserialized);
            Assert.Equal(original.StringFormat, deserialized.StringFormat);
            Assert.Equal(original.Fields.Count, deserialized.Fields.Count);
            Assert.Equal(original.FieldTypeSource, deserialized.FieldTypeSource);
        }

        [Fact]
        public void CanDeserializeWithCaseInsensitivePropertyNames()
        {
            // Arrange
            string json = """
                {
                    "stringformat": "{0}",
                    "fields": ["Name"],
                    "fieldtypesource": "Type"
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<MultiBindingDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("{0}", descriptor.StringFormat);
            Assert.Single(descriptor.Fields);
            Assert.Equal("Type", descriptor.FieldTypeSource);
        }
    }
}
