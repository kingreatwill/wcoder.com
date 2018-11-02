using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Wcoder.Blog.AppClient
{
    public class HttpClientProxy
    {
        public void MkFile(string path, string str)
        {
            System.IO.File.WriteAllText(path, str, Encoding.UTF8);
        }

        public string Generate(Type type)
        {
            if (!type.IsInterface) return string.Empty;
            var controllerName = type.Name.TrimStart('I');
            StringBuilder msb = new StringBuilder();
            var methods = type.GetMethods();
            foreach (var method in methods)
            {
                var httpMethod = HttpMethod.Post;// "PostJsonAsync";
                if (method.ReturnType != typeof(void) && method.ReturnType != typeof(Task))
                {
                    var mName = method.Name.ToLower();
                    var startsWith = new string[] { "get", "find", "search", "list" };
                    var endsWith = new string[] { "list", "detail", "listasync", "detailasync" };
                    if (startsWith.Any(t => mName.StartsWith(t)) || endsWith.Any(t => mName.EndsWith(t)))
                    {
                        httpMethod = HttpMethod.Get;//"GetJsonAsync";
                    }
                }

                var mParameters = method.GetParameters().Select(t => (t.ParameterType.IsGenericType && t.ParameterType.GetGenericTypeDefinition() == typeof(Nullable<>)) ?
                $"Nullable<{t.ParameterType.GetGenericArguments().FirstOrDefault().Name}> {t.Name}" :
                $"{t.ParameterType.Name} {t.Name}");
                // 返回值类型;
                var returnTypeName = (method.ReturnType == typeof(void) || method.ReturnType == typeof(Task)) ? "" : $"<{method.ReturnType.Name}>";
                if (method.ReturnType.IsGenericType && method.ReturnType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    var genType = method.ReturnType.GetGenericArguments().FirstOrDefault();
                    returnTypeName = $"<Nullable<{genType.Name}>>";
                }
                if (method.ReturnType.IsGenericType && method.ReturnType.GetGenericTypeDefinition() == typeof(Task<>))
                {
                    var genType = method.ReturnType.GetGenericArguments().FirstOrDefault();
                    if (genType.IsGenericType && genType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        genType = genType.GetGenericArguments().FirstOrDefault();
                        returnTypeName = $"<Nullable<{genType.Name}>>";
                    }
                    else
                    {
                        returnTypeName = $"<{genType.Name}>";
                    }
                }
                string ms = $@"
        public async Task{returnTypeName} {method.Name}({string.Join(",", mParameters)})
        {{
            var url = $""/{{controllerName}}/{{nameof({method.Name})}}"";
            return await httpClient.{(httpMethod == HttpMethod.Get ? "GetJsonAsync" : "PostJsonAsync")}{returnTypeName}(url{(httpMethod == HttpMethod.Get ? "" : $",{(mParameters.Count() > 0 ? method.GetParameters().First().Name : "null")}")});
        }}
";
                msb.Append(ms);
            }

            StringBuilder sb = new StringBuilder();
            sb.Append($@"using Microsoft.AspNetCore.Blazor;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Wcoder.Blog.Protocol.Interfaces;
using Wcoder.Blog.Protocol.Models;

namespace Wcoder.Blog.AppClient
{{
    public class HttpClient{controllerName} : I{controllerName}
    {{
        private readonly HttpClient httpClient;
        private readonly string controllerName = ""{controllerName}"";

        public HttpClient{controllerName}(HttpClient httpClient)
        {{
            this.httpClient = httpClient;
        }}

        {msb.ToString()}
     }}
}}
");
            return sb.ToString();
        }
    }
}