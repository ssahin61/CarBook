using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AboutsController : ControllerBase
	{
		private readonly GetAboutQueryHandler _getAboutQueryHandler;
		private readonly GetAboutByIdQueryHandler _getAboutByIdQueryHandler;
		private readonly CreateAboutCommandHandler _createAboutCommandHandler;
		private readonly UpdateAboutCommandHandler _updateAboutCommandHandler;
		private readonly RemoveAboutCommandHandler _removeAboutCommandHandler;

		public AboutsController(GetAboutQueryHandler getAboutQueryHandler, GetAboutByIdQueryHandler getAboutByIdQueryHandler, CreateAboutCommandHandler createAboutCommandHandler, UpdateAboutCommandHandler updateAboutCommandHandler, RemoveAboutCommandHandler removeAboutCommandHandler)
		{
			_getAboutQueryHandler = getAboutQueryHandler;
			_getAboutByIdQueryHandler = getAboutByIdQueryHandler;
			_createAboutCommandHandler = createAboutCommandHandler;
			_updateAboutCommandHandler = updateAboutCommandHandler;
			_removeAboutCommandHandler = removeAboutCommandHandler;
		}

		[HttpGet]
		public async Task<IActionResult> AboutList()
		{
			var values = await _getAboutQueryHandler.Handle();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetAboutById(int id)
		{
			var values = await _getAboutByIdQueryHandler.Handle(new GetAboutByIdQuery(id));
			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> CreateAbout(CreateAboutCommand command)
		{
			await _createAboutCommandHandler.Handle(command);
			return Ok("Hakkımızda bilgisi oluşturuldu");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateAbout(UpdateAboutCommand command)
		{
			await _updateAboutCommandHandler.Handle(command);
			return Ok("Hakkımızda bilgisi güncellendi");
		}

		[HttpDelete]
		public async Task<IActionResult> RemoveAbout(int id)
		{
			await _removeAboutCommandHandler.Handle(new RemoveAboutCommand(id));
			return Ok("Hakkımızda bilgisi silindi!");
		}
	}
}
