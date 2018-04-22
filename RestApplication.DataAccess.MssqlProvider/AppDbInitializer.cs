using RestApplication.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace RestApplication.DataAccess.MssqlProvider
{
	public class AppDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
	{
		protected override void Seed(ApplicationDbContext context)
		{
			context.Posts.Add(new Post { Id = 1, Author = "Hanna", Content = "test post", PublishedDate = DateTime.Now });
			context.Comments.Add(new Comment { Id = 1, Author = "Hanna", Content = "Great!", PostId = 1, PublishedDate = DateTime.Now });			
			context.SaveChanges();
			base.Seed(context);
		}
	}
}
