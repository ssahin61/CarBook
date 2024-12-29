﻿using CarBook.Application.Features.Mediator.Queries.ServiceQueries;
using CarBook.Application.Features.Mediator.Results.ServiceResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.ServiceHandlers
{
	public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
	{
		private readonly IRepository<Service> _repository;

		public GetServiceByIdQueryHandler(IRepository<Service> repository)
		{
			_repository = repository;
		}

		public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);

			return new GetServiceByIdQueryResult
			{
				Title = values.Title,
				Description = values.Description,
				IconUrl = values.IconUrl,
			};
		}
	}
}
