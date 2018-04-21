using Ninject;
using Ninject.Web.Common;
using RestApplication.DataAccess.Interfaces.Repository;
using RestApplication.DataAccess.MssqlProvider;
using RestApplication.DataAccess.MssqlProvider.Concrete;
using RestApplication.DomainModel;
using RestApplication.Services.Concrete;
using RestApplication.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApplication.Common.DependencyResolver
{
	public static class ResolverConfig
	{
		public static void ConfigurateResolverWeb(this IKernel kernel)
		{
			Configure(kernel);
		}

		private static void Configure(IKernel kernel)
		{

			kernel.Bind<IDbSession>().To<DbSession>().InRequestScope();
			kernel.Bind<DbContext>().To<ApplicationDbContext>().InRequestScope();


			kernel.Bind<IRepository<Post>>().To<PostRepository>();
			kernel.Bind<IRepository<Comment>>().To<CommentRepository>();

			kernel.Bind<ICrudService<Post>>().To<PostService>();
			kernel.Bind<ICrudService<Comment>>().To<CommentService>();
		}
	}
}
