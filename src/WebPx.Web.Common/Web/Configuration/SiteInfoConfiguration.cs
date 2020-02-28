using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebPx.Web.Configuration
{
    public sealed class SiteInfoConfiguration : IConfigureOptions<SiteInfo>
    {
        public SiteInfoConfiguration(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void Configure(SiteInfo options)
        {
            Configuration.GetSection("SiteInfo")?.Bind(options);
        }
    }
}
