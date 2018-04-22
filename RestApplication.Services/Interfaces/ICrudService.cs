using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestApplication.Services.Interfaces
{
	public interface ICrudService<IEntity>
	{
		IEntity Get(int? id);

		Task<IEntity> GetAsync(int? id);

		IEnumerable<IEntity> GetAll();

		void Create(IEntity entity);

		IEnumerable<IEntity> Find(Func<IEntity, bool> f);

		void Update(IEntity entity);

		void Delete(int? id);

		Task DeleteAsync(int? id);

		void Dispose();
	}
}
