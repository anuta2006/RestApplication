using RestApplication.DomainModel;
using System;
using System.Data.Entity;

namespace RestApplication.DataAccess.MssqlProvider
{
	public class AppDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
	{
		protected override void Seed(ApplicationDbContext context)
		{
			//ICollection<Comment> comments = new Comment[]
			//{
			//	new Comment {}
			//}
			context.Posts.Add(new Post { Id = 1, Author = "Hanna", Content = "test post", PublishedDate = DateTime.Now });
			context.SaveChanges();
			base.Seed(context);
		}
	}
}
