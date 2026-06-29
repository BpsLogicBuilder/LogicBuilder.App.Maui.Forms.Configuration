using System.Text.Json;

namespace LogicBuilder.App.Maui.Forms.Configuration.Tests
{
    public class CommandButtonDescriptorTest
    {
        [Fact]
        public void CanSerializeCommandButtonDescriptor()
        {
            // Arrange
            var descriptor = new CommandButtonDescriptor(
                id: 1,
                shortString: "Save",
                longString: "Save Document",
                command: "SaveCommand",
                buttonIcon: "save.png"
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor, SerializationOptions.Default);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(json));
            Assert.Contains("\"Id\"", json);
            Assert.Contains("\"ShortString\"", json);
            Assert.Contains("\"LongString\"", json);
            Assert.Contains("\"Command\"", json);
            Assert.Contains("\"ButtonIcon\"", json);
        }

        [Fact]
        public void CanDeserializeCommandButtonDescriptor()
        {
            // Arrange
            string json = """
                {
                    "Id": 1,
                    "ShortString": "Save",
                    "LongString": "Save Document",
                    "Command": "SaveCommand",
                    "ButtonIcon": "save.png"
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<CommandButtonDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal(1, descriptor.Id);
            Assert.Equal("Save", descriptor.ShortString);
            Assert.Equal("Save Document", descriptor.LongString);
            Assert.Equal("SaveCommand", descriptor.Command);
            Assert.Equal("save.png", descriptor.ButtonIcon);
        }

        [Fact]
        public void SerializationRoundTripPreservesAllProperties()
        {
            // Arrange
            var original = new CommandButtonDescriptor(
                id: 42,
                shortString: "Delete",
                longString: "Delete Selected Items",
                command: "DeleteCommand",
                buttonIcon: "delete.png"
            );

            // Act
            string json = JsonSerializer.Serialize(original, SerializationOptions.Default);
            var deserialized = JsonSerializer.Deserialize<CommandButtonDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserialized);
            Assert.Equal(original.Id, deserialized.Id);
            Assert.Equal(original.ShortString, deserialized.ShortString);
            Assert.Equal(original.LongString, deserialized.LongString);
            Assert.Equal(original.Command, deserialized.Command);
            Assert.Equal(original.ButtonIcon, deserialized.ButtonIcon);
        }

        [Fact]
        public void CanDeserializeWithCaseInsensitivePropertyNames()
        {
            // Arrange
            string json = """
                {
                    "id": 5,
                    "shortstring": "Edit",
                    "longstring": "Edit Document",
                    "command": "EditCommand",
                    "buttonicon": "edit.png"
                }
                """;

            // Act
            var descriptor = JsonSerializer.Deserialize<CommandButtonDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal(5, descriptor.Id);
            Assert.Equal("Edit", descriptor.ShortString);
            Assert.Equal("Edit Document", descriptor.LongString);
            Assert.Equal("EditCommand", descriptor.Command);
            Assert.Equal("edit.png", descriptor.ButtonIcon);
        }

        [Fact]
        public void CanSerializeCommandButtonDescriptorWithEmptyStrings()
        {
            // Arrange
            var descriptor = new CommandButtonDescriptor(
                id: 0,
                shortString: "",
                longString: "",
                command: "",
                buttonIcon: ""
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor, SerializationOptions.Default);
            var deserialized = JsonSerializer.Deserialize<CommandButtonDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserialized);
            Assert.Equal(0, deserialized.Id);
            Assert.Equal("", deserialized.ShortString);
            Assert.Equal("", deserialized.LongString);
            Assert.Equal("", deserialized.Command);
            Assert.Equal("", deserialized.ButtonIcon);
        }

        [Fact]
        public void CanSerializeCommandButtonDescriptorWithSpecialCharacters()
        {
            // Arrange
            var descriptor = new CommandButtonDescriptor(
                id: 99,
                shortString: "Test \"Quotes\"",
                longString: "Test with\nnewline and\ttab",
                command: "Command\\Path",
                buttonIcon: "icon/path/file.png"
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor, SerializationOptions.Default);
            var deserialized = JsonSerializer.Deserialize<CommandButtonDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserialized);
            Assert.Equal(descriptor.Id, deserialized.Id);
            Assert.Equal(descriptor.ShortString, deserialized.ShortString);
            Assert.Equal(descriptor.LongString, deserialized.LongString);
            Assert.Equal(descriptor.Command, deserialized.Command);
            Assert.Equal(descriptor.ButtonIcon, deserialized.ButtonIcon);
        }
    }
}
