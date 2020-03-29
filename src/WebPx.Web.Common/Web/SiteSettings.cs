using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebPx.Web
{
    public class SiteSettings : ISiteSettings
    {
        private readonly IOptionsSnapshot<SiteInfo> SiteInfoSnapshot;

        public SiteSettings(IOptionsSnapshot<SiteInfo> siteInfoOptions)
        {
            SiteInfoSnapshot = siteInfoOptions;
        }

        public SiteInfo SiteInfo => SiteInfoSnapshot.Value;
    }
}
