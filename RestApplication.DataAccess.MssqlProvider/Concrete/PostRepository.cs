using RestApplication.DomainModel;

namespace RestApplication.DataAccess.MssqlProvider.Concrete
{
	public class PostRepository : Repository<Post>
	{
		public PostRepository(ApplicationDbContext context)
			: base(context) { }
	}
}
