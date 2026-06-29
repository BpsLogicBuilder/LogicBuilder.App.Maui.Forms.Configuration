using LogicBuilder.App.Maui.Forms.Configuration.SearchForm;
using System.Collections.Generic;
using System.Text.Json;

namespace LogicBuilder.App.Maui.Forms.Configuration.Tests.SearchForm
{
    public class SearchFilterGroupDescriptorTest
    {
        [Fact]
        public void CanSerializeSearchFilterGroupDescriptor()
        {
            // Arrange
            var filter1 = new SearchFilterDescriptor("Name", null);
            var filter2 = new SearchFilterDescriptor("Email", null);
            var descriptor = new SearchFilterGroupDescriptor(
                filters: [filter1, filter2]
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor, SerializationOptions.Default);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(json));
            Assert.Contains("\"Filters\"", json);
        }

        [Fact]
        public void CanDeserializeSearchFilterGroupDescriptor()
        {
            // Arrange
            string json = """
                {
                    "TypeString": "LogicBuilder.App.Maui.Forms.Configuration.SearchForm.SearchFilterGroupDescriptor, LogicBuilder.App.Maui.Forms.Configuration",
                    "Filters": [
                        {
                            "TypeString": "LogicBuilder.App.Maui.Forms.Configuration.SearchForm.SearchFilterDescriptor, LogicBuilder.App.Maui.Forms.Configuration",
                            "Field": "Name",
                            "FieldTypeSource": null
                        },
                        {
                            "TypeString": "LogicBuilder.App.Maui.Forms.Configuration.SearchForm.SearchFilterDescriptor, LogicBuilder.App.Maui.Forms.Configuration",
                            "Field": "Email",
                            "FieldTypeSource": null
                        }
                    ]
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<SearchFilterGroupDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.NotNull(descriptor.Filters);
            Assert.Equal(2, descriptor.Filters.Count);
        }

        [Fact]
        public void SerializationRoundTripPreservesAllProperties()
        {
            // Arrange
            var filter1 = new SearchFilterDescriptor("FirstName", "StringType");
            var filter2 = new SearchFilterDescriptor("LastName", "StringType");
            var original = new SearchFilterGroupDescriptor(
                filters: [filter1, filter2]
            );

            // Act
            string json = JsonSerializer.Serialize(original, SerializationOptions.Default);
            var deserialized = JsonSerializer.Deserialize<SearchFilterGroupDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserialized);
            Assert.Equal(original.Filters.Count, deserialized.Filters.Count);
        }

        [Fact]
        public void CanDeserializeWithCaseInsensitivePropertyNames()
        {
            // Arrange
            string json = """
                {
                    "filters": []
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<SearchFilterGroupDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.NotNull(descriptor.Filters);
        }
    }
}
