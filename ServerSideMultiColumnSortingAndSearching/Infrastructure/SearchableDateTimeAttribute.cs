using System;

namespace ServerSideMultiColumnSortingAndSearching.Infrastructure
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SearchableDateTimeAttribute : SearchableAttribute
    {
        public SearchableDateTimeAttribute()
        {
            ExpressionProvider = new DateTimeSearchExpressionProvider();
        }
    }
}
