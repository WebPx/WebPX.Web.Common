using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPx.Web.TagHelpers
{
    public static class TagHelperExtesions
    {
        public static void SetClasses(this TagHelperOutput output, IEnumerable<string> primaryClasses)
        {
            var _class = ((HtmlString)output.Attributes["class"]?.Value)?.Value;
            var classes = new List<string>(primaryClasses);
            if (!string.IsNullOrEmpty(_class))
                classes.Add(_class);
            output.Attributes.SetAttribute("class", string.Join(" ", classes));
        }

        public static void AppendClass(this TagHelperOutput output, string @class)
        {
            if (string.IsNullOrEmpty(@class))
                return;
            var _class = output.Attributes["class"]?.Value?.ToString() ?? null;
            if (_class == null)
                output.Attributes.SetAttribute("class", @class);
            else
                output.Attributes.SetAttribute("class", $"{_class} {@class}");
        }

        /// <summary>
        /// Set a Default value for the <paramref name="class"/> attribute if there is no value already set.
        /// </summary>
        /// <param name="output">The output context of the TagHelper</param>
        /// <param name="class">The default class value</param>
        public static void SetDefaultClass(this TagHelperOutput output, string @class)
        {
            if (string.IsNullOrEmpty(@class))
                return;
            if (string.IsNullOrEmpty(output.Attributes["class"]?.Value?.ToString() ?? null))
                output.Attributes.Add("class", @class);
        }

        /// <summary>
        /// Set a Default value for the <paramref name="class"/> attribute if there is no value already set.
        /// </summary>
        /// <param name="output">The output context of the TagHelper</param>
        /// <param name="class">The default class value</param>
        public static void SetClass(this TagHelperOutput output, string @class)
        {
            if (string.IsNullOrEmpty(@class))
                return;
            if (string.IsNullOrEmpty(output.Attributes["class"]?.Value?.ToString() ?? null))
                output.Attributes.SetAttribute("class", @class);
        }

        /// <summary>
        /// Set a Default <paramref name="value"/> for the <paramref name="attribute"/> attribute if there is no value already set.
        /// </summary>
        /// <param name="output">The output context of the TagHelper</param>
        /// <param name="attribute">The HTML attribute name</param>
        /// <param name="value">The default value</param>
        public static void SetDefault(this TagHelperOutput output, string attribute, string value)
        {
            if (string.IsNullOrEmpty(attribute))
                throw new ArgumentNullException(nameof(attribute));
            if (string.IsNullOrEmpty(output.Attributes[attribute]?.Value.ToString() ?? null))
                output.Attributes.Add(attribute, value);
        }
    }
}
