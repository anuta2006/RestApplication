using RestApplication.DomainModel;
using System.Data.Entity;

namespace RestApplication.DataAccess.MssqlProvider
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext() : base("name=ApplicationDb")
		{	
			Database.SetInitializer(new AppDbInitializer());
		}

		public IDbSet<Comment> Comments { get; set; }
		public IDbSet<Post> Posts { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Post>().Map(m =>
			{
				m.MapInheritedProperties();
				m.ToTable("Post");
			});

			modelBuilder.Entity<Comment>().Map(m =>
			{
				m.MapInheritedProperties();
				m.ToTable("Comment");
			});
		}
	}
}
