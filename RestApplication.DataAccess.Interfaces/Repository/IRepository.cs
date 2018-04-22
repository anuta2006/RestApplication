using RestApplication.DomainModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestApplication.DataAccess.Interfaces.Repository
{
	public interface IRepository<TEntity> where TEntity : Entity
	{
		IEnumerable<TEntity> GetAll();
		TEntity Get(int key);
		Task<TEntity> GetAsync(int key);
		IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);
		void Create(TEntity entity);
		void Delete(int id);
		Task DeleteAsync(int id);
		void Update(TEntity entity);
	}
}
