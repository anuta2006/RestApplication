using RestApplication.Web.Infrastructure.ActionFilters;
using System.Web.Http;

namespace RestApplication.Web
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Web API configuration and services
			config.Filters.Add(new GlobalExceptionAttribute());
			config.Filters.Add(new LoggingFilterAttribute());
			config.Filters.Add(new ValidateModelAttribute());

			config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

			// Web API routes
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
		}
	}
}
