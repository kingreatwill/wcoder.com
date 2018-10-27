using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.AspNetCore.Builder
{
    public static class BlazorApplicationBuilderExtensions
    {
        /// <summary>
        /// 将服务转换成HTTP
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseBlazorHostServer(this IApplicationBuilder app)
        {
            return app;
        }
    }
}