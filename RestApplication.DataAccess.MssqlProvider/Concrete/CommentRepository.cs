using RestApplication.DomainModel;

namespace RestApplication.DataAccess.MssqlProvider.Concrete
{
	public class CommentRepository : Repository<Comment>
	{
		public CommentRepository(ApplicationDbContext context)
            : base(context) { }

	}
}
