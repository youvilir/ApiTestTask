using ApiTestTask.DB.Entities;

namespace ApiTestTask.DB.Repositories
{
	public interface IRepositoryBase<T> where T : class, IEntity
	{
		void Add(T entity);

		Task AddAsync(T entity);

		void Delete(Guid id);

		void Delete(T entity);

		T? Get(Guid id);

		void Update(T entity);
	}
}