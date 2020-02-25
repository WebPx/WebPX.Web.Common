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
            services.AddTransient<ITagHelperAdapter, DefaultTagHelperAdapter>();
            services.AddSingleton<AdapterResolver>();
            return services;
        }
    }
}
