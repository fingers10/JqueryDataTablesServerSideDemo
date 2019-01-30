using System;

namespace AspNetCoreServerSide.Infrastructure
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SearchableDoubleAttribute : SearchableAttribute
    {
        public SearchableDoubleAttribute()
        {
            ExpressionProvider = new DoubleSearchExpressionProvider();
        }
    }
}
