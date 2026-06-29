using LogicBuilder.Expressions.Utils.Json;

namespace LogicBuilder.App.Maui.Forms.Configuration.SearchForm.Json
{
    public class SearchFilterDescriptorConverter : JsonTypeConverter<SearchFilterDescriptorBase>
    {
        public override string TypePropertyName => nameof(SearchFilterDescriptorBase.TypeString);
    }
}
