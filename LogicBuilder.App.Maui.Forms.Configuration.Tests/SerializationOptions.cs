using LogicBuilder.App.Maui.Forms.Configuration.SearchForm.Json;
using LogicBuilder.App.Maui.Forms.Configuration.TextForm.Json;
using LogicBuilder.Expressions.Utils.Json;
using System.Text.Json;

namespace LogicBuilder.App.Maui.Forms.Configuration.Tests
{
    public static class SerializationOptions
    {
        private static readonly JsonSerializerOptions _default = CreateSerializationOptions();

        public static JsonSerializerOptions Default
        {
            get
            {
                return _default;
            }
        }

        static JsonSerializerOptions CreateSerializationOptions()
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            options.Converters.Add(new DescriptorConverter());
            options.Converters.Add(new LabelItemDescriptorConverter());
            options.Converters.Add(new SearchFilterDescriptorConverter());
            options.Converters.Add(new SpanItemDescriptorConverter());
            return options;
        }
    }
}
