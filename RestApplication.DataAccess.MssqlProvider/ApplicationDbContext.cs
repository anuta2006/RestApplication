using RestApplication.DomainModel;
using System.Data.Entity;

namespace RestApplication.DataAccess.MssqlProvider
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(string connectionString) : base(connectionString) { }

		public IDbSet<Comment> Comments { get; set; }
		public IDbSet<Post> Posts { get; set; }
	}
}
