using System;

namespace AspNetCoreServerSide.Infrastructure
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SearchableShortAttribute : SearchableAttribute
    {
        public SearchableShortAttribute()
        {
            ExpressionProvider = new ShortSearchExpressionProvider();
        }
    }
}
