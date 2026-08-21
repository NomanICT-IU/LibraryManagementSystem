

namespace LibraryManagementSystem.Api.Controllers
{

    [ApiController]
    [Route("api/books")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost("create-book")]
        
        public async Task<IActionResult> CreateBook([FromBody] BookDto bookDto, CancellationToken cancellationToken)
       {
            var book = await _bookService.CreateBookAsync(bookDto, cancellationToken);
            return Ok(new ApiResponse<BookDto>
            {
                Data = book
            });
        }

        [HttpGet("get-book-by-id/{bookId:int}")]
        public async Task<IActionResult> GetBookById(int bookId, CancellationToken cancellationToken)
        {
            var book = await _bookService.GetBookByIdAsync(bookId, cancellationToken);
            return Ok(new ApiResponse<BookDto>
            {
                Data = book
            });
        }

        [HttpPut("update-book")]
        public async Task<IActionResult> UpdateBook([FromBody] BookDto bookDto, CancellationToken cancellationToken)
        {
            var isUpdated = await _bookService.UpdateBookAsync(bookDto, cancellationToken);
            return Ok(new ApiResponse<bool>
            {
                Data = isUpdated,
            });
        }

        [HttpDelete("delete-book/{bookId:int}")]
        public async Task<IActionResult> DeleteBook(int bookId, CancellationToken cancellationToken)
        {
            var isDeleted = await _bookService.DeleteBookAsync(bookId, cancellationToken);

            return Ok(new ApiResponse<bool>
            {
                Data = isDeleted,
            });
        }

        [HttpGet("search-book-list")]
        public async Task<IActionResult> SearchBooksAsync(string searchBy, string searchText, CancellationToken cancellationToken)
        {
            var result = await _bookService.SearchBooksAsync(
                searchBy,
                searchText,
                cancellationToken);

            return Ok(new ApiResponse<IEnumerable<BookSearchDetailDto>>
            {
                Data = result
            });
        }
    }
}
