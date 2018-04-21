using RestApplication.DataAccess.Interfaces.Repository;
using RestApplication.DomainModel;
using System;

namespace RestApplication.DataAccess.MssqlProvider.Concrete
{
	public class DbSession : IDbSession
	{
		private readonly ApplicationDbContext _context;
		private bool _disposed = false;

		public DbSession(ApplicationDbContext context, IRepository<Post> postRepository, IRepository<Comment> commentRepository)
		{
			_context = context;
			Posts = postRepository;
			Comments = commentRepository;
		}

		public IRepository<Post> Posts { get; private set; }

		public IRepository<Comment> Comments { get; private set; }

		public void Save()
		{
			_context.SaveChanges();
		}

		#region Dispose pattern implementation
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					_context.Dispose();
				}
				_disposed = true;
			}
		}
		#endregion
	}
}
