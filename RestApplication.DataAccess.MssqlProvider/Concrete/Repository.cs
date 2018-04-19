using RestApplication.DataAccess.Interfaces.Repository;
using RestApplication.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RestApplication.DataAccess.MssqlProvider.Concrete
{
	public abstract class Repository<TEntity> : IRepository<TEntity>
		where TEntity : Entity
	{
		protected readonly ApplicationDbContext dbContext;

		public Repository(ApplicationDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public void Create(TEntity e)
		{
			dbContext.Set<TEntity>().Add(e);
		}

		public void Delete(int id)
		{
			TEntity entity = dbContext.Set<TEntity>().Find(id);
			if (entity != null)
			{
				dbContext.Set<TEntity>().Remove(entity);
			}
		}

		public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
		{
			return dbContext.Set<TEntity>().Where(predicate);
		}

		public TEntity Get(int key)
		{
			return dbContext.Set<TEntity>().FirstOrDefault(item => item.Id == key);
		}

		public IEnumerable<TEntity> GetAll()
		{
			return dbContext.Set<TEntity>();
		}

		public void Update(TEntity entity)
		{
			dbContext.Entry(entity).State = EntityState.Modified;
		}
	}
}
