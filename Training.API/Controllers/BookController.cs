using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Training.Entity.Entities;
using Training.Service.Services.Abstract;

namespace Training.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        [Route("GetBooks")]
        public async Task<IList<Book>> Get()
        {
            var books = await _bookService.ListAllBooksAsync();
            return books;
        }
    }
}
