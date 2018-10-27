using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Wcoder.Blog.Application;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MvcBuilderExtensions
    {
        public static IMvcBuilder AddOtherMvc(this IMvcBuilder builder)
        {
            return builder.ConfigureApplicationPartManager(m => m.FeatureProviders.Add(new MvcFeatureProvider()));
        }
    }
}