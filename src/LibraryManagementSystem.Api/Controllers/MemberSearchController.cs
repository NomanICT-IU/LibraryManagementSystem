namespace LibraryManagementSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MemberSearchController : ControllerBase
{
    private readonly IMemberSearchService _memberSearchService;

    public MemberSearchController(IMemberSearchService memberSearchService)
    {
        _memberSearchService = memberSearchService;
    }

    [HttpGet("search-member")]
    public async Task<IActionResult> SearchMember(
        [FromQuery] string searchText,
        CancellationToken cancellationToken)
    {
        var member = await _memberSearchService
            .SearchMember(searchText, cancellationToken);
        return Ok(new ApiResponse<FindMemberDto>
        {
            Data = member,
            StatusCode = StatusCodes.Status200OK
        });
    }
}