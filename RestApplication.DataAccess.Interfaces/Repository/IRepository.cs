using RestApplication.DomainModel;
using System;
using System.Collections.Generic;

namespace RestApplication.DataAccess.Interfaces.Repository
{
	public interface IRepository<TEntity> where TEntity : Entity
	{
		IEnumerable<TEntity> GetAll();
		TEntity Get(int key);
		IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);
		void Create(TEntity e);
		void Delete(int id);
		void Update(TEntity entity);
	}
}
