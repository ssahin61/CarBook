﻿using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces.CarInterfaces;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
	public class GetLast5CarsWithBrandQueryHandler
	{
		private readonly ICarRepository _repository;

		public GetLast5CarsWithBrandQueryHandler(ICarRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetCarWithBrandQueryResult>> Handle()
		{
			var values = await _repository.GetLast5CarsWithBrand();
			return values.Select(x => new GetCarWithBrandQueryResult
			{
				CarId = x.CarId,
				//BrandId = x.BrandId,
				BrandName = x.Brand.Name,
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
