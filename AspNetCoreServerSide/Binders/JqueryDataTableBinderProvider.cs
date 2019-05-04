using JqueryDataTables.ServerSide.AspNetCoreWeb;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AspNetCoreServerSide.Binders
{
    public class JqueryDataTableBinderProvider:IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            return context.Metadata.ModelType == typeof(DTParameters) ? new JqueryDataTableBinder() : null;
        }
    }
}
