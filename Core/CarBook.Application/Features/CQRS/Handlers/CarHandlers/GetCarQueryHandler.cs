using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
	public class GetCarQueryHandler
	{
		private readonly IRepository<Car> _repository;

		public GetCarQueryHandler(IRepository<Car> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetCarQueryResult>> Handle()
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetCarQueryResult
			{
				CarId = x.CarId,
				BrandId = x.BrandId,
				Model = x.Model,
				Fuel = x.Fuel,
				Km = x.Km,
				Luggage = x.Luggage,
				Seat = x.Seat,
				Transmission = x.Transmission,
				BigImageUrl = x.BigImageUrl,
				CoverImageUrl = x.CoverImageUrl
			}).ToList();
		}
	}
}
