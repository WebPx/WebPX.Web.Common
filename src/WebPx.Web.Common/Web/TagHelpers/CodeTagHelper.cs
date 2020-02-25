using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebPx.Web.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("code", Attributes = "raw")]
    public class CodeTagHelper : TagHelper
    {
        public CodeTagHelper()
        {
            
        }

        public bool Raw { get; set; } = true;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.Append(output.GetChildContentAsync().Result.GetContent());
        }
    }
}
