using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
	public class GetCarWithBrandQueryHandler
	{
		private readonly ICarRepository _repository;

		public GetCarWithBrandQueryHandler(ICarRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetCarWithBrandQueryResult>> Handle()
		{
			var values = await _repository.GetCarsWithBrand();
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
