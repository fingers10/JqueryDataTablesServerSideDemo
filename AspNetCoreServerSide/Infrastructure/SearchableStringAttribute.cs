using System;

namespace AspNetCoreServerSide.Infrastructure
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
