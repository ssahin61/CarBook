using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.SocialMediaCommands
{
	public class RemoveSocialMediaCommand : IRequest
	{
		public RemoveSocialMediaCommand(int ıd)
		{
			Id = ıd;
		}

		public int Id { get; set; }
	}
}
