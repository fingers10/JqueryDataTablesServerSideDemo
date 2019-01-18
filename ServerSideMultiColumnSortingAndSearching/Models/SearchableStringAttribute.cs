using Aetna.Informatics.DARTHWeb.Infrastructure;
using System;

namespace ServerSideMultiColumnSortingAndSearching.Models
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
