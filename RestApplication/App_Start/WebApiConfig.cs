using RestApplication.WebApp.Infrastructure.ActionFIlters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace RestApplication
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Web API configuration and services
			config.Filters.Add(new GlobalExceptionAttribute());
			config.Filters.Add(new LoggingFilterAttribute());
			config.Filters.Add(new ValidateModelAttribute());

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
