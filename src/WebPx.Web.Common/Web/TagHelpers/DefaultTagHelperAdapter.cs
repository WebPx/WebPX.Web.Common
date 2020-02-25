using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace WebPx.Web.TagHelpers
{
    public class DefaultTagHelperAdapter : ITagHelperAdapter
    {
        public DefaultTagHelperAdapter()
        {

        }

        public IThemeableTagHelper TagHelper { get; set; }

        public virtual void DoProcess(TagHelperContext context, TagHelperOutput output)
        {
            TagHelper.DoProcess(context, output);
        }

        public virtual Task DoProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            return TagHelper.DoProcessAsync(context, output);
        }
    }
}
