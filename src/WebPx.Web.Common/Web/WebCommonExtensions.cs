using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using WebPx.Web;
using WebPx.Web.Configuration;
using WebPx.Web.TagHelpers;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class WebCommonExtensions
    {
        /// <summary>
        /// Adds ServiceWorker services to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        public static IServiceCollection AddTagHelperAdapters(this IServiceCollection services)
        {
            services.TryAddTransient<ITagHelperAdapter, DefaultTagHelperAdapter>();
            services.TryAddSingleton<AdapterResolver>();
            return services;
        }

        public static IServiceCollection AddSiteFeatures(this IServiceCollection services, Action<SiteInfo> configure = null)
        {
            services.AddTagHelperAdapters();
            services.TryAddScoped<ISiteSettings, SiteSettings>();
            services.ConfigureOptions<SiteInfoConfiguration>();
            if (configure != null)
                services.Configure(configure);
            return services;
        }
    }
}
