using System;

namespace ServerSideMultiColumnSortingAndSearching.Models
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
