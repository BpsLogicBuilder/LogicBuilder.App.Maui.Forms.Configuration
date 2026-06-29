using System.Collections.Generic;

namespace LogicBuilder.App.Maui.Forms.Configuration
{
    public class MultiBindingDescriptor(string stringFormat, List<string> fields, string? fieldTypeSource)
    {
        public string StringFormat { get; } = stringFormat;
        public List<string> Fields { get; } = fields;
        public string? FieldTypeSource { get; } = fieldTypeSource;
    }
}
