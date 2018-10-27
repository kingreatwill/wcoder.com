using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Wcoder.Blog.Services;

namespace Wcoder.Blog.Application
{
    public class MvcFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            feature.Controllers.Add(typeof(WeatherForecastService).GetTypeInfo());
        }
    }
}