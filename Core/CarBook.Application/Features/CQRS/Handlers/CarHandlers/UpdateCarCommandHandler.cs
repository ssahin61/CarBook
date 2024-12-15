using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
	public class UpdateCarCommandHandler
	{
		private readonly IRepository<Car> _repository;

		public UpdateCarCommandHandler(IRepository<Car> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateCarCommand command)
		{
			var values = await _repository.GetByIdAsync(command.CarId);

			values.BrandId = command.CarId;
			values.Model = command.Model;
			values.Fuel = command.Fuel;
			values.Km = command.Km;
			values.Transmission = command.Transmission;
			values.Luggage = command.Luggage;
			values.Seat = command.Seat;
			values.BigImageUrl = command.BigImageUrl;
			values.CoverImageUrl = command.CoverImageUrl;

			await _repository.UpdateAsync(values);
		}
	}
}
