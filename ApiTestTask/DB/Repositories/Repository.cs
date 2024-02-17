using ApiTestTask.DB.Repositories.EntityRepository;

namespace ApiTestTask.DB.Repositories
{
	public class Repository : IRepository
	{
		protected DataContext _dataContext { get; set; }

		public Repository(DataContext dataContext)
		{
			_dataContext = dataContext;

			ApiEntity = new ApiEntityRepository(dataContext);
		}

		public ApiEntityRepository ApiEntity { get; }

		public void SaveChanges()
		{
			_dataContext.SaveChanges();
		}

		public async Task SaveChangesAsync()
		{
			await _dataContext.SaveChangesAsync();
		}

		public void Dispose()
		{
			_dataContext?.Dispose();
		}

	}
}
