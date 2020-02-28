using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebPx.Web.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement(Attributes = "condition")]
    public class ConditionalTagHelper : TagHelper
    {
        public ConditionalTagHelper()
        {

        }

        [HtmlAttributeName("condition")]
        public bool Condition { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!Condition)
                output.SuppressOutput();
        }
    }
}
