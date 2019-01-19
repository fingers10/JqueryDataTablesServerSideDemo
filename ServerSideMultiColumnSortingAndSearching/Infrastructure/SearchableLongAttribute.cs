using System;

namespace ServerSideMultiColumnSortingAndSearching.Infrastructure
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SearchableLongAttribute : SearchableAttribute
    {
        public SearchableLongAttribute()
        {
            ExpressionProvider = new LongSearchExpressionProvider();
        }
    }
}
