namespace LibraryManagementSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookCopyController : ControllerBase
{
    private readonly IBookCopyService _bookCopyService;

    public BookCopyController(IBookCopyService bookCopyService)
    {
        _bookCopyService = bookCopyService;
    }

    [HttpPost("create-book-copy")]
    public async Task<IActionResult> CreateBookCopyAsync(BookCopyDto bookCopyDto, CancellationToken cancellationToken)
    {
        var bookCopy = await _bookCopyService.CreateBookCopyAsync(bookCopyDto, cancellationToken);

        return Ok(new ApiResponse<BookCopyDto>
        {
            Data = bookCopy,
            StatusCode = StatusCodes.Status200OK
        });
    }

    [HttpDelete("delete-book-copy/{CopyId:int}")]
    public async Task<IActionResult> DeleteBookCopyAsync(int CopyId, CancellationToken cancellationToken)
    {
        var isDeleted = await _bookCopyService.DeleteBookCopyAsync(CopyId, cancellationToken);

        return Ok(new ApiResponse<bool>
        {
            Data = isDeleted,
            StatusCode = StatusCodes.Status200OK
        });
    }

    [HttpGet("get-book-copy-by-id/{CopyId:int}")]
    public async Task<IActionResult> GetBookCopyByIdAsync(int CopyId, CancellationToken cancellationToken)
    {
        var bookCopy = await _bookCopyService.GetBookCopyByIdAsync(CopyId, cancellationToken);
        return Ok(new ApiResponse<BookCopyDto>
        {
            Data = bookCopy,
            StatusCode = StatusCodes.Status200OK
        });
    }

    [HttpPut("update-book")]
    public async Task<IActionResult> UpdateBookCopyAsync(BookCopyDto bookCopyDto, CancellationToken cancellationToken)
    {
        var IsUpdated = await _bookCopyService.UpdateBookCopyAsync(bookCopyDto, cancellationToken);
        return Ok(new ApiResponse<bool>
        {
            Data = IsUpdated,
            StatusCode = StatusCodes.Status200OK
        });
    }

}
