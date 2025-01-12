using CarBook.Application.Features.Mediator.Results.FooterAddressResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.FooterAddressQueries
{
	public class GetFooterAddressByIdQuery : IRequest<GetFooterAddressByIdQueryResult>
	{
		public GetFooterAddressByIdQuery(int id)
		{
			Id = id;
		}

		public int Id { get; set; }
	}
}
