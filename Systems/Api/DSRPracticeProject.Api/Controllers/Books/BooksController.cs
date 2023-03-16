using AutoMapper;
using DSRPracticeProject.Api.Controllers.Books.Models;
using DSRPracticeProject.Common.Responses;
using DSRPracticeProject.Services.Books;
using DSRPracticeProject.Services.Books.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DSRPracticeProject.Api.Controllers.Books
{
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/books")]
    [ApiController]
    [ApiVersion("1.0")]
    public class BooksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogger<BooksController> logger;
        private readonly IBookService bookService;

        public BooksController(IMapper mapper, ILogger<BooksController> logger,
            IBookService bookService)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.bookService = bookService;
        }

        [ProducesResponseType(typeof(IEnumerable<BookResponse>), 200)]
        [HttpGet("")]
        public async Task<IEnumerable<BookResponse>> GetBooks([FromQuery] int offset,
            [FromQuery] int limit)
        {
            var books = await bookService.GetBooks(offset, limit);
            var response = mapper.Map<IEnumerable<BookResponse>>(books);
            return response;
        }

        [ProducesResponseType(typeof(BookResponse), 200)]
        [HttpGet("{id}")]
        public async Task<BookResponse> GetBookById([FromRoute] int id)
        {
            var book = await bookService.GetBook(id);
            var response = mapper.Map<BookResponse>(book);

            return response;
        }

        [HttpPost("")]
        public async Task<BookResponse> AddBook([FromBody] AddBookRequest request)
        {
            var model = mapper.Map<AddBookModel>(request);
            var book = await bookService.AddBook(model);
            var response = mapper.Map<BookResponse>(book);

            return response;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromRoute] int id,
            [FromBody] UpdateBookRequest request)
        {
            var model = mapper.Map<UpdateBookModel>(request);
            await bookService.UpdateBook(id, model);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            await bookService.DeleteBook(id);

            return Ok();
        }
    }
}
