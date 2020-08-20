using Brierley.ExtensionPropertyManager.ExtensionManagers;
using Brierley.ExtensionPropertyManager.Interfaces;
using ExtensionPropertyFramework.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Brierley.ExtensionPropertyManager
{
    public static class ExtensionManager<TContext> where TContext : ExtensionPropertyDbContext<TContext>
    {
        public static void AddExtensionProperties(IServiceCollection services)
        {
            services.AddTransient<IAttributeMetadataSetManager<TContext>, AttributeMetadataSetManager<TContext>>();
            services.AddTransient<IExtensionPropertyManager<TContext>, ExtensionPropertyManager<TContext>>();
            services.AddTransient<IAttributeMetadataPropertyManager<TContext>, AttributeMetadataPropertyManager<TContext>>();
        }
    }
}
