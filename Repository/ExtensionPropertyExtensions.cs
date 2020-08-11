using Brierley.ExtensionPropertyManager.ExtensionManagers;
using ExtensionPropertyFramework.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Brierley.ExtensionPropertyManager
{
    public static class ExtensionPropertyExtensions
    {
        public static void AddExtensionProperties(this IServiceCollection services)
        {
            //ServiceCollectionServiceExtensions.AddTransient<IExtensionDomainManager, ExtensionDomainManager>(services);
            ServiceCollectionServiceExtensions.AddTransient<IExtensionPropertyManager, ExtensionManagers.ExtensionPropertyManager>(services);
        }
    }
}
