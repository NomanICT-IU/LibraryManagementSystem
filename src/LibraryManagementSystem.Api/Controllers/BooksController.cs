using LibrarymanagementSystem.Shared;

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
            var book = await _bookService.CreateBookAsync(bookDto,cancellationToken);
            return Ok(new ApiResponse<BookDto>
            {
                Data = book
            });
        }

        [HttpGet("get-book-by-id/{bookId:int}")]
        public async Task<IActionResult> GetBookById(int bookId,CancellationToken cancellationToken)
        {
            var book = await _bookService.GetBookByIdAsync( bookId,cancellationToken);
            return Ok(new ApiResponse<BookDto>
            {
                Data = book
            });
        }

        [HttpPut("update-book")]
        public async Task<IActionResult> UpdateBook(BookDto bookDto,CancellationToken cancellationToken)
        {
            var isUpdated= await _bookService.UpdateBookAsync(bookDto,cancellationToken);
            return Ok(new ApiResponse<bool>
            {
                Data=isUpdated,
            });
        }

        [HttpDelete("delete-book/{bookId:int}")]
        public async Task<IActionResult> DeleteBook(int bookId,CancellationToken cancellationToken)
        {
            var isDeleted= await _bookService.DeleteBookAsync(bookId, cancellationToken);

            return Ok(new ApiResponse<bool>
            {
                Data = isDeleted,
            });
        }
    }
}
