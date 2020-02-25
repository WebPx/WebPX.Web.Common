using Microsoft.Extensions.DependencyInjection;
using System;

namespace WebPx.Web.TagHelpers
{
    public sealed class AdapterResolver
    {
        private readonly IServiceProvider ServiceProvider;

        public AdapterResolver(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        internal ITagHelperAdapter ResolveAdapter(Type type, IThemeableTagHelper themeableTagHelper)
        {
            var gen = (ITagHelperAdapter)ServiceProvider.GetService(typeof(ITagHelperAdapter<>).MakeGenericType(type));
            var adapter = gen ?? ServiceProvider.GetService<ITagHelperAdapter>();
            adapter.TagHelper = themeableTagHelper;
            return adapter;
        }
    }
}
