﻿using AutoMapper;
using DSRPracticeProject.Api.Controllers.Books.Models;
using DSRPracticeProject.Services.Books.Models;
using FluentValidation;

namespace DSRPracticeProject.Api.Controllers.Books.Models
{
    public class UpdateBookRequest
    {
        public int AuthorId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public class UpdateBookRequestValidator : AbstractValidator<UpdateBookRequest>
    {
        public UpdateBookRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(50).WithMessage("Title is long.");

            RuleFor(x => x.Description)
                .MaximumLength(2000).WithMessage("Description is long.");
        }
    }

    public class UpdateBookRequestProfile : Profile
    {
        public UpdateBookRequestProfile()
        {
            CreateMap<UpdateBookRequest, UpdateBookModel>()
                .ForMember(d => d.Note, a => a.MapFrom(s => s.Description));
        }
    }
}


