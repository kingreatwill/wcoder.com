using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Wcoder.Blog.Services;

namespace Wcoder.Blog.Application
{
    public class MvcFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        private readonly IServiceCollection services;

        public MvcFeatureProvider(IServiceCollection services)
        {
            this.services = services;
        }

        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            var ownServices = services.Where(t => t.ServiceType.Namespace.Equals("Wcoder.Blog.Protocol.Interfaces")).ToList();
            foreach (var srv in ownServices)
            {
                feature.Controllers.Add(srv.ImplementationType.GetTypeInfo());
            }
        }
    }
}