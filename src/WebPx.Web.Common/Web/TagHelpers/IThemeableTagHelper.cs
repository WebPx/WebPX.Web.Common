using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace WebPx.Web.TagHelpers
{
    public interface IThemeableTagHelper
    {
        void DoProcess(TagHelperContext context, TagHelperOutput output);
        Task DoProcessAsync(TagHelperContext context, TagHelperOutput output);
    }
}
