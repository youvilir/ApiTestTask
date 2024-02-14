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
		/// �������� ������
		/// </summary>
		/// <remarks>
		/// �������� ������
		/// </remarks>
		/// <response code="202">ID ����� ������</response>
		[ProducesResponseType((int)HttpStatusCode.Accepted)]
		[HttpPost("/task")]
        public async Task<IActionResult> Create()
        {
			var newId = await _apiEntitryService.CreateAsync();

			return Accepted(newId);
        }

		/// <summary>
		/// ��������� ������� ������
		/// </summary>
		/// <param name="id"></param>
		/// <remarks>
		/// ��������� ������� ������
		/// </remarks>
		/// <param name="id">ID ������</param>
		/// <response code="200">������ ������</response>
		/// <response code="404">������ �� �������</response>
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		[HttpGet("/task/{id}")]
		public IActionResult Get(Guid id)
		{
			// "���������� 400, ���� ������� �� GUID" - �����? ����� � ����� ����� ���������� Guid - ������� ���������� ���� �� ����� �������������
			var entity = _repository.ApiEntity.Get(id);

			if (entity == null)
				return NotFound();


			return Ok(entity.Status);
		}
	}
}