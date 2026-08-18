using LibraryManagementSystem.BLL.Dtos;
using LibraryManagementSystem.BLL.Service;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Api.Controllers
{

    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost("create-book")]
        public async Task<IActionResult> CreateBook(BookDto bookDto,CancellationToken cancellationToken)
        {
            var book = await _bookService.CreateBook(bookDto,cancellationToken);
            var response = new
            {
                IsSuccess = true,
                Message="Book Saved Successfully",
                Results = book
            };
            return Ok(response);
        }

        [HttpGet("get-book-by-id/{bookId:int}")]
        public async Task<IActionResult> GetBookById(int bookId,CancellationToken cancellationToken)
        {
            var book = await _bookService.GetBookById( bookId,cancellationToken);

            return Ok(book);
        }

        [HttpPut("update-book")]
        public async Task<IActionResult> UpdateBook(BookDto bookDto,CancellationToken cancellationToken)
        {
            var isUpdated= await _bookService.UpdateBook(bookDto,cancellationToken);

            return Ok(isUpdated);
        }

        [HttpDelete("delete-book/{bookId:int}")]
        public async Task<IActionResult> DeleteBook(int bookId,CancellationToken cancellationToken)
        {
            var isDeleted= await _bookService.DeleteBook(bookId, cancellationToken);

            return Ok(isDeleted);
        }
    }
}
