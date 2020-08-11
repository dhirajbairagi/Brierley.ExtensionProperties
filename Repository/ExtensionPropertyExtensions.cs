using Brierley.ExtensionPropertyManager.ExtensionManagers;
using ExtensionPropertyFramework.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Brierley.ExtensionPropertyManager
{
    public static class ExtensionPropertyExtensions<TContext> where TContext : ExtensionPropertyDbContext<TContext>
    {
        public static void AddExtensionProperties(IServiceCollection services)
        {
            ServiceCollectionServiceExtensions.AddTransient<IAttributeMetadataSetManager<TContext>, AttributeMetadataSetManager<TContext>>(services) ;
            ServiceCollectionServiceExtensions.AddTransient<IExtensionPropertyManager<TContext>, ExtensionPropertyManager<TContext>>(services);
        }
    }
}
