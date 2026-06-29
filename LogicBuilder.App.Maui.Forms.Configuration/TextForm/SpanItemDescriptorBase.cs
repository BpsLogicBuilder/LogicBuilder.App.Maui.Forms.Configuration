using LogicBuilder.App.Maui.Forms.Configuration.TextForm.Json;
using System.Text.Json.Serialization;

namespace LogicBuilder.App.Maui.Forms.Configuration.TextForm
{
    [JsonConverter(typeof(SpanItemDescriptorConverter))]
    public abstract class SpanItemDescriptorBase
    {
        public string TypeString => this.GetType().AssemblyQualifiedName;
    }
}
