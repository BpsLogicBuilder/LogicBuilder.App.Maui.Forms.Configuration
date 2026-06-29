using System.Collections.Generic;

namespace LogicBuilder.App.Maui.Forms.Configuration.SearchForm
{
    public class SearchFilterGroupDescriptor(ICollection<SearchFilterDescriptorBase> filters) : SearchFilterDescriptorBase
    {
        public ICollection<SearchFilterDescriptorBase> Filters { get; } = filters;
    }
}
