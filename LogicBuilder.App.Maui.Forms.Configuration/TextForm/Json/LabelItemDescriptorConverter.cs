using LogicBuilder.Expressions.Utils.Json;

namespace LogicBuilder.App.Maui.Forms.Configuration.TextForm.Json
{
    public class LabelItemDescriptorConverter : JsonTypeConverter<LabelItemDescriptorBase>
    {
        public override string TypePropertyName => nameof(LabelItemDescriptorBase.TypeString);
    }
}
