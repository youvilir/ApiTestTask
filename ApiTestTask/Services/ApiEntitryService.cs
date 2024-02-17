using ApiTestTask.DB.Entities;
using ApiTestTask.DB.Repositories;
using ApiTestTask.Enums;

namespace ApiTestTask.Services
{
	public class ApiEntitryService : IApiEntitryService
	{
		private readonly IRepository _repository;
		private const int _delay = 2 * 60 * 100; // TODO вынести в конфиг

		public ApiEntitryService(IRepository repository)
		{
			_repository = repository;
		}

		public async Task<Guid> CreateAsync()
		{
			var apiEntity = new ApiEntity();

			await _repository.ApiEntity.AddAsync(apiEntity);
			await _repository.SaveChangesAsync();

			var outer = Task.Run(async () =>
			{
				await ChangeStatusAsync(apiEntity);
				await Task.Delay(_delay);
				await ChangeStatusAsync(apiEntity);
			});

			return apiEntity.ID.Value;
		}

		private async Task ChangeStatusAsync(ApiEntity apiEntity)
		{
			apiEntity.Status = apiEntity.Status switch
			{
				Status.Created => Status.Running,
				Status.Running => Status.Finished,
				_ => Status.Created
			};

			_repository.ApiEntity.Update(apiEntity);
			await _repository.SaveChangesAsync();

			Console.WriteLine($"New status for {apiEntity.ID} = {apiEntity.Status}");
		}
	}
}
