using System;

namespace ServerSideMultiColumnSortingAndSearching.Infrastructure
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SearchableIntAttribute : SearchableAttribute
    {
        public SearchableIntAttribute()
        {
            ExpressionProvider = new IntSearchExpressionProvider();
        }
    }
}
