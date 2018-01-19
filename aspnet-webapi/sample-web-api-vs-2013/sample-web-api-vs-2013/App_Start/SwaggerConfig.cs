using System.Web.Http;
using WebActivatorEx;
using sample_web_api_vs_2013;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace sample_web_api_vs_2013
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "Restful Api Documentation");
                        c.IncludeXmlComments(string.Format(@"{0}\bin\sample-web-api-vs-2013.XML", System.AppDomain.CurrentDomain.BaseDirectory));
                    })
                .EnableSwaggerUi(c =>
                    {
                    });
        }
    }
}
