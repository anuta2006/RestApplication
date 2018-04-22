using RestApplication.DataAccess.Interfaces.Repository;
using RestApplication.DomainModel;
using RestApplication.Services.Infrastructure;
using RestApplication.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestApplication.Services.Concrete
{
	public class CommentService : ICrudService<Comment>
	{
		protected readonly IDbSession _dbSession;

		public CommentService(IDbSession dbSession)
		{
			_dbSession = dbSession;
		}

		public void Create(Comment comment)
		{
			if (comment == null)
			{
				throw new ArgumentNullException("comment");
			}
			comment.PublishedDate = DateTime.Now;
			_dbSession.Comments.Create(comment);
			_dbSession.Save();
		}

		public void Delete(int? id)
		{
			if (id == null)
			{
				throw new ArgumentNullException("id");
			}
			_dbSession.Comments.Delete(id.Value);
			_dbSession.Save();
		}

		public async Task DeleteAsync(int? id)
		{
			if (id == null)
			{
				throw new ArgumentNullException("id");
			}
			await _dbSession.Comments.DeleteAsync(id.Value);
			_dbSession.Save();
		}

		public Comment Get(int? id)
		{
			if (id == null)
			{
				throw new ArgumentNullException("id");
			}
			return _dbSession.Comments.Get(id.Value) ?? throw new ValidationException($"Comment with id={id} is not found", "");
		}

		public async Task<Comment> GetAsync(int? id)
		{
			if (id == null)
			{
				throw new ArgumentNullException("id");
			}
			return await _dbSession.Comments.GetAsync(id.Value) ?? throw new ValidationException($"Comment with id={id} is not found", "");
		}

		public IEnumerable<Comment> GetAll()
		{
			return _dbSession.Comments.GetAll();
		}

		public IEnumerable<Comment> Find(Func<Comment, bool> f)
		{
			return _dbSession.Comments.Find(f);
		}

		public void Update(Comment comment)
		{
			if (comment == null)
			{
				throw new ArgumentNullException("comment");
			}
			comment.LastUpdatedDate = DateTime.Now;
			_dbSession.Comments.Update(comment);
			_dbSession.Save();
		}

		public void Dispose()
		{
			_dbSession.Dispose();
		}
	}
}
