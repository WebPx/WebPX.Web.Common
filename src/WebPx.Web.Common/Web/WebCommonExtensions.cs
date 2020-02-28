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
            services.TryAddSingleton<ISiteSettings, SiteSettings>();
            services.ConfigureOptions<SiteInfoConfiguration>();
            if (configure != null)
                services.Configure(configure);
            else
                services.Configure<SiteInfo>((o) =>
                {
                    o.Name = "WebSite";
                    o.Copyright = "Copyright &copy; {1} {0}. All rights reserved.";
                });
            return services;
        }
    }
}
