
using System;

namespace ServerSideMultiColumnSortingAndSearching.Models
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
