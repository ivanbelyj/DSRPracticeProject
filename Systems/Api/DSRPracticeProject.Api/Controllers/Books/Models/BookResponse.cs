using AutoMapper;
using DSRPracticeProject.Api.Controllers.Books.Models;
using DSRPracticeProject.Services.Books.Models;

namespace DSRPracticeProject.Api.Controllers.Books.Models
{
    public class BookResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int AuthorId { get; set; }
        public string Author { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public class BookResponseProfile : Profile
    {
        public BookResponseProfile()
        {
            CreateMap<BookModel, BookResponse>()
                .ForMember(d => d.Description, a => a.MapFrom(s => s.Note));
        }
    }

}
