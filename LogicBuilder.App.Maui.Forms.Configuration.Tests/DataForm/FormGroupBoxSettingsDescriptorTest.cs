using LogicBuilder.App.Maui.Forms.Configuration.DataForm;
using System.Collections.Generic;
using System.Text.Json;

namespace LogicBuilder.App.Maui.Forms.Configuration.Tests.DataForm
{
    public class FormGroupBoxSettingsDescriptorTest
    {
        [Fact]
        public void CanSerializeFormGroupBoxSettingsDescriptor()
        {
            // Arrange
            var descriptor = new FormGroupBoxSettingsDescriptor(
                groupHeader: "Personal Information",
                fieldSettings: [],
                headerBindings: null,
                isHidden: false
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor, SerializationOptions.Default);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(json));
            Assert.Contains("\"GroupHeader\"", json);
            Assert.Contains("\"FieldSettings\"", json);
            Assert.Contains("\"IsHidden\"", json);
        }

        [Fact]
        public void CanDeserializeFormGroupBoxSettingsDescriptor()
        {
            // Arrange
            string json = """
                {
                    "GroupHeader": "Personal Information",
                    "FieldSettings": [],
                    "HeaderBindings": null,
                    "IsHidden": false
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<FormGroupBoxSettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("Personal Information", descriptor.GroupHeader);
            Assert.NotNull(descriptor.FieldSettings);
            Assert.False(descriptor.IsHidden);
        }

        [Fact]
        public void SerializationRoundTripPreservesAllProperties()
        {
            // Arrange
            var headerBindings = new MultiBindingDescriptor("{0}", ["Name"], null);
            var original = new FormGroupBoxSettingsDescriptor(
                groupHeader: "Contact Information",
                fieldSettings: [],
                headerBindings: headerBindings,
                isHidden: true
            );

            // Act
            string json = JsonSerializer.Serialize(original, SerializationOptions.Default);
            var deserialized = JsonSerializer.Deserialize<FormGroupBoxSettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserialized);
            Assert.Equal(original.GroupHeader, deserialized.GroupHeader);
            Assert.Equal(original.IsHidden, deserialized.IsHidden);
        }

        [Fact]
        public void CanDeserializeWithCaseInsensitivePropertyNames()
        {
            // Arrange
            string json = """
                {
                    "groupheader": "Address Information",
                    "fieldsettings": [],
                    "ishidden": false
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<FormGroupBoxSettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal("Address Information", descriptor.GroupHeader);
        }
    }
}
