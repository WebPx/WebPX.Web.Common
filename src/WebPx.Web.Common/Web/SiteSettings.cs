using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebPx.Web
{
    public class SiteSettings : ISiteSettings
    {
        public SiteSettings(IOptions<SiteInfo> siteInfoOptions)
        {
            SiteInfo = siteInfoOptions.Value;
        }

        public SiteInfo SiteInfo { get; }
    }
}
