using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPx.Web
{
    internal static class SkinExtensions
    {
        public static TOption Find<TOption>(this TOption[] options, string name = "Default")
            where TOption : Skin
        {
            foreach (var option in options)
                if (string.Equals(option.Name, name, StringComparison.OrdinalIgnoreCase))
                    return option;
            return null;
        }

        public static bool TryMerge<TOption>(this TOption options, TOption other)
            where TOption : Skin
        {
            if (options is IMergeable<TOption> merger)
            {
                merger.Merge(other);
                return true;
            }
            else if (options is IMergeable merger2)
            {
                merger2.Merge(other);
                return true;
            }
            return false;
        }
    }
}
