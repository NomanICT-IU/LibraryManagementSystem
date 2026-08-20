namespace LibraryManagementSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BorrowRecordController : ControllerBase
{
    private readonly IBorrowRecordService _borrowRecordService;

    public BorrowRecordController(IBorrowRecordService borrowRecordService)
    {
        _borrowRecordService = borrowRecordService;
    }

    [HttpPost("create-borrow-record")]
    public async Task<IActionResult> CreateBorrowRecordAsync(BorrowRecordDto borrowRecordDto, CancellationToken cancellationToken)
    {
        var borrowRecord = await _borrowRecordService
            .CreateBorrowRecordAsync(borrowRecordDto, cancellationToken);

        return Ok(new ApiResponse<BorrowRecordDto>
        {
            Data = borrowRecord,
            StatusCode = StatusCodes.Status200OK
        });
    }

    [HttpDelete("delete-borrow-record/{borrowId:int}")]
    public async Task<IActionResult> DeleteBorrowBookAsync(int borrowId, CancellationToken cancellationToken)
    {
        var isDeleted = await _borrowRecordService.DeleteBorrowBookAsync(borrowId, cancellationToken);

        return Ok(new ApiResponse<bool>
        {
            Data = isDeleted,
            StatusCode = StatusCodes.Status200OK
        });
    }

    [HttpGet("get-borrow-record-by-id/{borrowId:int}")]
    public async Task<IActionResult> GetBorrowRecordByIdAsync(int borrowId, CancellationToken cancellationToken)
    {
        var borrowRecord = await _borrowRecordService.GetBorrowRecordByIdAsync(borrowId, cancellationToken);


        return Ok(new ApiResponse<BorrowRecordDto>
        {

            Data = borrowRecord,
            StatusCode = StatusCodes.Status200OK

        });

    }
    [HttpPut("update-borrow-record")]
    public async Task<IActionResult> UpdateBorrowRecordAsync(BorrowRecordDto borrowRecordDto, CancellationToken cancellationToken)
    {
        var isUpdated = await _borrowRecordService.UpdateBorrowRecordAsync(borrowRecordDto, cancellationToken);

        return Ok(new ApiResponse<bool>
        {
            Data = isUpdated,
            StatusCode = StatusCodes.Status200OK
        });
    }





}
