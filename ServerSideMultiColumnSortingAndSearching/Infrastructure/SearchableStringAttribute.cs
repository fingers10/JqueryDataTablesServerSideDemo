using System;

namespace ServerSideMultiColumnSortingAndSearching.Infrastructure
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SearchableStringAttribute : SearchableAttribute
    {
        public SearchableStringAttribute()
        {
            ExpressionProvider = new StringSearchExpressionProvider();
        }
    }
}
