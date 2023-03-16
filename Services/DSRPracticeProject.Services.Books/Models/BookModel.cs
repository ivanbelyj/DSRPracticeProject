using AutoMapper;
using DSRPracticeProject.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSRPracticeProject.Services.Books.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Author { get; set; } = "";
        public string Title { get; set; } = "";
        public string Note { get; set; } = "";
    }

    public class BookModelProfile : Profile
    {
        public BookModelProfile()
        {
            CreateMap<Book, BookModel>()
                .ForMember(dest => dest.Note, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name));
        }
    }
}
