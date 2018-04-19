using RestApplication.DomainModel;
using System;

namespace RestApplication.DataAccess.Interfaces.Repository
{
	public interface IUnitOfWork : IDisposable
	{
		IRepository<Post> Posts { get; }
		IRepository<Comment> Comments { get; }
		void Save();
	}
}
