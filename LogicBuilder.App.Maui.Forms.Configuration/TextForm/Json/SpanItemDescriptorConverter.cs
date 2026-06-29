using LogicBuilder.Expressions.Utils.Json;

namespace LogicBuilder.App.Maui.Forms.Configuration.TextForm.Json
{
    public class SpanItemDescriptorConverter : JsonTypeConverter<SpanItemDescriptorBase>
    {
        public override string TypePropertyName => nameof(SpanItemDescriptorBase.TypeString);
    }
}
