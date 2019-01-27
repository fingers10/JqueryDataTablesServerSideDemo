using AspNetCoreServerSide.Contracts;
using System;

namespace AspNetCoreServerSide.Infrastructure
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SearchableAttribute : Attribute
    {
        public string EntityProperty { get; set; }

        public ISearchExpressionProvider ExpressionProvider { get; set; }
            = new DefaultSearchExpressionProvider();
    }
}
