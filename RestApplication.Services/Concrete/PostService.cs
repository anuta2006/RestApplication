using RestApplication.DataAccess.Interfaces.Repository;
using RestApplication.DomainModel;
using RestApplication.Services.Infrastructure;
using RestApplication.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestApplication.Services.Concrete
{
	public class PostService : ICrudService<Post>
	{
		protected readonly IDbSession _dbSession;

		public PostService(IDbSession dbSession)
		{
			_dbSession = dbSession;
		}

		public void Create(Post post)
		{
			if (post == null)
			{
				throw new ArgumentNullException("post");
			}
			post.PublishedDate = DateTime.Now;
			_dbSession.Posts.Create(post);
			_dbSession.Save();
		}

		public void Delete(int? id)
		{
			if (id == null)
			{
				throw new ArgumentNullException("id");
			}
			_dbSession.Posts.Delete(id.Value);
			_dbSession.Save();
		}

		public async Task DeleteAsync(int? id)
		{
			if (id == null)
			{
				throw new ArgumentNullException("id");
			}
			await _dbSession.Posts.DeleteAsync(id.Value);
			_dbSession.Save();
		}

		public Post Get(int? id)
		{
			if (id == null)
			{
				throw new ArgumentNullException("id");
			}
			return _dbSession.Posts.Get(id.Value) ?? throw new ValidationException($"Post with id={id} is not found", "");
		}

		public async Task<Post> GetAsync(int? id)
		{
			if (id == null)
			{
				throw new ArgumentNullException("id");
			}
			return await _dbSession.Posts.GetAsync(id.Value) ?? throw new ValidationException($"Post with id={id} is not found", "");
		}

		public IEnumerable<Post> GetAll()
		{
			return _dbSession.Posts.GetAll();
		}

		public IEnumerable<Post> Find(Func<Post, bool> f)
		{
			return _dbSession.Posts.Find(f);
		}

		public void Update(Post post)
		{
			if (post == null)
			{
				throw new ArgumentNullException("post");
			}
			_dbSession.Posts.Update(post);
			_dbSession.Save();
		}

		public void Dispose()
		{
			_dbSession.Dispose();
		}
	}
}
