
namespace ApiTestTask.Services
{
	public interface IApiEntitryService
	{
		Task<Guid> CreateAsync();
	}
}