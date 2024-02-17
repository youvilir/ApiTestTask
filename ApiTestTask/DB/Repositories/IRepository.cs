using ApiTestTask.DB.Repositories.EntityRepository;

namespace ApiTestTask.DB.Repositories
{
	public interface IRepository: IDisposable
	{
		ApiEntityRepository ApiEntity { get; }

		void SaveChanges();

		Task SaveChangesAsync();
	}
}