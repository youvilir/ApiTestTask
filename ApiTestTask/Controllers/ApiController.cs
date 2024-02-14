using ApiTestTask.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApiFile.DB.Repositories;
using WebApiFile.Enums;

namespace WebApiFile.Controllers
{
	[Produces("application/json")]
    [ApiController]
    public class ApiController : ControllerBase
    {

        private readonly ILogger<ApiController> _logger;
        private readonly IRepository _repository;
		private readonly ApiEntitryService _apiEntitryService;

		public ApiController(
			ILogger<ApiController> logger, 
			IRepository repository, 
			ApiEntitryService apiEntitryService)
        {
            _logger = logger;
            _repository = repository;
			_apiEntitryService = apiEntitryService;
        }

		/// <summary>
		/// Создание задачи
		/// </summary>
		/// <remarks>
		/// Создание задачи
		/// </remarks>
		/// <response code="202">ID новой задачи</response>
		[ProducesResponseType((int)HttpStatusCode.Accepted)]
		[HttpPost("/task")]
        public async Task<IActionResult> Create()
        {
			var newId = await _apiEntitryService.CreateAsync();

			return Accepted(newId);
        }

		/// <summary>
		/// Получение статуса задачи
		/// </summary>
		/// <param name="id"></param>
		/// <remarks>
		/// Получение статуса задачи
		/// </remarks>
		/// <param name="id">ID задачи</param>
		/// <response code="200">Статус задачи</response>
		/// <response code="404">Задача не найдена</response>
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		[HttpGet("/task/{id}")]
		public IActionResult Get(Guid id)
		{
			// "Возвращает 400, если передан не GUID" - зачем? можно в метод сразу передавать Guid - получим приведение типа на этапе маршрутизации
			var entity = _repository.ApiEntity.Get(id);

			if (entity == null)
				return NotFound();


			return Ok(entity.Status);
		}
	}
}