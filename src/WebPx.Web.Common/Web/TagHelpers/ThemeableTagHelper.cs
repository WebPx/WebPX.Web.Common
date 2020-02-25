using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebPx.Web.TagHelpers
{
    public abstract class ThemeableTagHelper : ThemeableTagHelper<Skin>
    {
        public ThemeableTagHelper(AdapterResolver resolver) : base(resolver)
        {

        }
    }

    public abstract class ThemeableTagHelper<TOptions> : TagHelper, IThemeableTagHelper
        where TOptions : Skin
    {
        //private TOptions _settings;
        //private static TOptions _defaultSettings = null;
        private Func<TOptions[]> propFunc;

        public ThemeableTagHelper(AdapterResolver resolver)
        {
            this.Resolver = resolver;
            if (!_sharedInited.Contains(this.GetType()))
                SharedInit(this);
        }

        protected TOptions Settings { get; set; }

        protected TOptions DefaultSettings { get; private set; }

        public string Skin { get; set; }

        protected Func<TOptions[]> PropFunc { set => propFunc = value; }

        private AdapterResolver Resolver { get; }

        private ITagHelperAdapter _adapter;

        protected ITagHelperAdapter Adapter => _adapter ?? (_adapter = GetAdapter());

        private ITagHelperAdapter GetAdapter() => Resolver.ResolveAdapter(GetType(), this);

        public sealed override void Process(TagHelperContext context, TagHelperOutput output)
        {
            ApplySkin(context, output);
            Adapter.DoProcess(context, output);
        }

        public sealed override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            ApplySkin(context, output);
            await Adapter.DoProcessAsync(context, output);
        }


        private static readonly HashSet<Type> _sharedInited = new HashSet<Type>();

        protected internal static void SharedInit(ThemeableTagHelper<TOptions> tagHelper)
        {
            if (tagHelper.HasSettings)
                tagHelper.DefaultSettings = default;
            //if (_defaultSettings == null)
            else
                tagHelper.DefaultSettings = tagHelper.propFunc?.Invoke()?.Find("Default");
            _sharedInited.Add(tagHelper.GetType());
        }

        protected virtual bool HasSettings { get => false; }

        public override void Init(TagHelperContext context)
        {
            base.Init(context);
            BuildSkin();
        }

        protected virtual void BuildSkin()
        {
            var skinName = Skin;
            if (!string.IsNullOrEmpty(skinName))
            {
                var temp = propFunc?.Invoke()?.Find(skinName) ?? DefaultSettings;
                if (temp != null)
                {
                    if (Settings.TryMerge(temp))
                        return;
                    Settings = temp;
                }
            }
            else if (DefaultSettings != null)
                Settings = DefaultSettings;
        }

        protected virtual string BuildClass(string @class) => @class;

        protected virtual void ApplySkin(TagHelperContext context, TagHelperOutput output)
        {
            if (!string.IsNullOrEmpty(DefaultSettings?.Class))
                output.Attributes.SetAttribute("class", BuildClass(DefaultSettings.Class));
            else if (Settings != null)
                output.SetDefaultClass(BuildClass(Settings.Class));
            else
            {
                var @class = context.AllAttributes["class"]?.Value.ToString();
                output.Attributes.SetAttribute("class", BuildClass(@class));
            }
        }

        protected virtual void DoProcess(TagHelperContext context, TagHelperOutput output)
        {

        }

        protected virtual Task DoProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            Process(context, output);
            return Task.CompletedTask;
        }

        void IThemeableTagHelper.DoProcess(TagHelperContext context, TagHelperOutput output) => DoProcess(context, output);

        async Task IThemeableTagHelper.DoProcessAsync(TagHelperContext context, TagHelperOutput output) => await DoProcessAsync(context, output);
    }
}
