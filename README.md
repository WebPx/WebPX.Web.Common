# WebPX.Web.Common
ASP.NET Core Web Common Utilities
## Adding to your project
You can find it in https://www.nuget.org/packages/WebPx.Web.Common

Installing in VisualStudio: Install-Package WebPx.Web.Common
Installing in VisualStudio Code: dotnet add package WebPx.Web.Common

## Configuring your application

To add all features call **AddSiteFeatures** in Startup class

    services.AddSiteFeatures();

To add just the TagAdapter support you need to add to you Startup class

    services.AddTagHelperAdapters();

## Settings your Site information
You can configure the Site Info for your application in two ways:
- appsettings.json
- Startup Class

### appsettings.json

```
{
    "SiteInfo" : {
        "Name" : "WebPx AdminLTE Demo",
        "Copyright" : "Copyright &copy; {1} <a href='https://webpx.com'>{0}<a/>. All rights reserved."
    }
});
```

### Startup.cs

```
services.AddSiteFeatures((o) =>
{
    o.Name = "WebPx AdminLTE Demo"; 
    o.Copyright = "Copyright &copy; {1} <a href='https://webpx.com'>{0}<a/>. All rights reserved.";
});
```

## Using TagHelper Adapters

### Overriding the primary TagHelperAdapter
This should be done before calling *AddSiteFeatures*

    services.AddTransient<ITagHelperAdapter, DefaultTagHelperAdapter>();
    
### Overriding the specifig TagHelperAdapter

    services.AddTransient<ITagHelperAdapter<TagHelperType>, CustomTagHelperAdapter>();

## Change History
Version | Date | Description
--------|------|------------
0.9.2|28/02/2020|Added ConditionalTagHelper and Default Site Name and Copyright Notice for SiteInfo
0.9.1|27/02/2020|Added SiteInfo and SiteSettings for storing and managing 
0.9.0|25/02/2020|First Release with TagHelperAdapter and AdapterResolver
