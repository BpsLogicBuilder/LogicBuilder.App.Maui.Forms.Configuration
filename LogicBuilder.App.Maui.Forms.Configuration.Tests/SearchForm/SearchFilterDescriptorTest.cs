using LogicBuilder.App.Maui.Forms.Configuration.SearchForm;
using System.Text.Json;

namespace LogicBuilder.App.Maui.Forms.Configuration.Tests.SearchForm
{
    public class SearchFilterDescriptorTest
    {
        [Fact]
        public void CanSerializeSearchFilterDescriptor()
        {
            // Arrange
            var descriptor = new SearchFilterDescriptor(
                field: "Name",
                fieldTypeSource: null
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor, SerializationOptions.Default);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(json));
            Assert.Contains("\"Field\"", json);
        }

        [Fact]
        public void CanDeserializeSearchFilterDescriptor()
        {
            // Arrange
            string json = """
                {
                    "TypeString": "LogicBuilder.App.Maui.Forms.Configuration.SearchForm.SearchFilterDescriptor, LogicBuilder.App.Maui.Forms.Configuration",
                    "Field": "Name",
                    "FieldTypeSource": null
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<SearchFilterDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("Name", descriptor.Field);
            Assert.Null(descriptor.FieldTypeSource);
        }

        [Fact]
        public void SerializationRoundTripPreservesAllProperties()
        {
            // Arrange
            var original = new SearchFilterDescriptor(
                field: "Email",
                fieldTypeSource: "StringType"
            );

            // Act
            string json = JsonSerializer.Serialize(original, SerializationOptions.Default);
            var deserialized = JsonSerializer.Deserialize<SearchFilterDescriptor>(json, SerializationOptions.Default);

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
                    "fieldtypesource": null
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<SearchFilterDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("Phone", descriptor.Field);
        }
    }
}
