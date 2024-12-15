using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
	public class CreateCarCommandHandler
	{
		private readonly IRepository<Car> _repository;

		public CreateCarCommandHandler(IRepository<Car> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateCarCommand command)
		{
			await _repository.CreateAsync(new Car
			{
				BrandId = command.BrandId,
				Model = command.Model,
				Fuel = command.Fuel,
				Km = command.Km,
				Seat = command.Seat,
				Luggage = command.Luggage,
				Transmission = command.Transmission,
				BigImageUrl = command.BigImageUrl,
				CoverImageUrl = command.CoverImageUrl,
			});
		}
	}
}
