using WebApiFile.DB.Entities;
using WebApiFile.DB.Repositories;
using WebApiFile.Enums;

namespace ApiTestTask.Services
{
	public class ApiEntitryService
	{
		private readonly IRepository _repository;

		public ApiEntitryService(IRepository repository)
		{
			_repository = repository;
		}

		public async Task<Guid> CreateAsync()
		{
			var apiEntity = new ApiEntity();

			await _repository.ApiEntity.AddAsync(apiEntity);
			await _repository.SaveChangesAsync();

			var outer = Task.Run(() =>
			{
				var inner = Task.Run(() =>
				{
					_ = ChangeStatusAsync(apiEntity)
						.ContinueWith(_ => Task.Delay(TimeSpan.FromSeconds(120))) // TODO вынести параметр в конфиг
						.Unwrap()
						.ContinueWith(_ => ChangeStatusAsync(apiEntity))
						.Unwrap();
				});
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
