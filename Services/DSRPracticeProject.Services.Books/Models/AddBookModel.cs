using AutoMapper;
using DSRPracticeProject.Context.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSRPracticeProject.Services.Books.Models
{
    public class AddBookModel
    {
        public int AuthorId { get; set; }
        public string Title { get; set; } = "";
        public string Note { get; set; } = "";

    }

    public class AddBookModelValidator : AbstractValidator<AddBookModel>
    {
        public AddBookModelValidator()
        {
            RuleFor(x => x.AuthorId)
                .NotEmpty().WithMessage("Author is required.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(50).WithMessage("Title is long.");

            RuleFor(x => x.Note)
                .MaximumLength(2000).WithMessage("Description is long.");

            // Здесь можно проверить, например, на уникальность
        }
    }

    public class AddBookModelProfile : Profile
    {
        public AddBookModelProfile()
        {
            CreateMap<AddBookModel, Book>()
                .ForMember(d => d.Description, a => a.MapFrom(s => s.Note));
        }
    }
}
