using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPx.Web.TagHelpers
{
    public interface ITagHelperAdapter
    {
        IThemeableTagHelper TagHelper { get; set; }
        void DoProcess(TagHelperContext context, TagHelperOutput output);
        Task DoProcessAsync(TagHelperContext context, TagHelperOutput output);
    }

    public interface ITagHelperAdapter<TTagHelper> : ITagHelper
        where TTagHelper : TagHelper, IThemeableTagHelper
    {
    }
}
