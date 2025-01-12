﻿using CarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.TestimonialHandlers
{
	public class UpdateTestimonailCommandHandler : IRequestHandler<UpdateTestimonialCommand>
	{
		private readonly IRepository<Testimonial> _repository;

		public UpdateTestimonailCommandHandler(IRepository<Testimonial> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.TestiMonialId);

			values.Name = request.Name;
			values.Title = request.Title;
			values.Comment = request.Comment;
			values.ImageUrl = request.ImageUrl;

			await _repository.UpdateAsync(values);
		}
	}
}
