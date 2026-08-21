namespace LibraryManagementSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MemberController : ControllerBase
{
    private readonly IMemberService _memberService;

    public MemberController(IMemberService memberService)
    {
        _memberService = memberService;
    }

    [HttpPost("create-Member")]
    public async Task<IActionResult> CreateMember(MemberDto memberDto, CancellationToken cancellationToken)
    {
        var member = await _memberService.CreateMemberAsync(memberDto, cancellationToken);
        return Ok(new ApiResponse<MemberDto>
        {
            Data = member,
        });
    }
    [HttpDelete("delete-member/{memberId:int}")]
    public async Task<IActionResult> DeleteMember(int memberId, CancellationToken cancellationToken)
    {
        var isDeleted = await _memberService.DeleteMemberAsync(memberId, cancellationToken);
        return Ok(new ApiResponse<bool>
        {
            Data = isDeleted,
        });
    }

    [HttpGet("get-member-by-id/{memberId:int}")]
    public async Task<IActionResult> GetMembGetMemberByIderByAsync(int memberId, CancellationToken cancellationToken)
    {
        var member = await _memberService.GetMemberByIdAsync(memberId, cancellationToken);
        return Ok(new ApiResponse<MemberDto>
        {
            Data = member,
        });
    }
    [HttpPut("update-member")]
    public async Task<IActionResult> UpdateMemberAsync(MemberDto memberDto, CancellationToken cancellationToken)
    {
        var isUpdated = await _memberService.UpdateMemberAsync(memberDto, cancellationToken);

        return Ok(new ApiResponse<bool>
        {
            Data = isUpdated,
        });
    }

    [HttpGet("search-members")]
    public async Task<IActionResult> SearchMember(
       [FromQuery] string searchText,
       CancellationToken cancellationToken)
    {
        var member = await _memberService
            .SearchMember(searchText, cancellationToken);
        return Ok(new ApiResponse<MemberSearchDto>
        {
            Data = member,
            StatusCode = StatusCodes.Status200OK
        });
    }
}