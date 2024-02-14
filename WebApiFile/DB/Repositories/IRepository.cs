using WebApiFile.DB.Repositories.EntityRepository;

namespace WebApiFile.DB.Repositories
{
	public interface IRepository: IDisposable
	{
		ApiEntityRepository ApiEntity { get; }

		void SaveChanges();

		Task SaveChangesAsync();
	}
}